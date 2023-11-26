using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Interfaces.Repositories
{
    public interface IShareRepository
    {
        Task<List<Share>> UpdateShare(List<Share> entityList);
        Task<List<Share>> GetShareList();
        Task<Share> GetShareBySymbol(string Symbol);
    }
}
