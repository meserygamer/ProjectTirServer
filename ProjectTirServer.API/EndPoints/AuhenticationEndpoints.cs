using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjectTirServer.API.Contracts.Authentication;
using System.Security.Claims;

namespace ProjectTirServer.API.EndPoints
{
    public static class AuhenticationEndpoints
    {
        public static IEndpointRouteBuilder AddAuthenticationEndpoints(this IEndpointRouteBuilder builder) 
        {
            var group = builder.MapGroup("authentication");

            group.MapPost("login", Login);
            group.MapPost("logout", Logout);

            return builder;
        }


        private static async Task<IResult> Login(HttpContext context, [FromBody] AuthenticationLoginRequest loginData)
        {
            ICollection<Claim> claims = new List<Claim>() { new Claim("sessionId", Guid.NewGuid().ToString()) };
            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await context.SignInAsync(new ClaimsPrincipal(identity));
            return Results.Ok("Login completed");
        }

        private static async Task<IResult> Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Ok("Logout completed");
        }
    }
}
