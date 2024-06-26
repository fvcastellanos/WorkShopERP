﻿namespace WorkShopERP.Model
{
    public partial class CarBrand
    {
        public CarBrand()
        {
            CarLines = [];
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public int Active { get; set; }
        public string Tenant { get; set; } = null!;

        public virtual ICollection<CarLine> CarLines { get; set; }
    }
}
