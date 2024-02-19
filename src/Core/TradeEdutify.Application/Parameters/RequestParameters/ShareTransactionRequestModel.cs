namespace TradeEdutify.Application.Parameters.RequestParameters
{
    public class ShareTransactionRequestModel
    {
        public string Symbol { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}