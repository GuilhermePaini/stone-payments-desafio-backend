using Stone.StarstoreAPI.Data;
using Stone.StarstoreAPI.Endpoints.Groups;

namespace Stone.StarstoreAPI;

internal static class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ProductContext>();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        #region Custom Endpoints
        
        app.MapStarStoreGroup();

        #endregion

        app.Run();
    }
}