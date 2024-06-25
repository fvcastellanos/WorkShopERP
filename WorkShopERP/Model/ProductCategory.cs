using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Active { get; set; }
        public string Tenant { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
