using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class OneCandlestickPatternFactory {
        public Dictionary<IOneCandlestickPattern, StockAction> PatternDict { get; private set; }

        public OneCandlestickPatternFactory() {
            PatternDict = new Dictionary<IOneCandlestickPattern, StockAction>();
            PatternDict.Add(new ShootingStar(), StockAction.Buy);
            PatternDict.Add(new InvertedHammer(), StockAction.Buy);
            PatternDict.Add(new Hammer(), StockAction.Sell);
            PatternDict.Add(new HangingMan(), StockAction.Sell);
        }
    }
}