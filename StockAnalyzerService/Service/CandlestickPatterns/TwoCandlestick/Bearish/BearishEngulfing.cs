using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {

    public class BearishEngulfing : ITwoCandlestickPattern
    {
        public CandlestickAnalysis Apply(Candlestick firstCandle, Candlestick secondCandle, string ticker)
        {
            // confirm first candle is red
            var isFirstCandleGreen = firstCandle.OpenPrice < firstCandle.ClosePrice;
            // confirm second candle is green
            var isSecondCandleRed = secondCandle.OpenPrice > secondCandle.ClosePrice;
            // confirm second candle is bigger than first
            var isFirstCandleEngulfed = firstCandle.HighPrice < secondCandle.OpenPrice 
                                        && firstCandle.LowPrice > secondCandle.ClosePrice;
            
            if (isFirstCandleGreen && isSecondCandleRed && isFirstCandleEngulfed)
            {
                return new CandlestickAnalysis() {
                    Ticker = ticker,
                    Timestamp = firstCandle.Timestamp,
                    Pattern = "Bearish Engulfing",
                    Action = StockAction.Sell
                };
            }
            return null;
        }
    }
}