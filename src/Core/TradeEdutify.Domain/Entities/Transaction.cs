using System.ComponentModel.DataAnnotations;

namespace TradeEdutify.Domain.Entities
{
    public class Transaction
    {
        public Guid TransactionID { get; set; }
        public TradeType TradeType { get; set; }
        public Guid ShareID { get; set; }
        public Guid UserID { get; set; }
        public DateTimeOffset OperationDate { get; set; }

        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "The UnitPrice should be exactly 2 decimal digits.")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [RegularExpression(@"^\d+\.\d{2}$", ErrorMessage = "The TotalOperationPrice should be exactly 2 decimal digits.")]
        public decimal TotalOperationPrice { get; set; }
    }


    public enum TradeType
    {
        BUY,
        SELL
    }
}
