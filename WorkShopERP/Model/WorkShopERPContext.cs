
using Microsoft.EntityFrameworkCore;
// using MySql.Data.Types;

namespace WorkShopERP.Model 
{

    // [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class WorkShopERPContext : DbContext
    {

        public virtual DbSet<CarBrand> CarBrands { get; set; }

        public WorkShopERPContext(string connectionString): base(connectionString)
        {
            // db context initialize
        }
    }
}
