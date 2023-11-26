using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.Application.Features.Queries.ShareQueries
{
    public class GetShareListQuery : IRequest<ApiServiceResponse>
    {
    }
}
