using System.Threading.Tasks;
using AdvertisementManagement.Api.Infrastucture;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace AdvertisementManagement.Api.Providers
{
    public class CustomOAuthProvider: OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Enable CORS
            var allowedOrigin = "*";
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
            var appUserManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var appUser = await appUserManager.FindAsync(context.UserName, context.Password);

            if(appUser == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            if (!appUser.EmailConfirmed)
            {
                context.SetError("invalid_grant", "The user didn't confirm the email");
                return;
            }

            var oAuthIdentity = await appUser.GenerateUserIdentityAsync(appUserManager, "JWT");
         
            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }
    }
}