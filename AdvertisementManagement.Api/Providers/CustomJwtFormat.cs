using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Configuration;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;

namespace AdvertisementManagement.Api.Providers
{
    public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        public object TextEncoding { get; private set; }
        private readonly string _issuer = string.Empty;

        public CustomJwtFormat(string issuer)
        {
            _issuer = issuer;
        }
             
        public string Protect(AuthenticationTicket data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("data");
            }

            var appId = ConfigurationManager.AppSettings["AppId"];
            var appSecret = ConfigurationManager.AppSettings["AppSecret"];

            var keyByteArray = TextEncodings.Base64Url.Decode(appSecret);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;
            var expires = data.Properties.ExpiresUtc;
            var token = new JwtSecurityToken(_issuer, appId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.WriteToken(token);
            
            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            throw new NotImplementedException();
        }
    }
}