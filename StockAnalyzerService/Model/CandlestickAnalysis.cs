using System;
using CsvHelper.Configuration.Attributes;

namespace StockAnalyzerService.Model {
    public class CandlestickAnalysis {
        [Name("ticker")]
        public string Ticker { get; set; }
        [Name("timestamp")]
        public DateTime Timestamp { get; set; }
        [Name("pattern")]
        public string Pattern { get; set; }
        [Name("action")]
        public StockAction Action { get; set; }
    }
}