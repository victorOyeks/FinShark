using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public class QueryObject
    {
        public String? Symbol { get; set; } = null;
        public String? CompanyName { get; set; } = null;
        public String? SortBy { get; set; } = null;
        public bool isDescending { get; set; } = false;
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; }  = 20;
    }
}