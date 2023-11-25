using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Domain.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Portfolio>? Portfolios { get; set; }
    }
}
