using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Features.Queries.ShareQueries;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.Application.Features.Handlers
{
    public class ShareQueryHandler : IRequestHandler<UpdateShareQuery, ApiServiceResponse>,
        IRequestHandler<GetShareListQuery, ApiServiceResponse>,
        IRequestHandler<SellShareQuery, ApiServiceResponse>,
        IRequestHandler<BuyShareQuery, ApiServiceResponse>
    {
        public Task<ApiServiceResponse> Handle(UpdateShareQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ApiServiceResponse> Handle(GetShareListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
