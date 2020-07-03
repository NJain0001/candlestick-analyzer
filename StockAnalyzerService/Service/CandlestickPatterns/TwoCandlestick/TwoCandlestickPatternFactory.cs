using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class TwoCandlestickPatternFactory : ITwoCandlestickPatternFactory
    {
        public List<ITwoCandlestickPattern> PatternDict { get; private set; }

        public TwoCandlestickPatternFactory() {
            PatternDict = new List<ITwoCandlestickPattern>() {
                new BullishEngulfing(),
                new BearishEngulfing()
            };
        }
    }
}