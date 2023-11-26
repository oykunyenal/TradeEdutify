using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeEdutify.Domain.Entities;

namespace TradeEdutify.Persistence.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    UserID = 100,
                    Username = "Ethan Hayes"
                },
                new User
                {
                    UserID = 101,
                    Username = "Olivia Foster"
                },
                new User
                {
                    UserID = 102,
                    Username = "Amelia Rodriguez"
                },
                new User
                {
                    UserID = 103,
                    Username = "Sophia Chang"
                },
                new User
                {
                    UserID = 104,
                    Username = "Jackson Bennett"
                });

            modelBuilder.Entity<Share>()
                .HasData(new Share
                {
                    LastUpdateDate = DateTime.Now,
                    Rate = 45.43,
                    ShareID = 100,
                    Symbol = "AGT",
                },
                new Share
                {
                    LastUpdateDate = DateTime.Now,
                    Rate = 30.16,
                    ShareID = 101,
                    Symbol = "THY",
                },
                new Share
                {
                    LastUpdateDate = DateTime.Now,
                    Rate = 70.32,
                    ShareID = 102,
                    Symbol = "EGS",
                },
                new Share
                {
                    LastUpdateDate = DateTime.Now,
                    Rate = 120.76,
                    ShareID = 103,
                    Symbol = "ODR",
                },
                new Share
                {
                    LastUpdateDate = DateTime.Now,
                    Rate = 12.10,
                    ShareID = 104,
                    Symbol = "VHY",
                }
                );



            modelBuilder.Entity<Portfolio>().HasData(new Portfolio
            {
                ShareID = 100,
                UserID = 100,
                PortfolioID = 100,
                OperationDate = DateTime.Now,
            },
            new Portfolio
            {
                ShareID = 102,
                UserID = 101,
                PortfolioID = 101,
                OperationDate = DateTime.Now,
            },
            new Portfolio
            {
                ShareID = 103,
                UserID = 101,
                PortfolioID = 102,
                OperationDate = DateTime.Now,
            },
            new Portfolio
            {
                ShareID = 104,
                UserID = 102,
                PortfolioID = 103,
                OperationDate = DateTime.Now,
            },
            new Portfolio
            {
                ShareID = 103,
                UserID = 102,
                PortfolioID = 104,
                OperationDate = DateTime.Now,
            });


            modelBuilder.Entity<Transaction>().HasData(new Transaction
            {
                OperationDate = DateTime.Now,
                Quantity = 3,
                TradeType = Domain.Enums.TradeType.BUY,
                UserID = 100,
                ShareID = 100,
                TotalOperationPrice = 45.43 * 3,
                TransactionID = 100,
                UnitPrice = 45.44
            },
            new Transaction
            {
                OperationDate = DateTime.Now,
                Quantity = 20,
                TradeType = Domain.Enums.TradeType.BUY,
                UserID = 101,
                ShareID = 102,
                TotalOperationPrice = 30.16 * 20,
                TransactionID = 101,
                UnitPrice = 30.16
            },
            new Transaction
            {
                OperationDate = DateTime.Now,
                Quantity = 10,
                TradeType = Domain.Enums.TradeType.BUY,
                UserID = 101,
                ShareID = 103,
                TotalOperationPrice = 120.76 * 10,
                TransactionID = 103,
                UnitPrice = 120.76
            },
            new Transaction
            {
                OperationDate = DateTime.Now,
                Quantity = 5,
                TradeType = Domain.Enums.TradeType.SELL,
                UserID = 101,
                ShareID = 103,
                TotalOperationPrice = 125.76 * 5,
                TransactionID = 104,
                UnitPrice = 125.76
            },
            new Transaction
            {
                OperationDate = DateTime.Now,
                Quantity = 5,
                TradeType = Domain.Enums.TradeType.BUY,
                UserID = 102,
                ShareID = 104,
                TotalOperationPrice = 12.1 * 5,
                TransactionID = 105,
                UnitPrice = 12.1
            },
            new Transaction
            {
                OperationDate = DateTime.Now,
                Quantity = 20,
                TradeType = Domain.Enums.TradeType.BUY,
                UserID = 102,
                ShareID = 103,
                TotalOperationPrice = 120.76 * 20,
                TransactionID = 106,
                UnitPrice = 120.76
            }
            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
