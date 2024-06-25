
using WorkShopERP.Domain.Views;
using WorkShopERP.Model;
using WorkShopERP.Transformers;

namespace WorkShopERP.Services
{

    public class CarBrandService
    {
        private readonly WorkShopERPContext dbContext;

        public CarBrandService(WorkShopERPContext dbContext) 
        {

            this.dbContext = dbContext;
        }

        public void Test() 
        {

            dbContext.CarBrands.Where(carBrand => carBrand.Tenant.Equals("resta", StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<CarBrandView> Search(SearchView searchView, string tenant)
        {

            int skip = (searchView.Page - 1) * searchView.Size;

            return dbContext.CarBrands
                .Where(carBrand => carBrand.Tenant.Equals(tenant))
                .Where(carBrand => carBrand.Name.Contains(searchView.Text, StringComparison.CurrentCultureIgnoreCase))
                .Where(carBrand => carBrand.Active == searchView.Active)
                .Skip(skip)
                .Take(searchView.Size)
                .Select(CarBrandTransformer.ToView);
        }
    }
}