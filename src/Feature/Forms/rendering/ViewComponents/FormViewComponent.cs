using Microsoft.AspNetCore.Mvc;
using Mvp.Feature.Forms.Models;
using Sitecore.AspNet.RenderingEngine.Binding;
using System.Threading.Tasks;

namespace Mvp.Feature.Forms.ViewComponents
{
    public class FormViewComponent : ViewComponent
    {
        private readonly IViewModelBinder viewModelBinder;

        public FormViewComponent(IViewModelBinder viewModelBinder)
        {
            this.viewModelBinder = viewModelBinder;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await viewModelBinder.Bind<Form>(this.ViewContext);
            model.ActionUrl = $"https://mvp-cd.sc.localhost/api/jss/formbuilder?fxb.FormItemId={model.Metadata.ItemId}&fxb.HtmlPrefix={model.HtmlPrefix}&sc_apikey={{E2F3D43E-B1FD-495E-B4B1-84579892422A}}&sc_itemid={model.Metadata.ItemId}";

            HttpContext.Response.Cookies.Append("__RequestVerificationToken", 
                model?.AntiForgeryToken?.Value, 
                new Microsoft.AspNetCore.Http.CookieOptions() {
                    Domain = ".sc.localhost"
                }
            );

            return View(model);
        }
    }
}
