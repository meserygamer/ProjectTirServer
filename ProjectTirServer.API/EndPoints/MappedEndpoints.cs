namespace ProjectTirServer.API.EndPoints
{
    public static class MappedEndpoints
    {
        public static void AddMappedEndPoints(this IEndpointRouteBuilder builder)
        {
            builder.AddServerCheckEndPoints();

        }
    }
}
