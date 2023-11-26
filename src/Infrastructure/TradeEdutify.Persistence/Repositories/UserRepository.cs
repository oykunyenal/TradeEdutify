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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public UserRepository(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<User> GetUserByUsername(string Username)
        {
            var getUserByUsernameResult = _dbContext.Users.Any(q => q.Username.Equals(Username));

            if (!getUserByUsernameResult)
            {
                return null;
            }

            return await _dbContext.Users.FirstOrDefaultAsync(q => q.Username.Equals(Username));
        }
    }
}
