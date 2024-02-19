using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<int> GetAvailableShareLimitForUser(long UserID, long ShareID);

        Task<Transaction> AddTransaction(Transaction entity);
    }
}