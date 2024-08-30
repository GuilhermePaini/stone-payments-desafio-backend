namespace Stone.StarstoreAPI.Models
{
    public record Product(
        Guid Id,
        string? Title,
        decimal Price,
        string? Zipcode,
        string? Seller,
        string? ThumbnailHd,
        string? Date);
}
