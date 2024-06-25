
using Microsoft.AspNetCore.Components;
using WorkShopERP.Services;

namespace WorkShopERP.Pages
{
    public class CarBrandPage : CrudBase
    {
        [Inject]
        protected CarBrandService Service { get; set; }

        protected override void OnInitialized()
        {
            // service.Search()
            // service.Test();
        }

        protected override async Task OnInitializedAsync()
        {
            var tenant = await UserService.GetTenantCodeAsync();

            System.Console.WriteLine(tenant);


        }

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