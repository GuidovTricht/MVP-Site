using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.Feature.Account.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientFactory clientFactory;

        public AuthenticationService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<string>> Login(string username, string password, string domain = "sitecore")
        {
            var client = clientFactory.CreateClient("sitecoreClient");

            var content = $"{{\"domain\": \"{domain}\", \"username\": \"{username}\", \"password\": \"{password}\"}}";
            var postContent = new StringContent(content, Encoding.UTF8, "application/json");

            var httpResponse =
                await client.PostAsync("/sitecore/api/ssc/auth/login", postContent);

            return httpResponse.Headers.GetValues("Set-Cookie").ToList();
        }

        public async Task<bool> Logout(StringValues cookies)
        {
            var client = clientFactory.CreateClient("sitecoreClient");
            client.DefaultRequestHeaders.Add("Cookie", cookies.ToString());

            var postContent = new StringContent("", Encoding.UTF8, "application/json");

            var httpResponse =
                await client.PostAsync("/sitecore/api/ssc/auth/logout", postContent);

            return httpResponse.IsSuccessStatusCode;
        }
    }
}
