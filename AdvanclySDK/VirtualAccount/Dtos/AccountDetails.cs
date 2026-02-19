using System.Text.Json.Serialization;

public class AccountDetailsResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public AccountDetailsData Data { get; set; }
}

public class AccountDetailsData
{
    [JsonPropertyName("accountName")] public string AccountName { get; set; }
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }
    [JsonPropertyName("globalAccountNumber")] public string GlobalAccountNumber { get; set; }
    [JsonPropertyName("accountBalance")] public decimal AccountBalance { get; set; }
    [JsonPropertyName("availableBalance")] public decimal AvailableBalance { get; set; }
}
