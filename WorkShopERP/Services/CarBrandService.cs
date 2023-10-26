
using WorkShopERP.Model;

namespace WorkShopERP.Services
{

    public class CarBrandService
    {
        private readonly WorkShopERPContext dbContext;

        public CarBrandService(WorkShopERPContext dbContext) {

            this.dbContext = dbContext;
        }
    }
}