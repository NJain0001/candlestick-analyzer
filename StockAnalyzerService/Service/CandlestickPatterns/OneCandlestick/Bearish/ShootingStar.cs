using System;
using StockAnalyzerService.Model;

namespace StockAnalyzerService.Service {
    public class ShootingStar : IOneCandlestickPattern {
        public Boolean Apply(Candlestick candlestick) {
            var HighLowPriceDifference = candlestick.HighPrice - candlestick.LowPrice;
			var HighOpenPriceDifference = candlestick.HighPrice - candlestick.OpenPrice;
			var OpenClosePriceDifference = candlestick.OpenPrice - candlestick.ClosePrice;
			var CloseLowPriceDifference = candlestick.ClosePrice - candlestick.LowPrice;

			var UpperWickRatio = HighOpenPriceDifference / HighLowPriceDifference;
			var BodyRatio = OpenClosePriceDifference / HighLowPriceDifference;
			var LowerWickRatio = CloseLowPriceDifference / HighLowPriceDifference;

			if ((UpperWickRatio / BodyRatio) >= 2 && LowerWickRatio <= .05) {
				return true;
			}

			return false;
        }
    }
}