using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class TwoCandlestickPatternFactory : ITwoCandlestickPatternFactory
    {
        public Dictionary<ITwoCandlestickPattern, StockAction> PatternDict { get; private set; }

        public TwoCandlestickPatternFactory() {
            PatternDict = new Dictionary<ITwoCandlestickPattern, StockAction>() {
                { new BullishEngulfing(), StockAction.Buy },
                { new BearishEngulfing(), StockAction.Sell }
            };
        }
    }
}