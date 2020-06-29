using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class InvertedHammer : IOneCandlestickPattern {
        public Boolean Apply(Candlestick candlestick) {
            var HighLowPriceDifference = candlestick.HighPrice - candlestick.LowPrice;
			var HighClosePriceDifference = candlestick.HighPrice - candlestick.ClosePrice;
			var CloseOpenPriceDifference = candlestick.ClosePrice - candlestick.OpenPrice;
			var OpenLowPriceDifference = candlestick.OpenPrice - candlestick.LowPrice;

			var UpperWickRatio = HighClosePriceDifference / HighLowPriceDifference;
			var BodyRatio = CloseOpenPriceDifference / HighLowPriceDifference;
			var LowerWickRatio = OpenLowPriceDifference / HighLowPriceDifference;

			if ((UpperWickRatio / BodyRatio) >= 2 && LowerWickRatio <= .05) {
				return true;
			}

			return false;
        }
    }
}