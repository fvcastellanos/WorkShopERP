using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
            WorkOrderDetails = new HashSet<WorkOrderDetail>();
        }

        public string Id { get; set; } = null!;
        public string CarLineId { get; set; } = null!;
        public string ContactId { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string PlateNumber { get; set; } = null!;
        public string OdometerMeasurement { get; set; } = null!;
        public double OdometerValue { get; set; }
        public double GasAmount { get; set; }
        public string Tenant { get; set; } = null!;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string? Notes { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual CarLine CarLine { get; set; } = null!;
        public virtual Contact Contact { get; set; } = null!;
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
    }
}
