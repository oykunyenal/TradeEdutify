using TradeEdutify.Domain.Enums;

namespace TradeEdutify.Application.Dtos
{
    public record TransactionDto
    {
        public Guid TransactionID { get; set; }
        public TradeType TradeType { get; set; }
        public Guid ShareID { get; set; }
        public Guid UserID { get; set; }
        public DateTimeOffset OperationDate { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalOperationPrice { get; set; }
    }
}
