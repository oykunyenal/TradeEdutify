﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeEdutify.Domain.Entities
{
    [Table("User")]
    public class User
    {
        public User()
        {
            this.Transactions = new List<Transaction>();
            this.Portfolios = new List<Portfolio>();
        }

        [Key]
        public long UserID { get; set; }

        public string Username { get; set; } = string.Empty;
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Portfolio>? Portfolios { get; set; }
    }
}