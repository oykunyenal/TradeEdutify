using AutoMapper;
using FluentValidation;
using MediatR;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Application.Features.Queries.ShareQueries;
using TradeEdutify.Application.Interfaces.Repositories;
using TradeEdutify.Application.Parameters;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Features.Handlers
{
    public class ShareQueryHandler : IRequestHandler<UpdateShareQuery, ApiServiceResponse>,
        IRequestHandler<GetShareListQuery, ApiServiceResponse>,
        IRequestHandler<SellShareQuery, ApiServiceResponse>,
        IRequestHandler<BuyShareQuery, ApiServiceResponse>
    {
        private readonly IShareRepository shareRepository;
        private readonly IUserRepository userRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IPortfolioRepository portfolioRepository;
        private readonly IValidator<ShareDto> validator;
        private readonly IValidator<List<ShareDto>> listValidator;
        private readonly IMapper mapper;
        private ApiServiceResponse apiServiceResponse;

        public ShareQueryHandler(IShareRepository shareRepository, IMapper mapper, IValidator<ShareDto> validator, IValidator<List<ShareDto>> listValidator, IUserRepository userRepository, ITransactionRepository transactionRepository, IPortfolioRepository portfolioRepository)
        {
            this.shareRepository = shareRepository;
            this.mapper = mapper;
            this.validator = validator;
            this.listValidator = listValidator;
            apiServiceResponse = new ApiServiceResponse();
            this.userRepository = userRepository;
            this.transactionRepository = transactionRepository;
            this.portfolioRepository = portfolioRepository;
        }

        public async Task<ApiServiceResponse> Handle(UpdateShareQuery request, CancellationToken cancellationToken)
        {
            if (!request.ShareList.Any())
            {
                throw new ArgumentNullException(nameof(request.ShareList), "UpdateShareQuery Handle -> Share List in request can not be null");
            }

            var listValidationResult = listValidator.Validate(request.ShareList);

            if (!listValidationResult.IsValid)
            {
                var failures = listValidationResult.Errors.Select(err => err.ErrorMessage).ToList();

                apiServiceResponse = new ApiServiceResponse
                {
                    Message = string.Join(", ", failures),
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            request.ShareList.ForEach(item => item.LastUpdateDate = DateTime.UtcNow);

            var shareListOnUpdate = mapper.Map<List<Share>>(request.ShareList);

            var isShareUpdateAvailable = shareRepository.ShareUpdateAvailable(shareListOnUpdate);

            if (!isShareUpdateAvailable)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "Share update can be done every 1 hour period",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var updatedShareList = await shareRepository.UpdateShare(shareListOnUpdate);

            if (!updatedShareList.Any())
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "Share update operation failed. Check for logs",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            apiServiceResponse = new ApiServiceResponse
            {
                Message = "",
                Result = true,
                Object = mapper.Map<List<ShareDto>>(updatedShareList)
            };

            return Task.FromResult(apiServiceResponse).Result;
        }

        public async Task<ApiServiceResponse> Handle(GetShareListQuery request, CancellationToken cancellationToken)
        {
            var shareList = await shareRepository.GetShareList();

            if (!shareList.Any())
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Object = null,
                    Result = false,
                    Message = "There is no element in list"
                };
                return Task.FromResult(apiServiceResponse).Result;
            }

            apiServiceResponse = new ApiServiceResponse
            {
                Object = mapper.Map<List<ShareDto>>(shareList),
                Result = true,
                Message = ""
            };

            return Task.FromResult(apiServiceResponse).Result;
        }

        public async Task<ApiServiceResponse> Handle(BuyShareQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserClaim))
            {
                throw new ArgumentNullException(nameof(request.UserClaim), "BuyShareQuery Handle -> Userclaim in request can not be null");
            }

            if (request.ShareTransactionRequestModel is null)
            {
                throw new ArgumentNullException(nameof(request.UserClaim), "BuyShareQuery Handle -> ShareTransactionRequestModel in request can not be null");
            }

            var user = await userRepository.GetUserByUsername(request.UserClaim);

            if (user is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "User not found in the system",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var availableShareToBuy = await shareRepository.GetShareBySymbol(request.ShareTransactionRequestModel.Symbol);

            if (availableShareToBuy is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "There is no available share to buy",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var isShareExistInPortfolioForUser = await portfolioRepository.CheckShareExistInPortfolioForUser(user.UserID, availableShareToBuy.ShareID);

            if (!isShareExistInPortfolioForUser)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "User has no registered share in his/her portfolio",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var mappedShare = mapper.Map<ShareDto>(availableShareToBuy);

            var validationResult = validator.Validate(mappedShare);

            if (!validationResult.IsValid)
            {
                var failures = validationResult.Errors.Select(err => err.ErrorMessage).ToList();

                apiServiceResponse = new ApiServiceResponse
                {
                    Message = string.Join(", ", failures),
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var mappedUser = mapper.Map<UserDto>(user);

            Transaction transaction = new Transaction
            {
                Quantity = request.ShareTransactionRequestModel.Quantity,
                ShareID = mappedShare.ShareID,
                OperationDate = DateTime.UtcNow,
                TotalOperationPrice = mappedShare.Rate * request.ShareTransactionRequestModel.Quantity,
                TradeType = Domain.Enums.TradeType.BUY,
                UnitPrice = mappedShare.Rate,
                UserID = mappedUser.UserID,
            };

            var transactionAddResult = await transactionRepository.AddTransaction(transaction);

            if (transactionAddResult is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "Error while adding transaction, please check logs",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            Portfolio portfolio = new Portfolio
            {
                OperationDate = DateTime.UtcNow,
                ShareID = mappedShare.ShareID,
                UserID = mappedUser.UserID,
                Share = null,
                User = null
            };

            var portfolioAddResult = await portfolioRepository.AddPortfolio(portfolio);

            if (portfolioAddResult is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "Error while adding portfolio, please check logs",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            apiServiceResponse = new ApiServiceResponse
            {
                Object = null,
                Result = true,
                Message = "Share Buy Operation Completed with Success"
            };

            return Task.FromResult(apiServiceResponse).Result;
        }

        public async Task<ApiServiceResponse> Handle(SellShareQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserClaim))
            {
                throw new ArgumentNullException(nameof(request.UserClaim), "SellShareQuery Handle -> Userclaim in request can not be null");
            }

            if (request.ShareTransactionRequestModel is null)
            {
                throw new ArgumentNullException(nameof(request.UserClaim), "SellShareQuery Handle -> ShareTransactionRequestModel in request can not be null");
            }

            var user = await userRepository.GetUserByUsername(request.UserClaim);

            if (user is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "User not found in the system",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var isPortfolioExistForUser = await portfolioRepository.CheckPortfolioExistForUser(user.UserID);

            if (!isPortfolioExistForUser)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "User has no registered portfolio",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var availableShareToBuy = await shareRepository.GetShareBySymbol(request.ShareTransactionRequestModel.Symbol);

            if (availableShareToBuy is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "There is no available share to sell",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            var mappedShare = mapper.Map<ShareDto>(availableShareToBuy);

            int availableShareCount = await transactionRepository.GetAvailableShareLimitForUser(user.UserID, mappedShare.ShareID);

            if (availableShareCount < request.ShareTransactionRequestModel.Quantity)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = $"User can not sell the given amount because the limit for user => {availableShareCount}",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            Transaction transaction = new Transaction
            {
                Quantity = request.ShareTransactionRequestModel.Quantity,
                ShareID = mappedShare.ShareID,
                OperationDate = DateTime.UtcNow,
                TotalOperationPrice = mappedShare.Rate * request.ShareTransactionRequestModel.Quantity,
                TradeType = Domain.Enums.TradeType.SELL,
                UnitPrice = mappedShare.Rate,
                UserID = user.UserID,
            };

            var transactionAddResult = await transactionRepository.AddTransaction(transaction);

            if (transactionAddResult is null)
            {
                apiServiceResponse = new ApiServiceResponse
                {
                    Message = "Error while adding transaction, please check logs",
                    Result = false,
                    Object = null
                };

                return Task.FromResult(apiServiceResponse).Result;
            }

            apiServiceResponse = new ApiServiceResponse
            {
                Object = null,
                Result = true,
                Message = "Share Sell Operation Completed with Success"
            };

            return Task.FromResult(apiServiceResponse).Result;
        }
    }
}