using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Mvp.Feature.Account.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureAccount(this RenderingEngineOptions options)
        {
            options.AddViewComponent("Login");
            options.AddViewComponent("Logout");

            return options;
        }
    }
}