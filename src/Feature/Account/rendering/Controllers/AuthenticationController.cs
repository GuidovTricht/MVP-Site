using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Mvp.Feature.Account.Services;
using Mvp.Feature.Account.ViewModels;
using System.Linq;

namespace Mvp.Feature.Account.Controllers
{
    //Can't make it into an ApiController as I then need to add routing attributes, 
    //which I don't want to do as that will overwrite the routing Sitecore has in place
    //[ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var result = authenticationService.Login(loginViewModel.Username, loginViewModel.Password).ConfigureAwait(false).GetAwaiter().GetResult();

            if (result != null && result.Any())
            {
                foreach (var c in result)
                {
                    Response.Headers.Append("Set-Cookie", c);
                }
            }

            return Redirect("/");
        }
    }
}
