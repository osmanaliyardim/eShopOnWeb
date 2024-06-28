using System.Text.Json.Serialization;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

public record OrderedItems<T>
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("finalPrice")]
    public decimal finalPrice { get; set; }

    [JsonPropertyName("body")]
    public T Body { get; init; }

    public OrderedItems(string id, T body)
    {
        Id = id;
        Body = body;
    }
}
