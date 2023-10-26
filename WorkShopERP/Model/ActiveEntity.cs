using System.ComponentModel.DataAnnotations.Schema;

namespace WorkShopERP.Model
{
    public abstract class ActiveEntity : BaseEntity
    {
        [Column("active", TypeName = "int")]
        public int Active { get; set; }
    }
}