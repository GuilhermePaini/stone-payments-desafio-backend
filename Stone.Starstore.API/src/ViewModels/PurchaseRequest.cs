using System.Text.Json.Serialization;
using Flunt.Notifications;
using Flunt.Validations;
using Stone.StarstoreAPI.DTO;
using Stone.StarstoreAPI.Models;

namespace Stone.StarstoreAPI.ViewModels;

public class PurchaseRequest : Notifiable<Notification>
{
    [JsonPropertyName("client_id")]
    public Guid ClientId { get; set; }

    [JsonPropertyName("client_name")]
    public string? ClientName { get; set; }

    [JsonPropertyName("total_to_pay")]
    public decimal TotalToPay { get; set; }

    [JsonPropertyName("credit_card")]
    public CreditCard? CreditCard { get; set; }

    public Transaction MapTo()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(ClientId, "ClientId is required")
            .IsNotNullOrEmpty(ClientName, "ClientName is required")
            .IsGreaterOrEqualsThan(TotalToPay, decimal.Zero, "TotalToPay must be greather or equals than zero")
            .IsNotNull(CreditCard, "Credit card info is required");
        
        AddNotifications(contract);

        return new Transaction(
            Guid.NewGuid(),
            ClientId,
            TotalToPay,
            DateTime.UtcNow.ToString("dd/MM/yyyy"),
            CreditCard?.CardNumber);
    }
/*
{
   "client_id":"7e655c6e-e8e5-4349-8348-e51e0ff3072e",
   "client_name":"Luke Skywalker",
   "total_to_pay":1236,
   "credit_card":{
      "card_number":"1234123412341234",
      "value":7990,
      "cvv":789,
      "card_holder_name":"Luke Skywalker",
      "exp_date":"12/24"
   }
}*/
}
