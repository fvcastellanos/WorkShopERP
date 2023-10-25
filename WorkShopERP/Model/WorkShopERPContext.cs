
using Microsoft.EntityFrameworkCore;

namespace WorkShopERP.Model 
{

    public class WorkShopERPContext: DbContext
    {

        public WorkShopERPContext(DbContextOptions options): base(options)
        {
            // db context initialize
        }
    }
}