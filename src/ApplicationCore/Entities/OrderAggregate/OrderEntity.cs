using System.Text.Json.Serialization;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

public record OrderEntity<T>
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("body")]
    public T Body { get; init; }

    [JsonPropertyName("partitionKey")]
    public string PartitionKey { get; init; }

    public OrderEntity(string id, T body, string partitionKey)
    {
        Id = id;
        Body = body;
        PartitionKey = partitionKey;
    }
}
