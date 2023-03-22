using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PushDemoAPI.Authentication;

namespace PushDemoAPI.Authentication
{
    /// <summary>
    /// An Authentication Handler is a type that implements the behavior of a scheme, in this case a custom API Key scheme.
    /// </summary>
    public class ApiKeyAuthHandler : AuthenticationHandler<ApiKeyAuthOptions>
    {
        const string ApiKeyIdentifier = "apikey";

        public ApiKeyAuthHandler(
            IOptionsMonitor<ApiKeyAuthOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock)
            : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string key = string.Empty;

            if (Request.Headers[ApiKeyIdentifier].Any())
            {
                key = Request.Headers[ApiKeyIdentifier].FirstOrDefault();
            }
            else if (Request.Query.ContainsKey(ApiKeyIdentifier))
            {
                if (Request.Query.TryGetValue(ApiKeyIdentifier, out var queryKey))
                    key = queryKey;
            }

            if (string.IsNullOrWhiteSpace(key))
                return Task.FromResult(AuthenticateResult.Fail("No api key provided"));

            if (!string.Equals(key, Options.ApiKey, StringComparison.Ordinal))
                return Task.FromResult(AuthenticateResult.Fail("Invalid api key."));

            var identities = new List<ClaimsIdentity> {
                new ClaimsIdentity("ApiKeyIdentity")
            };

            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identities), Options.Scheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}