using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class InvoiceDetail
    {
        public InvoiceDetail()
        {
            Inventories = new HashSet<Inventory>();
            WorkOrderDetails = new HashSet<WorkOrderDetail>();
        }

        public string Id { get; set; } = null!;
        public string InvoiceId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string? WorkOrderId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime Created { get; set; }
        public string Tenant { get; set; } = null!;

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual WorkOrder? WorkOrder { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
    }
}
