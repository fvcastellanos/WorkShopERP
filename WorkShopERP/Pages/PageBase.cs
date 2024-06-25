
using Microsoft.AspNetCore.Components;
using WorkShopERP.Services;

namespace WorkShopERP.Pages
{
    public abstract class PageBase: ComponentBase
    {
        [Inject]
        protected UserService UserService { get; set; }
        protected bool DisplayErrorMessage;

        protected string ErrorMessage;

        protected void HideErrorMessage()
        {
            DisplayErrorMessage = false;
            ErrorMessage = "";
        }

        protected void ShowErrorMessage(string message)
        {
            DisplayErrorMessage = true;
            ErrorMessage = message;
        }        
    }
}