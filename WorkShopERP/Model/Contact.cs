using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class Contact
    {
        public Contact()
        {
            Invoices = new HashSet<Invoice>();
            WorkOrders = new HashSet<WorkOrder>();
        }

        public string Id { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Contact1 { get; set; }
        public string? TaxId { get; set; }
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Active { get; set; }
        public string Tenant { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
