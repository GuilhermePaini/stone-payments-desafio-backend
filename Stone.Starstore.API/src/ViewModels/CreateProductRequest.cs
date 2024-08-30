using Flunt.Notifications;
using Flunt.Validations;
using Stone.StarstoreAPI.Models;

namespace Stone.StarstoreAPI.ViewModels
{
    public class CreateProductRequest : Notifiable<Notification>
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Zipcode { get; set; }
        public string? Seller { get; set; }
        public string? ThumbnailHd { get; set; }
        public string? Date { get; set; }

        public Product MapTo()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNullOrEmpty(Title, "The field 'Title' is required")
                .IsNotNull(Price, "The field 'Title' is required")
                .IsNotNullOrEmpty(Zipcode, "Zipcode");

            AddNotifications(contract);

            return new Product(Guid.NewGuid(), Title, Price, Zipcode, Seller, ThumbnailHd, Date);
        }
    }
}