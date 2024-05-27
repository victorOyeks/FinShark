using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account.Portfolio
{
    public class PortfolioDto
    {
        public string AppUserId { get; set; } = string.Empty;
        public int StockId { get; set; } 
    }
}