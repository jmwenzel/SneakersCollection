using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using SneakersCollection.Infrastructure.Authentication;
using System;

namespace SneakersCollection.Infrastructure.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JwtAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
            var token = ExtractToken(context.HttpContext.Request.Headers["Authorization"]);

            if (token == null || !authService.ValidateToken(token))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private string ExtractToken(string authorizationHeader)
        {
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }

            return authorizationHeader.Substring("Bearer ".Length).Trim();
        }
    }
}
