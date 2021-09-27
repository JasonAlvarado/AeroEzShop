using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroEzShop.Api.Models
{
    public class CategoryTreeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public List<CategoryTreeItem> Subcategories { get; set; }
    }
}
