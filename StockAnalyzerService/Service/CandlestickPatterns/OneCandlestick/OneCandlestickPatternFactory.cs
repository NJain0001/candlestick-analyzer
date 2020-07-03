using System.Collections.Generic;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class OneCandlestickPatternFactory {
        public List<IOneCandlestickPattern> PatternDict { get; private set; }

        public OneCandlestickPatternFactory() {
            PatternDict = new List<IOneCandlestickPattern>();
            PatternDict.Add(new ShootingStar());
            PatternDict.Add(new InvertedHammer());
            PatternDict.Add(new Hammer());
            PatternDict.Add(new HangingMan());
        }
    }
}