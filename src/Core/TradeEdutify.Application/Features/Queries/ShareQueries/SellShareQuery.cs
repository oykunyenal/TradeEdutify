using MediatR;
using TradeEdutify.Application.Parameters;
using TradeEdutify.Application.Parameters.RequestParameters;

namespace TradeEdutify.Application.Features.Queries.ShareQueries
{
    public class SellShareQuery : IRequest<ApiServiceResponse>
    {
        public ShareTransactionRequestModel ShareTransactionRequestModel { get; set; }
        public string UserClaim { get; set; }

        public SellShareQuery(ShareTransactionRequestModel shareTransactionRequestModel, string userClaim)
        {
            this.ShareTransactionRequestModel = shareTransactionRequestModel;
            this.UserClaim = userClaim;
        }
    }
}