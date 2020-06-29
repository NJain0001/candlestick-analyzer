using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class HangingMan : IOneCandlestickPattern {
        public Boolean Apply(Candlestick candlestick) {
			var HighLowPriceDifference = candlestick.HighPrice - candlestick.LowPrice;
			var HighOpenPriceDifference = candlestick.HighPrice - candlestick.OpenPrice;
			var OpenClosePriceDifference = candlestick.OpenPrice - candlestick.ClosePrice;
			var CloseLowPriceDifference = candlestick.ClosePrice - candlestick.LowPrice;

			var UpperWickRatio = HighOpenPriceDifference / HighLowPriceDifference;
			var BodyRatio = OpenClosePriceDifference / HighLowPriceDifference;
			var LowerWickRatio = CloseLowPriceDifference / HighLowPriceDifference;

			if ((LowerWickRatio / BodyRatio) >= 2 && UpperWickRatio <= .05) {
				return true;
			}

			return false;
		}
    }
}