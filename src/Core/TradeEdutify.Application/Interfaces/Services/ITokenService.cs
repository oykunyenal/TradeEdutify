using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(string Username);
    }
}
