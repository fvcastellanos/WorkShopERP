
using Microsoft.AspNetCore.Components;
using WorkShopERP.Services;

namespace WorkShopERP.Pages
{
    public class CarBrandPage : CrudBase
    {
        [Inject]
        protected CarBrandService service { get; set; }

        protected override void Add()
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            throw new NotImplementedException();
        }
    }
}