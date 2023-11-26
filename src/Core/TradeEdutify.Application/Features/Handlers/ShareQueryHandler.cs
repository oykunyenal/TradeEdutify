using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private readonly IValidator<ShareDto> validator;
        private readonly IValidator<List<ShareDto>> listValidator;
        private readonly IMapper mapper;
        private ApiServiceResponse apiServiceResponse;

        public ShareQueryHandler(IShareRepository shareRepository, IMapper mapper, IValidator<ShareDto> validator, IValidator<List<ShareDto>> listValidator)
        {
            this.shareRepository = shareRepository;
            this.mapper = mapper;
            this.validator = validator;
            this.listValidator = listValidator;
            apiServiceResponse = new ApiServiceResponse();

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

            var shareListOnUpdate = mapper.Map<List<Share>>(request.ShareList);

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

        public Task<ApiServiceResponse> Handle(BuyShareQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApiServiceResponse> Handle(SellShareQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
