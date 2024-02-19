namespace TradeEdutify.Application.Dtos
{
    public record UserDto
    {
        public UserDto()
        {
            this.TransactionDtoList = new List<TransactionDto>();
            this.PortfolioDtoList = new List<PortfolioDto>();
        }

        public long UserID { get; set; }
        public string Username { get; set; } = string.Empty;
        public List<TransactionDto>? TransactionDtoList { get; set; }
        public List<PortfolioDto>? PortfolioDtoList { get; set; }
    }
}