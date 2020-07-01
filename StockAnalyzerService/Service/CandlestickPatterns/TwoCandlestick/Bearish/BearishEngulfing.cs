using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {

    public class BearishEngulfing : ITwoCandlestickPattern
    {
        public bool Apply(Candlestick firstCandle, Candlestick secondCandle)
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
                return true;
            }
            return false;
        }
    }
}