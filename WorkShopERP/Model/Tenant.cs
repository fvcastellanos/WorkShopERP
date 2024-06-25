using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class Tenant
    {
        public Tenant()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Active { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
