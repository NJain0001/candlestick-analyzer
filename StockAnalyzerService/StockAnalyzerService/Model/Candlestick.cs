using System;
using CsvHelper.Configuration.Attributes;

namespace StockAnalyzerService.Model {
    public class Candlestick
    {
        [Name("timestamp")]
        public DateTime Timestamp { get; set; }
        [Name("high")]
        public double HighPrice { get; set; }
        [Name("low")]
        public double LowPrice { get; set; }
        [Name("open")]
        public double OpenPrice { get; set; }
        [Name("close")]
        public double ClosePrice { get; set; }
    }
}
