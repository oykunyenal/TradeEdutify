using MediatR;
using TradeEdutify.Application.Parameters;
using TradeEdutify.Application.Parameters.RequestParameters;

namespace TradeEdutify.Application.Features.Queries.ShareQueries
{
    public class BuyShareQuery : IRequest<ApiServiceResponse>
    {
        public ShareTransactionRequestModel ShareTransactionRequestModel { get; set; }

        public string UserClaim { get; set; }

        public BuyShareQuery(ShareTransactionRequestModel shareTransactionRequestModel, string userClaim)
        {
            this.ShareTransactionRequestModel = shareTransactionRequestModel;
            this.UserClaim = userClaim;
        }
    }
}