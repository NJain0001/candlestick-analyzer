using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class HangingMan : IOneCandlestickPattern {
        public CandlestickAnalysis Apply(Candlestick candlestick, string ticker) {
			var HighLowPriceDifference = candlestick.HighPrice - candlestick.LowPrice;
			var HighOpenPriceDifference = candlestick.HighPrice - candlestick.OpenPrice;
			var OpenClosePriceDifference = candlestick.OpenPrice - candlestick.ClosePrice;
			var CloseLowPriceDifference = candlestick.ClosePrice - candlestick.LowPrice;

			var UpperWickRatio = HighOpenPriceDifference / HighLowPriceDifference;
			var BodyRatio = OpenClosePriceDifference / HighLowPriceDifference;
			var LowerWickRatio = CloseLowPriceDifference / HighLowPriceDifference;

			if ((LowerWickRatio / BodyRatio) >= 2 && UpperWickRatio <= .05) {
				return new CandlestickAnalysis() {
                    Ticker = ticker,
                    Timestamp = candlestick.Timestamp,
                    Pattern = "Hanging Man",
                    Action = StockAction.Sell
                };
			}

			return null;
		}
    }
}