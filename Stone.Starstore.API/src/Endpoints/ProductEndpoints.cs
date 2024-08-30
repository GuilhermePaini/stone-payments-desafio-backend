using Flunt.Notifications;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Stone.StarstoreAPI.Data;
using Stone.StarstoreAPI.Models;
using Stone.StarstoreAPI.ViewModels;

namespace Stone.StarstoreAPI.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/product", CreateProduct);
            app.MapGet("/products", GetProducts);
        }

        public static Results<Created, BadRequest<IReadOnlyCollection<Notification>>> CreateProduct(ProductContext dbContext, CreateProductRequest productRequest)
        {
            if (productRequest.IsValid)
            {
                var product = productRequest.MapTo();

                dbContext.Add(product);
                dbContext.SaveChanges();

                return TypedResults.Created();
            }

            return TypedResults.BadRequest(productRequest.Notifications);
        }

        public static Results<Ok<List<Product>>, NoContent> GetProducts(ProductContext dbContext)
        {
            var products = dbContext.Products
                    .AsNoTracking()
                    .ToList();

            if (products.Count == 0)
                return TypedResults.NoContent();

            return TypedResults.Ok(products);
        }
    }
}