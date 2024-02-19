namespace TradeEdutify.Application.Dtos
{
    public record PortfolioDto
    {
        public long PortfolioID { get; set; }
        public DateTimeOffset OperationDate { get; set; }
        public long UserID { get; set; }
        public long ShareID { get; set; }
    }
}