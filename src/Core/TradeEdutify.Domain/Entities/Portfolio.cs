﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeEdutify.Domain.Entities
{
    [Table("Portfolio")]
    public class Portfolio
    {
        [Key]
        public long PortfolioID { get; set; }

        public DateTimeOffset OperationDate { get; set; }
        public long UserID { get; set; }
        public long ShareID { get; set; }

        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        [ForeignKey("ShareID")]
        public virtual Share? Share { get; set; }
    }
}