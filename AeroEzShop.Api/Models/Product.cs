using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Presentation { get; set; }
        public string Brand { get; set; }
        public string Photo { get; set; }
        public decimal? DollarPrice { get; set; }

        public decimal OriginalPrice { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
