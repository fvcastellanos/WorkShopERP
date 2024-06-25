using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public string Id { get; set; } = null!;
        public string ContactId { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string? Suffix { get; set; }
        public string Number { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Tenant { get; set; } = null!;
        public string Status { get; set; } = null!;

        public virtual Contact Contact { get; set; } = null!;
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
