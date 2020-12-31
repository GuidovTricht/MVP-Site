using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Mvp.Foundation.Multisite.Configuration;
using System;

namespace Mvp.Foundation.Multisite.Services
{
    public class SiteResolver : ISiteResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private SitecoreOptions Configuration { get; }

        public SiteResolver(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.Configuration = configuration.GetSection(SitecoreOptions.Key).Get<SitecoreOptions>();
            this._httpContextAccessor = httpContextAccessor;
        }

        //Check if there is a site in the AppSettings which matches the current Request properties
        //If not, we return the DefaultSiteName setting as a fallback
        public string GetContextSite()
        {
            foreach (var siteInfo in Configuration.Sites)
                if (Matches(siteInfo.HostName, siteInfo.VirtualFolder, siteInfo.Port))
                    return siteInfo.SiteName;

            return Configuration.DefaultSiteName;
        }

        //If host, folder and port match with the current Request properties, then we treat it as a match
        private bool Matches(string host, string folder, int port)
        {
            var currentRequest = _httpContextAccessor.HttpContext.Request;
            if (currentRequest.Host.Host.Equals(host, StringComparison.InvariantCultureIgnoreCase)
                && (!currentRequest.Host.Port.HasValue || currentRequest.Host.Port.Value.Equals(port))
                && currentRequest.Path.Value.StartsWith(folder))
                return true;
            return false;
        }
    }
}
