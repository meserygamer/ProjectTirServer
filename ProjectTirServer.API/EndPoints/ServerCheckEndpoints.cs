using Microsoft.AspNetCore.Authorization;
using ProjectTirServer.API.Filters;

namespace ProjectTirServer.API.EndPoints
{
    public static class ServerCheckEndpoints
    {
        public static IEndpointRouteBuilder AddServerCheckEndPoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("serverChecker");

            group.MapGet("checkServerState",  CheckServerState)
                .AddEndpointFilter<SessionFilter>();

            return builder;
        }


        [Authorize]
        private static async Task<IResult> CheckServerState()
        {
            return Results.Ok("Server is running");
        }
    }
}
