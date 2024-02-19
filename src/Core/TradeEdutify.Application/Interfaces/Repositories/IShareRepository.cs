using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Interfaces.Repositories
{
    public interface IShareRepository
    {
        Task<List<Share>> UpdateShare(List<Share> entityList);

        Task<List<Share>> GetShareList();

        Task<Share> GetShareBySymbol(string Symbol);

        bool ShareUpdateAvailable(List<Share> entityList);
    }
}