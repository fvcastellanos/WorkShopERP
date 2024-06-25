using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            InvoiceDetails = new HashSet<InvoiceDetail>();
            WorkOrderDetails = new HashSet<WorkOrderDetail>();
        }

        public string Id { get; set; } = null!;
        public string? ProductCategoryId { get; set; }
        public string Type { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double MinimalQuantity { get; set; }
        public double SalePrice { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Active { get; set; }
        public string Tenant { get; set; } = null!;

        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
    }
}
