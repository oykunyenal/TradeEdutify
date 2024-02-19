using Microsoft.EntityFrameworkCore;
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

        public async Task<Share> GetShareBySymbol(string Symbol)
        {
            return await _dbContext.Shares
                .Where(q => q.Symbol.Equals(Symbol))
                .OrderByDescending(s => s.LastUpdateDate)
                .FirstOrDefaultAsync();
        }

        public bool ShareUpdateAvailable(List<Share> entityList)
        {
            foreach (var item in entityList)
            {
                var selectedShareItem = GetShareBySymbol(item.Symbol).Result;

                if (selectedShareItem is null)
                {
                    return true;
                }

                var elapsedTime = DateTime.UtcNow - selectedShareItem.LastUpdateDate;

                if (elapsedTime.TotalHours < 1)
                {
                    return false;
                }
            }
            return true;
        }
    }
}