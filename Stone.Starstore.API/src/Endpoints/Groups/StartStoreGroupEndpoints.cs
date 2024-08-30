namespace Stone.StarstoreAPI.Endpoints.Groups
{
    public static class StartStoreGroupEndpoints
    {
        public static void MapStarStoreGroup(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/starstore");
            
            group.MapTransactionEndpoints();
            group.MapProductEndpoints();
        }
    }
}