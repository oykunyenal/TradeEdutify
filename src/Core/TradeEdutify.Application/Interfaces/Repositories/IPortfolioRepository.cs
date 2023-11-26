using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Interfaces.Repositories
{
    public interface IPortfolioRepository
    {
        Task<Portfolio> AddPortfolio(Portfolio entity);
    }
}
