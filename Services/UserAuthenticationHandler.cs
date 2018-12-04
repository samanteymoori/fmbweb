using FMB.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace FMB.Services
{
    public class UserAuthenticationHandler : AuthenticationHandler<UserAuthenticationOptions>
    {
        IAuthenticationService _service = null;
        public UserAuthenticationHandler(
            IOptionsMonitor<UserAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IAuthenticationService service)
            : base(options, logger, encoder, clock)
        {

            _service = service;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var headers = Request.Headers;
            byte[] usr = null;
            if (!Request.HttpContext.Session.TryGetValue("usr", out usr))
            {
                return Task.FromResult(AuthenticateResult.Fail("Unauthorized"));
            }
            var token = "X-Auth-Token";

            var claims = new[] { new Claim("token", token) };
            var identity = new ClaimsIdentity(claims, nameof(UserAuthenticationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), this.Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
