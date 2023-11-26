using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Application.Dtos;
using TradeEdutify.Application.Interfaces.Services;
using TradeEdutify.Application.Services;
using TradeEdutify.Application.Validations;

namespace TradeEdutify.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(assembly));

            services.AddSingleton<ITokenService, TokenService>();

            services.AddTransient<IValidator<UserDto>, UserValidator>();
            services.AddTransient<IValidator<TransactionDto>, TransactionValidator>();
            services.AddTransient<IValidator<PortfolioDto>, PortfolioValidator>();
            services.AddTransient<IValidator<ShareDto>, ShareValidator>();
            services.AddTransient<IValidator<List<ShareDto>>, ShareListValidator>();
        }
    }
}
