using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class CarLine
    {
        public CarLine()
        {
            WorkOrders = new HashSet<WorkOrder>();
        }

        public string Id { get; set; } = null!;
        public string CarBrandId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public uint Active { get; set; }
        public DateTime Created { get; set; }
        public string Tenant { get; set; } = null!;

        public virtual CarBrand CarBrand { get; set; } = null!;
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
