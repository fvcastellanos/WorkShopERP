using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class WorkOrderDetail
    {
        public string Id { get; set; } = null!;
        public string WorkOrderId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string? InvoiceDetailId { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string Tenant { get; set; } = null!;
        public DateTime Created { get; set; }

        public virtual InvoiceDetail? InvoiceDetail { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual WorkOrder WorkOrder { get; set; } = null!;
    }
}
