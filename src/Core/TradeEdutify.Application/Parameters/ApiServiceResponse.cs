namespace TradeEdutify.Application.Parameters
{
    public class ApiServiceResponse
    {
        public object? Object { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}