﻿using StockAnalyzerService.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalyzerService.Service {
    public interface IStockAnalyzer {
        Task<List<StockMetadata>> GetStocksWithUsers();
    }
}
