using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzerService.Model {
    class StockAnalysisData {
        public DateTime DateTimeOfData { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double OpenPrice { get; set; }
        public double ClosePrice { get; set; }

        public static StockAnalysisData FromCsv(string csvRow) {
            string[] data = csvRow.Split(',');
            StockAnalysisData stockAnalysisData = new StockAnalysisData
            {
                DateTimeOfData = Convert.ToDateTime(data[0]),
                OpenPrice = Convert.ToDouble(data[1]),
                HighPrice = Convert.ToDouble(data[2]),
                LowPrice = Convert.ToDouble(data[3]),
                ClosePrice = Convert.ToDouble(data[4])
            };
            return stockAnalysisData;
        }
    }
}
