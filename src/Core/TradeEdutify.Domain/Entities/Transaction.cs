using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeEdutify.Domain.Enums;

namespace TradeEdutify.Domain.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public long TransactionID { get; set; }

        public TradeType TradeType { get; set; }
        public long ShareID { get; set; }
        public long UserID { get; set; }
        public DateTimeOffset OperationDate { get; set; }

        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "The UnitPrice should be exactly 2 double digits.")]
        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "The TotalOperationPrice should be exactly 2 double digits.")]
        public double TotalOperationPrice { get; set; }
    }
}