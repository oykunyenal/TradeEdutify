using MediatR;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Application.Parameters;

namespace TradeEdutify.Application.Features.Queries.ShareQueries
{
    public class UpdateShareQuery : IRequest<ApiServiceResponse>
    {
        public List<ShareDto> ShareList { get; set; }

        public UpdateShareQuery(List<ShareDto> entityList)
        {
            this.ShareList = entityList;
        }
    }
}