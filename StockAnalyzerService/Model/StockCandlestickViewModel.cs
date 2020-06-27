using System.Collections.Generic;

namespace StockAnalyzerService.Model {

    public class StockCandlestickViewModel : StockMetadata
    {
        public StockCandlestickViewModel()
        {
            Candlesticks = new List<Candlestick>();
        }
        public List<Candlestick> Candlesticks { get; set; }
    }
}