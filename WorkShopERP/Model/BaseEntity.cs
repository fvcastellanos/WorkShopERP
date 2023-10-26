
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShopERP.Model
{
    public abstract class BaseEntity
    {
        [Column("tenant", TypeName = "varchar(50)")]
        public string Tenant { get; set; }
    }
}