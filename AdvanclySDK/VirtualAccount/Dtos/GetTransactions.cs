using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class GetTransactionsRequest
{
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }
    [JsonPropertyName("start_date")] public string StartDate { get; set; }
    [JsonPropertyName("end_date")] public string EndDate { get; set; }
    [JsonPropertyName("page")] public int Page { get; set; } = 1;
    [JsonPropertyName("page_size")] public int PageSize { get; set; } = 10;
}

public class GetTransactionsResponse
{
    [JsonPropertyName("page")] public int Page { get; set; }
    [JsonPropertyName("pageSize")] public int PageSize { get; set; }
    [JsonPropertyName("totalCount")] public int TotalCount { get; set; }
    [JsonPropertyName("totalPages")] public int TotalPages { get; set; }
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<WalletTransaction> Data { get; set; }
}

public class WalletTransaction
{
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }
    [JsonPropertyName("transactionAmount")] public decimal TransactionAmount { get; set; }
    [JsonPropertyName("balance")] public decimal Balance { get; set; }
    [JsonPropertyName("transactionDate")] public string TransactionDate { get; set; }
    [JsonPropertyName("createdDate")] public string CreatedDate { get; set; }
    [JsonPropertyName("transactionType")] public string TransactionType { get; set; }
    [JsonPropertyName("narration")] public string Narration { get; set; }
    [JsonPropertyName("clientId")] public int ClientId { get; set; }
    [JsonPropertyName("currencyCode")] public string CurrencyCode { get; set; }
    [JsonPropertyName("senderDetails")] public WalletPartyDetails SenderDetails { get; set; }
    [JsonPropertyName("receiverDetails")] public WalletPartyDetails ReceiverDetails { get; set; }
    [JsonPropertyName("sessionId")] public string SessionId { get; set; }
}

public class WalletPartyDetails
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("bankName")] public string BankName { get; set; }
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }
}
