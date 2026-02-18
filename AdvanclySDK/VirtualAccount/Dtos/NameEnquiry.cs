using System.Text.Json.Serialization;

public class NameEnquiryRequest
{
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }
    [JsonPropertyName("bank_code")] public string BankCode { get; set; }
}

public class NameEnquiryResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public NameEnquiryData Data { get; set; }
}

public class NameEnquiryData
{
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }
    [JsonPropertyName("account_name")] public string AccountName { get; set; }
    [JsonPropertyName("kyc_tier")] public string KycTier { get; set; }
}
