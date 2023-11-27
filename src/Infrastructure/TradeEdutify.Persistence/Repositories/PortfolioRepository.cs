using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Interfaces.Repositories;
using TradeEdutify.Application.Parameters.ResponseParameters;
using TradeEdutify.Domain.Entities;
using TradeEdutify.Persistence.Context;

namespace TradeEdutify.Persistence.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {

        private readonly ApplicationDBContext _dbContext;

        public PortfolioRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<Portfolio> AddPortfolio(Portfolio entity)
        {
            await _dbContext.Set<Portfolio>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> CheckPortfolioExistForUser(long UserID)
        {
            return await _dbContext.Portfolios.AnyAsync(q => q.UserID == UserID);
        }

        public async Task<bool> CheckShareExistInPortfolioForUser(long UserID, long ShareID)
        {
            return await _dbContext.Portfolios.AnyAsync(q => q.UserID == UserID && q.ShareID == ShareID);
        }

        public async Task<List<Portfolio>> GetPortfolioListForUser(string Username)
        {
            var portfolioList = await _dbContext.Portfolios
                .PortfolioWithRelations()
                .ToListAsync();

            var filteredList = portfolioList.Where(q => q.User.Username.Equals(Username)).ToList();

            return filteredList;
        }
    }
}
