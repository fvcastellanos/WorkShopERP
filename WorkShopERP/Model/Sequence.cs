using System;
using System.Collections.Generic;

namespace WorkShopERP.Model
{
    public partial class Sequence
    {
        public uint Id { get; set; }
        public string Prefix { get; set; } = null!;
        public string Value { get; set; } = null!;
        public DateTime Updated { get; set; }
    }
}
