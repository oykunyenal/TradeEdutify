using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Domain.Entities
{
    public class Share
    {
        public Guid ShareID { get; set; }

        [RegularExpression(@"^[A-Z]{3}$", ErrorMessage = "Symbol should be a three-character capital letter.")]
        public string Symbol { get; set; } = string.Empty;

        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "The Rate should be exactly 2 decimal digits.")]
        public decimal Rate { get; set; }
        public DateTimeOffset LastUpdateDate { get; set; }

        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Portfolio>? Portfolios { get; set; }
    }
}
