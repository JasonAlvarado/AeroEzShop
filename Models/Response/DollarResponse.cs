using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.Response
{
    public class DollarResponse
    {
        public decimal Rate { get; set; }
        public string Currency { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
