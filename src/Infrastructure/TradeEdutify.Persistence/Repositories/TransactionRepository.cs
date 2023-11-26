using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Interfaces.Repositories;
using TradeEdutify.Domain.Entities;
using TradeEdutify.Persistence.Context;

namespace TradeEdutify.Persistence.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public TransactionRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<Transaction> AddTransaction(Transaction entity)
        {
            await _dbContext.Set<Transaction>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> GetAvailableShareLimitForUser(long UserID, long ShareID)
        {
            var transactionListForUser = _dbContext.Transactions.Where(q => q.UserID == UserID && q.ShareID == ShareID).AsQueryable();

            int sumOfBoughtSharesForUser = transactionListForUser.Where(q => q.TradeType == Domain.Enums.TradeType.BUY).Sum(s => s.Quantity);

            int sumOfSoldSharesForUser = transactionListForUser.Where(q => q.TradeType == Domain.Enums.TradeType.SELL).Sum(s => s.Quantity);

            return sumOfBoughtSharesForUser - sumOfSoldSharesForUser;
        }

    }
}
