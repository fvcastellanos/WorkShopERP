using WorkShopERP.Domain.Views;
using WorkShopERP.Model;

namespace WorkShopERP.Transformers
{
    public static class CarBrandTransformer
    {
        public static CarBrandView ToView(CarBrand carBrand)
        {
            return new CarBrandView {

                Id = carBrand.Id,
                Name = carBrand.Name,
                Description = carBrand.Description,
                Active = carBrand.Active
            };
        }
    }
}