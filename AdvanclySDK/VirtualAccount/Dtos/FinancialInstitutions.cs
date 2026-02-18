using System.Text.Json.Serialization;

public class FinancialInstitutionsResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<FinancialInstitution> Data { get; set; }
}

public class FinancialInstitution
{
    [JsonPropertyName("bank_code")] public string BankCode { get; set; }
    [JsonPropertyName("bank_name")] public string BankName { get; set; }
    [JsonPropertyName("png_logo_url")] public string PngLogoUrl { get; set; }
    [JsonPropertyName("svg_logo_url")] public string SvgLogoUrl { get; set; }
}
