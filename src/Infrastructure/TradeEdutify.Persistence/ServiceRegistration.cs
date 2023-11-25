using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Persistence.Context;

namespace TradeEdutify.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
