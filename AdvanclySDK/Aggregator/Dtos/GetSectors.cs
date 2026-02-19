using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class GetSectorsResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<SectorData> Data { get; set; }
}

public class SectorData
{
    [JsonPropertyName("category_id")] public int CategoryId { get; set; }
    [JsonPropertyName("category_name")] public string CategoryName { get; set; }
    [JsonPropertyName("category_slug")] public string CategorySlug { get; set; }
    [JsonPropertyName("code")] public string Code { get; set; }
}
