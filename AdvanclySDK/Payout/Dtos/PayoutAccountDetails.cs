using System.Text.Json.Serialization;

public class PayoutAccountDetailsResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<PayoutAccountData> Data { get; set; }
}

public class PayoutAccountData
{
    [JsonPropertyName("walletProviderId")] public int WalletProviderId { get; set; }
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }
    [JsonPropertyName("accountName")] public string AccountName { get; set; }
    [JsonPropertyName("globalAccountNumber")] public string GlobalAccountNumber { get; set; }
    [JsonPropertyName("clientId")] public int ClientId { get; set; }
    [JsonPropertyName("accountBalance")] public decimal AccountBalance { get; set; }
    [JsonPropertyName("availableBalance")] public decimal AvailableBalance { get; set; }
    [JsonPropertyName("isPrimaryAccount")] public bool IsPrimaryAccount { get; set; }
    [JsonPropertyName("currencyCode")] public string CurrencyCode { get; set; }
}
