using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving all available loan sectors.
/// GET /api/v1/misc/sectors
/// </summary>
public class GetSectorsResponse
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
    /// The list of available sectors.
    /// </summary>
    [JsonPropertyName("data")] public List<SectorData> Data { get; set; }
}

/// <summary>
/// Represents a single sector category.
/// </summary>
public class SectorData
{
    /// <summary>
    /// The unique identifier of the sector category.
    /// </summary>
    [JsonPropertyName("category_id")] public int CategoryId { get; set; }

    /// <summary>
    /// The name of the sector category.
    /// </summary>
    [JsonPropertyName("category_name")] public string CategoryName { get; set; }

    /// <summary>
    /// The URL-friendly slug for the sector category.
    /// </summary>
    [JsonPropertyName("category_slug")] public string CategorySlug { get; set; }

    /// <summary>
    /// The sector code used when submitting a loan application.
    /// </summary>
    [JsonPropertyName("code")] public string Code { get; set; }
}
