using BlazorWASM_HelloAuthentication.Shared.Models.CustomModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWASM_HelloAuthentication.Server.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet("oidc")]
        public async Task Login(string RedirectUri)
        {
            var props = new AuthenticationProperties
            {
                RedirectUri = RedirectUri
            };

            await HttpContext.ChallengeAsync("oidc", props);
        }

        [HttpGet]
        public CurrentUser CurrentUserInfo()
        {
            if (User.Claims.Any())
            {
                var username = User.Claims.Where(c => c.Type.Equals("name")).FirstOrDefault().Value ?? string.Empty;
                var email = User.Claims.Where(c => c.Type.Contains("email")).FirstOrDefault().Value;
                var nameidentifier = User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault().Value;

                var claimsDictionary = new Dictionary<string, string>
                {
                    { "username", username },
                    { "email", email },
                    { "nameidentifier", nameidentifier }
                };

                return new CurrentUser
                {
                    IsAuthenticated = User.Identity.IsAuthenticated,
                    UserName = username,
                    Claims = claimsDictionary
                };
            }
            else
            {
                return new CurrentUser
                {
                    IsAuthenticated = User.Identity.IsAuthenticated,
                    UserName = User.Identity.Name,
                    Claims = new Dictionary<string, string>()
                };
            }
        }


        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
