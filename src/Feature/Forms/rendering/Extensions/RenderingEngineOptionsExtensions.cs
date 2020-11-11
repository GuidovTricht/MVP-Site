using Sitecore.AspNet.RenderingEngine.Configuration;
using Sitecore.AspNet.RenderingEngine.Extensions;

namespace Mvp.Feature.Forms.Extensions
{
    public static class RenderingEngineOptionsExtensions
    {
        public static RenderingEngineOptions AddFeatureForms(this RenderingEngineOptions options)
        {
            options.AddViewComponent("Form");
            
            return options;
        }
    }
}