using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mvp.Foundation.Multisite.Services;
using Sitecore.LayoutService.Client;
using Sitecore.LayoutService.Client.Request;
using Sitecore.LayoutService.Client.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvp.Foundation.Multisite.Client
{
    public class MultisiteLayoutClient : ISitecoreLayoutClient, ILayoutRequestHandler
    {
        public readonly string SiteKey = "sc_site";
        private readonly IServiceProvider _services;
        private readonly IOptions<SitecoreLayoutClientOptions> _layoutClientOptions;
        private readonly IOptionsSnapshot<SitecoreLayoutRequestOptions> _layoutRequestOptions;
        private readonly ILogger<MultisiteLayoutClient> _logger;
        private readonly ISiteResolver _siteResolver;

        public MultisiteLayoutClient(
            IServiceProvider services,
            IOptions<SitecoreLayoutClientOptions> layoutClientOptions,
            IOptionsSnapshot<SitecoreLayoutRequestOptions> layoutRequestOptions,
            ILogger<MultisiteLayoutClient> logger,
            ISiteResolver siteResolver)
        {
            this._services = services;
            this._layoutClientOptions = layoutClientOptions;
            this._layoutRequestOptions = layoutRequestOptions;
            this._logger = logger;
            this._siteResolver = siteResolver;
        }

        public async Task<SitecoreLayoutResponse> Request(SitecoreLayoutRequest request)
        {
            return await this.Request(request, string.Empty).ConfigureAwait(false);
        }

        public async Task<SitecoreLayoutResponse> Request(SitecoreLayoutRequest request, string handlerName)
        {
            string str = !string.IsNullOrWhiteSpace(handlerName) ? handlerName : this._layoutClientOptions.Value.DefaultHandler;
            if (string.IsNullOrWhiteSpace(str))
                throw new ArgumentNullException(str, "Exception_HandlerNameIsNull"); //Original Exception details are in an internal class
            if (!this._layoutClientOptions.Value.HandlerRegistry.ContainsKey(str))
            {
                throw new KeyNotFoundException(str); //Original Exception details are in an internal class
            }
            SitecoreLayoutRequest sitecoreLayoutRequest = request.UpdateRequest(this.MergeLayoutRequestOptions(str).RequestDefaults);

            //Custom: Resolve current site based on HttpContext Request Host
            var contextSiteName = _siteResolver.GetContextSite();
            if(!string.IsNullOrEmpty(contextSiteName))
                if (sitecoreLayoutRequest.ContainsKey(SiteKey))
                    sitecoreLayoutRequest[SiteKey] = contextSiteName;
                else
                    sitecoreLayoutRequest.Add(SiteKey, contextSiteName);

            Func<IServiceProvider, ILayoutRequestHandler> func = this._layoutClientOptions.Value.HandlerRegistry[str];
            if (this._logger.IsEnabled(LogLevel.Trace))
                this._logger.LogTrace("Sitecore Layout Request " + ToDebugString<string, object>(sitecoreLayoutRequest));
            IServiceProvider services = this._services;
            return await func(services).Request(sitecoreLayoutRequest, str).ConfigureAwait(false);
        }

        private SitecoreLayoutRequestOptions MergeLayoutRequestOptions(string handlerName)
        {
            SitecoreLayoutRequestOptions currentOptions = this._layoutRequestOptions.Value;
            SitecoreLayoutRequestOptions handlerOptions = this._layoutRequestOptions.Get(handlerName);
            if (AreEqual(currentOptions.RequestDefaults, handlerOptions.RequestDefaults))
                return currentOptions;
            SitecoreLayoutRequestOptions resultOptions = currentOptions;
            SitecoreLayoutRequest currentDefaults = currentOptions.RequestDefaults;
            SitecoreLayoutRequest handlerDefaults = handlerOptions.RequestDefaults;
            foreach (KeyValuePair<string, object> keyValuePair in (Dictionary<string, object>)handlerDefaults)
            {
                if (currentDefaults.ContainsKey(keyValuePair.Key))
                    currentDefaults[keyValuePair.Key] = handlerDefaults[keyValuePair.Key];
                else
                    currentDefaults.Add(keyValuePair.Key, handlerDefaults[keyValuePair.Key]);
            }
            resultOptions.RequestDefaults = currentDefaults;
            return resultOptions;
        }

        private bool AreEqual(
          IDictionary<string, object> dictionary1,
          IDictionary<string, object> dictionary2)
        {
            if (dictionary1.Count != dictionary2.Count)
                return false;
            foreach (string key in dictionary1.Keys)
            {
                object obj;
                if (!dictionary2.TryGetValue(key, out obj) || dictionary1[key] != obj)
                    return false;
            }
            return true;
        }

        private string ToDebugString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key?.ToString() + "=" + kv.Value?.ToString()).ToArray()) + "}";
        }
    }
}
