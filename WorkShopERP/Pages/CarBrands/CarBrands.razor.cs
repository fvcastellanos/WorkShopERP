
using Microsoft.AspNetCore.Components;
using WorkShopERP.Domain.Views;
using WorkShopERP.Services;

namespace WorkShopERP.Pages
{
    public class CarBrandPage : CrudBase
    {
        [Inject]
        protected CarBrandService Service { get; set; }

        IEnumerable<CarBrandView> CarBrands { get; set; }

        protected SearchView SearchView { get; set; }

        protected override async Task OnInitializedAsync()
        {
            CarBrands = [];

            SearchView = new SearchView
            {
                Text = "",
                Active = 1,
                Page = DefaultPage,
                Size = DefaultPageSize
            };
        }

        protected void Search()
        {
            try
            {
                var tenant = GetTenantCode();

                var result = Service.Search(SearchView, tenant);

                if (result != null)
                {
                    CarBrands = result;
                }

            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
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