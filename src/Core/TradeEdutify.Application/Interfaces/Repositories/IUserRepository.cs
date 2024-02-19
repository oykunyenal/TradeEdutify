using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsername(string Username);
    }
}