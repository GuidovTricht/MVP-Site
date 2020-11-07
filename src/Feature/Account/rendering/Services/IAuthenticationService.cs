using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mvp.Feature.Account.Services
{
    public interface IAuthenticationService
    {
        Task<List<string>> Login(string username, string password, string domain = "sitecore");
        Task<bool> Logout(StringValues cookies);
    }
}
