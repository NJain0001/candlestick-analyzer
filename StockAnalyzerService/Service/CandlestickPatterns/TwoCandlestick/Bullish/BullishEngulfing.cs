using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {

    public class BullishEngulfing : ITwoCandlestickPattern
    {
        public CandlestickAnalysis Apply(Candlestick firstCandle, Candlestick secondCandle, string ticker)
        {
            var isFirstCandleRed = firstCandle.OpenPrice > firstCandle.ClosePrice;
            // confirm second candle is green
            var isSecondCandleGreen = secondCandle.OpenPrice < secondCandle.ClosePrice;
            // confirm second candle is bigger than first
            var isFirstCandleEngulfed = firstCandle.HighPrice < secondCandle.ClosePrice 
                                        && firstCandle.LowPrice > secondCandle.OpenPrice;
            
            if (isFirstCandleRed && isSecondCandleGreen && isFirstCandleEngulfed)
            {
                return new CandlestickAnalysis() {
                    Ticker = ticker,
                    Timestamp = firstCandle.Timestamp,
                    Pattern = "Bullish Engulfing",
                    Action = StockAction.Buy
                };
            } 
            return null;
        }
    }
}