using System.ComponentModel.DataAnnotations;

namespace Stone.StarstoreAPI.Models
{
    public record Transaction(
        [property: Key] Guid PurchaseId,
        Guid ClientId,
        decimal? Value,
        string? Date,
        string? CardNumber);
}
