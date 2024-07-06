using Microsoft.AspNetCore.Authentication.Cookies;
using ProjectTirServer.API.EndPoints;

namespace ProjectTirServer.API.Extensions
{
    public static class APIExtensions
    {
        public static void AddMappedEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.AddServerCheckEndPoints();
            builder.AddAuthenticationEndpoints();
        }

        public static void AddApiAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }
    }
}
