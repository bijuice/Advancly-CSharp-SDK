using System.Text.Json.Serialization;

public class GetCountryBankListResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<BankData> Data { get; set; }
}

public class BankData
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("slug")] public string Slug { get; set; }
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("longcode")] public string LongCode { get; set; }
    [JsonPropertyName("vigipay_bank_id")] public string VigipayBankId { get; set; }
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}
