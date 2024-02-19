using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Interfaces.Repositories
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> AddPortfolio(Portfolio entity);

        Task<bool> CheckPortfolioExistForUser(long UserID);

        Task<bool> CheckShareExistInPortfolioForUser(long UserID, long ShareID);

        Task<List<Portfolio>> GetPortfolioListForUser(string Username);
    }
}