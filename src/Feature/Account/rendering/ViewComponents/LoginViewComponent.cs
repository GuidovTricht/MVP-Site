using Microsoft.AspNetCore.Mvc;

namespace Mvp.Feature.Account.ViewComponents
{
    public class LoginViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            // Return the model to the Default.cshtml Razor view.
            return View();
        }
    }
}
