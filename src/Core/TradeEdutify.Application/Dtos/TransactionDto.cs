using TradeEdutify.Domain.Enums;

namespace TradeEdutify.Application.Dtos
{
    public record TransactionDto
    {
        public long TransactionID { get; set; }
        public TradeType TradeType { get; set; }
        public long ShareID { get; set; }
        public long UserID { get; set; }
        public DateTimeOffset OperationDate { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalOperationPrice { get; set; }
    }
}