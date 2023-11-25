using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeEdutify.Domain.Entities
{
    public class Portfolio
    {
        public Guid PortfolioID { get; set; }
        public DateTimeOffset OperationDate { get; set; }
        public Guid UserID { get; set; }
        public Guid ShareID { get; set; }

        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        [ForeignKey("ShareID")]
        public virtual Share? Share { get; set; }
    }
}
