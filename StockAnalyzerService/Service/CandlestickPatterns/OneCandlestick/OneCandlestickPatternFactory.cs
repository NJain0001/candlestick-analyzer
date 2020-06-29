using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class OneCandlestickPatternFactory {
        private Dictionary<IOneCandlestickPattern, StockAction> _PatternDict;

        public OneCandlestickPatternFactory() {
            _PatternDict = new Dictionary<IOneCandlestickPattern, StockAction>();
        }
        public Dictionary<IOneCandlestickPattern, StockAction> CreatePatterns() {
            _PatternDict.Add(new ShootingStar(), StockAction.Buy);
            _PatternDict.Add(new InvertedHammer(), StockAction.Buy);
            _PatternDict.Add(new Hammer(), StockAction.Sell);
            _PatternDict.Add(new HangingMan(), StockAction.Sell);

            return _PatternDict;
        }
    }
}