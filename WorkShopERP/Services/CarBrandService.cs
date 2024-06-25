
using WorkShopERP.Domain.Views;
using WorkShopERP.Model;
using WorkShopERP.Transformers;

namespace WorkShopERP.Services
{

    public class CarBrandService
    {
        private readonly WorkShopERPContext dbContext;
        private readonly ILogger<CarBrandService> logger;

        public CarBrandService(WorkShopERPContext dbContext,
                               ILogger<CarBrandService> logger) 
        {

            this.dbContext = dbContext;
            this.logger = logger;
        }

        public void Test() 
        {

            dbContext.CarBrands.Where(carBrand => carBrand.Tenant.Equals("resta", StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CarBrandView> Search(SearchView searchView, string tenant)
        {

            logger.LogInformation($"Searching car brands for tenant {tenant}");

            int skip = (searchView.Page - 1) * searchView.Size;

            var text = "";

            if (!string.IsNullOrEmpty(searchView.Text))
            {
                text = searchView.Text;
            }

            return dbContext.CarBrands
                .Where(carBrand => carBrand.Tenant.Equals(tenant))
                .Where(carBrand => carBrand.Name.ToLower().Contains(text, StringComparison.CurrentCultureIgnoreCase))
                .Where(carBrand => carBrand.Active == searchView.Active)
                .Skip(skip)
                .Take(searchView.Size)
                .Select(CarBrandTransformer.ToView)
                .ToList();
        }
    }
}