using System.Transactions;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Stone.StarstoreAPI.Data;
using Stone.StarstoreAPI.Models;
using Stone.StarstoreAPI.ViewModels;

namespace Stone.StarstoreAPI.Endpoints
{
    public static class TransactionEndpoints
    {
        public static void MapTransactionEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/buy", Buy);
            app.MapGet("/history", GetStoreHistory);
            app.MapGet("/history/{clientId}", GetCustomerHistory);
        }

        public static Results<Ok<List<Models.Transaction>>, NoContent> GetCustomerHistory(
            ProductContext dbContext, 
            Guid clientId)
        {
            var transactions = dbContext.Transactions
                .AsNoTracking()
                .Where(x => x.ClientId == clientId)
                .ToList();

            if (transactions.Count == 0)
                return TypedResults.NoContent();

            return TypedResults.Ok(transactions);
        }

        public static Results<Ok<List<Models.Transaction>>, NoContent> GetStoreHistory(ProductContext dbContext)
        {
            var transactions = dbContext.Transactions
                .AsNoTracking()
                .ToList();

            if (transactions.Count == 0)
                return TypedResults.NoContent();

            return TypedResults.Ok(transactions);
        }

        public static Results<Created, BadRequest<IReadOnlyCollection<Notification>>> Buy(
            ProductContext dbContext, 
            PurchaseRequest purchaseRequest)
        {
            var transaction = purchaseRequest.MapTo();

            if (purchaseRequest.IsValid)
            {
                dbContext.Transactions.Add(transaction);
                dbContext.SaveChanges();

                return TypedResults.Created();
            }

            return TypedResults.BadRequest(purchaseRequest.Notifications);
        }
    }
}