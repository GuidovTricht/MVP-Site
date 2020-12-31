using System;

namespace Mvp.Foundation.Multisite.Configuration
{
    public class SitecoreOptions
    {
        public static readonly string Key = "Sitecore";

        public Uri InstanceUri { get; set; }
        public string LayoutServicePath { get; set; } = "/sitecore/api/layout/render/jss";
        public string DefaultSiteName { get; set; }
        public SiteInfo[] Sites { get; set; }
        public string ApiKey { get; set; }
        public Uri RenderingHostUri { get; set; }
        public bool EnableExperienceEditor { get; set; }

        public Uri LayoutServiceUri
        {
            get
            {
                if (InstanceUri == null) return null;

                return new Uri(InstanceUri, LayoutServicePath);
            }
        }
    }

    public class SiteInfo
    {
        public string SiteName { get; set; }
        public string HostName { get; set; }
        public string Scheme { get; set; }
        public int Port { get; set; }
        public string VirtualFolder { get; set; }
    }
}
