using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Persistence.Repositories
{
    public static class PortfolioRelationQuery
    {
        public static IQueryable<Portfolio> PortfolioWithRelations(this IQueryable<Portfolio> query)
        {
            return query.Select(s => new Portfolio
            {
                UserID = s.UserID,
                ShareID = s.ShareID,
                OperationDate = s.OperationDate,
                PortfolioID = s.PortfolioID,
                User = s.User == null ? new User() : new User
                {
                    UserID = s.User.UserID,
                    Username = s.User.Username
                },
                Share = s.Share == null ? new Share() : new Share()
                {
                    ShareID = s.Share.ShareID,
                    Rate = s.Share.Rate,
                    Symbol = s.Share.Symbol,
                    LastUpdateDate = s.Share.LastUpdateDate,
                }
            });
        }
    }
}