namespace ProjectTirServer.API.EndPoints
{
    public static class ServerCheckEndpoints
    {
        public static IEndpointRouteBuilder AddServerCheckEndPoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("serverChecker");

            group.MapGet("checkServerState", CheckServerState);

            return builder;
        }


        private static async Task<IResult> CheckServerState()
        {
            return Results.Ok("Server is running");
        }
    }
}
