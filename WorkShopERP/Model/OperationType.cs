using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class OperationType
    {
        public string Id { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Active { get; set; }
        public string Tenant { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
