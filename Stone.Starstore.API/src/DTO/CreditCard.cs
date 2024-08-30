using System.Text.Json.Serialization;

namespace Stone.StarstoreAPI.DTO
{
    public record CreditCard(
        [property: JsonPropertyName("card_number")] 
        string? CardNumber,
        [property: JsonPropertyName("value")] 
        decimal Value,
        [property: JsonPropertyName("cvv")] 
        int Cvv,
        [property: JsonPropertyName("card_holder_name")] 
        string? CardHolderName,
        [property: JsonPropertyName("exp_date")] 
        string? ExpirationDate);

        /*
        
            "credit_card":{
            "card_number":"1234123412341234",
            "value":7990,
            "cvv":789,
            "card_holder_name":"Luke Skywalker",
            "exp_date":"12/24"
        }*/
}