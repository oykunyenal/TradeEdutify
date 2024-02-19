namespace TradeEdutify.Application.Dtos
{
    public record ShareDto
    {
        public ShareDto()
        {
            this.TransactionDtoList = new List<TransactionDto>();
            this.PortfolioDtoList = new List<PortfolioDto>();
        }
        public long ShareID { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public double Rate { get; set; }
        public DateTimeOffset LastUpdateDate { get; set; }
        public List<TransactionDto>? TransactionDtoList { get; set; }
        public List<PortfolioDto>? PortfolioDtoList { get; set; }
    }
}