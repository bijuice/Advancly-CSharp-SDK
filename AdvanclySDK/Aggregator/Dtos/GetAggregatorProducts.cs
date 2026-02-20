using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving all loan products available for an aggregator.
/// GET /api/v1/misc/query_product_by_aggregator
/// </summary>
public class GetAggregatorProductsResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The list of loan products available for the aggregator.
    /// </summary>
    [JsonPropertyName("data")] public List<AggregatorProduct> Data { get; set; }
}

/// <summary>
/// Represents a single loan product configured for an aggregator.
/// </summary>
public class AggregatorProduct
{
    /// <summary>
    /// The unique identifier of the product.
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// The short code identifying the product.
    /// </summary>
    [JsonPropertyName("product_code")] public string ProductCode { get; set; }

    /// <summary>
    /// The display name of the loan product.
    /// </summary>
    [JsonPropertyName("product_name")] public string ProductName { get; set; }

    /// <summary>
    /// The maximum loan amount allowed for this product.
    /// </summary>
    [JsonPropertyName("maximum_amount")] public decimal MaximumAmount { get; set; }

    /// <summary>
    /// The date the product was created.
    /// </summary>
    [JsonPropertyName("pub_date")] public string PubDate { get; set; }

    /// <summary>
    /// The date the product was last modified.
    /// </summary>
    [JsonPropertyName("modified_date")] public string ModifiedDate { get; set; }

    /// <summary>
    /// The name of the product's category.
    /// </summary>
    [JsonPropertyName("productCategoryName")] public string ProductCategoryName { get; set; }

    /// <summary>
    /// The interest rate applied to loans under this product.
    /// </summary>
    [JsonPropertyName("interest_rate")] public decimal InterestRate { get; set; }

    /// <summary>
    /// The maximum loan tenor (in months) allowed for this product.
    /// </summary>
    [JsonPropertyName("maximum_tenor")] public int MaximumTenor { get; set; }

    /// <summary>
    /// The unique identifier of the aggregator that owns this product.
    /// </summary>
    [JsonPropertyName("aggregator_id")] public int AggregatorId { get; set; }

    /// <summary>
    /// The identifier of the product category this product belongs to.
    /// </summary>
    [JsonPropertyName("product_category_id")] public int ProductCategoryId { get; set; }
}
