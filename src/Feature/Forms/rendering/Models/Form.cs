using Sitecore.AspNet.RenderingEngine.Binding.Attributes;
using System.Collections.Generic;

namespace Mvp.Feature.Forms.Models
{
    public class Form
    {
        public string ActionUrl { get; set; }
        [SitecoreComponentField]
        public string HtmlPrefix { get; set; }
        [SitecoreComponentField]
        public FormProperty FormSessionId { get; set; }
        [SitecoreComponentField]
        public FormProperty FormItemId { get; set; }
        [SitecoreComponentField]
        public FormProperty PageItemId { get; set; }
        [SitecoreComponentField]
        public FormProperty AntiForgeryToken { get; set; }
        [SitecoreComponentField]
        public FormMetadata Metadata { get; set; }
        [SitecoreComponentField]
        public List<FormField> Fields { get; set; }
    }
}
