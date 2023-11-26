using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
