using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Mvp.Feature.Account.Services;
using Sitecore.AspNet.RenderingEngine;
using System.Threading.Tasks;

namespace Mvp.Feature.Account.ViewComponents
{
    public class LogoutViewComponent : ViewComponent
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ISitecoreRenderingContext sitecoreRenderingContext;

        public LogoutViewComponent(IAuthenticationService authenticationService, ISitecoreRenderingContext sitecoreRenderingContext)
        {
            this.authenticationService = authenticationService;
            this.sitecoreRenderingContext = sitecoreRenderingContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!HttpContext.GetSitecoreRenderingContext().Response?.Content?.Sitecore?.Context?.IsEditing ?? false)
            {
                StringValues cookiesHeader;
                HttpContext.Request.Headers.TryGetValue("Cookie", out cookiesHeader);
                var result = await authenticationService.Logout(cookiesHeader);
                if (result)
                    HttpContext.Response.Cookies.Delete(".AspNet.Cookies");
                HttpContext.Response.Redirect("/");
            }
            // Return the model to the Default.cshtml Razor view.
            return Content("Logout component");
        }
    }
}
