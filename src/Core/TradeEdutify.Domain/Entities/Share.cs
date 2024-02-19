﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeEdutify.Domain.Entities
{
    [Table("Share")]
    public class Share
    {
        public Share()
        {
            this.Transactions = new List<Transaction>();
            this.Portfolios = new List<Portfolio>();
        }

        [Key]
        public long ShareID { get; set; }

        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Symbol should be a three-character capital letter.")]
        public string Symbol { get; set; } = string.Empty;

        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "The Rate should be exactly 2 double digits.")]
        public double Rate { get; set; }

        public DateTimeOffset LastUpdateDate { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Portfolio>? Portfolios { get; set; }
    }
}