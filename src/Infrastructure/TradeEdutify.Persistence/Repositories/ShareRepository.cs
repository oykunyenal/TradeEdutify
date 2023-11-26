using Microsoft.EntityFrameworkCore;
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
    public class ShareRepository : IShareRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public ShareRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<Share>> UpdateShare(List<Share> entityList)
        {
            await _dbContext.AddRangeAsync(entityList);
            await _dbContext.SaveChangesAsync();
            return entityList;
        }

        public async Task<List<Share>> GetShareList()
        {
            return await _dbContext.Shares.AsNoTracking().ToListAsync();
        }
    }
}
