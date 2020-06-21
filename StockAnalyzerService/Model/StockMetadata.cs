using System;
using System.Collections;
using System.Collections.Generic;

namespace StockAnalyzerService.Model {
	public class StockMetadata {
        public string Ticker { get; set; }
        public string CompanyName { get; set; }
        public List<User> Users { get; set; }
    }
}