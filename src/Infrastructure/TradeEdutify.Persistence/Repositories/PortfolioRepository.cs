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
    }
}
