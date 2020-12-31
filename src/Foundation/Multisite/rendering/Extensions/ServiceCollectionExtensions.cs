using Microsoft.Extensions.DependencyInjection;
using Mvp.Foundation.Multisite.Client;
using Mvp.Foundation.Multisite.Services;
using Sitecore.LayoutService.Client;
using System.Linq;

namespace Mvp.Foundation.Multisite.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ReplaceSitecoreLayoutClient(
            this IServiceCollection services)
        {
            //If exists, remove original ISitecoreLayoutClient service which uses DefaultLayoutClient as implementation
            var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ISitecoreLayoutClient));
            if (serviceDescriptor != null)
                services.Remove(serviceDescriptor);

            //Now add the ISitecoreLayoutClient service again with our custom implementation class
            ServiceCollectionServiceExtensions.AddTransient<ISitecoreLayoutClient>(services, (sp =>
            {
                using (IServiceScope scope = ServiceProviderServiceExtensions.CreateScope(sp))
                    return ActivatorUtilities.CreateInstance<MultisiteLayoutClient>(scope.ServiceProvider, new object[1]
                    {
                        sp
                    });
            }));

            //Add other custom services
            services.AddTransient<ISiteResolver, SiteResolver>();

            return services;
        }
    }
}
