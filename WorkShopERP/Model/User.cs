using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class User
    {
        public string Id { get; set; } = null!;
        public string TenantId { get; set; } = null!;
        public string Provider { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        public virtual Tenant Tenant { get; set; } = null!;
    }
}
