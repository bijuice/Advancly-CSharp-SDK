using System.Text.Json.Serialization;

public class GetAggregatorProductsResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<AggregatorProduct> Data { get; set; }
}

public class AggregatorProduct
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("product_code")] public string ProductCode { get; set; }
    [JsonPropertyName("product_name")] public string ProductName { get; set; }
    [JsonPropertyName("maximum_amount")] public decimal MaximumAmount { get; set; }
    [JsonPropertyName("pub_date")] public string PubDate { get; set; }
    [JsonPropertyName("modified_date")] public string ModifiedDate { get; set; }
    [JsonPropertyName("productCategoryName")] public string ProductCategoryName { get; set; }
    [JsonPropertyName("interest_rate")] public decimal InterestRate { get; set; }
    [JsonPropertyName("maximum_tenor")] public int MaximumTenor { get; set; }
    [JsonPropertyName("aggregator_id")] public int AggregatorId { get; set; }
    [JsonPropertyName("product_category_id")] public int ProductCategoryId { get; set; }
}
