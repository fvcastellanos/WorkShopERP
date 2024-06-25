using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class Inventory
    {
        public string Id { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string? InvoiceDetailId { get; set; }
        public string OperationType { get; set; } = null!;
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double Total { get; set; }
        public DateTime Created { get; set; }
        public string? Description { get; set; }
        public DateTime Updated { get; set; }
        public string Tenant { get; set; } = null!;
        public DateTime OperationDate { get; set; }

        public virtual InvoiceDetail? InvoiceDetail { get; set; }
        public virtual Product Product { get; set; } = null!;
    }
}
