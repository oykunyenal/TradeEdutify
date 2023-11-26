using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Interfaces.Repositories;
using TradeEdutify.Persistence.Context;
using TradeEdutify.Persistence.Repositories;

namespace TradeEdutify.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IShareRepository, ShareRepository>();
            services.AddTransient<IPortfolioRepository, PortfolioRepository>();
        }
    }
}
