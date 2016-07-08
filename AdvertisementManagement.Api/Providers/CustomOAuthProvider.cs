using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using AdvertisementManagement.Api.Infrastucture;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

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
            ApplicationUser appUser = await appUserManager.FindAsync(context.UserName, context.Password);

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

            ClaimsIdentity oAuthIdentity = await appUser.GenerateUserIdentityAsync(appUserManager, "JWT");
         
            var ticket = new AuthenticationTicket(oAuthIdentity, null);

            context.Validated(ticket);
        }
    }
}