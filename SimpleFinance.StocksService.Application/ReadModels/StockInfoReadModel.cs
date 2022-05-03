namespace SimpleFinance.StocksService.Application.ReadModels
{
    internal class StockInfoReadModel
    {
        public string symbol { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string currency { get; set; } = string.Empty;
        public string exchange { get; set; } = string.Empty;
        public string mic_code { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
    }
}
