using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TradeEdutify.Application.Interfaces.Repositories;
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
       

    }
}
