using System;
using Microsoft.AspNetCore.Authentication;
using PushDemoAPI.Authentication;

namespace PushDemoAPI.Authentication
{
    public static class AuthenticationBuilderExtensions
    {
        // This extension method simplifies the middleware configuration code in Startup.cs making it more readable and generally easier to follow.
        public static AuthenticationBuilder AddApiKeyAuth(
            this AuthenticationBuilder builder,
            Action<ApiKeyAuthOptions> configureOptions)
        {
            return builder
                .AddScheme<ApiKeyAuthOptions, ApiKeyAuthHandler>(
                    ApiKeyAuthOptions.DefaultScheme,
                    configureOptions);
        }
    }
}