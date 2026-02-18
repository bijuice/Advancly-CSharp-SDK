using System.Text.Json.Serialization;

public class GetTransactionResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public TransactionData Data { get; set; }
}

public class TransactionData
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("externalReferenceNumber")] public string ExternalReferenceNumber { get; set; }
    [JsonPropertyName("sessionId")] public string SessionId { get; set; }
    [JsonPropertyName("senderAccountName")] public string SenderAccountName { get; set; }
    [JsonPropertyName("senderAccountNumber")] public string SenderAccountNumber { get; set; }
    [JsonPropertyName("senderBankCode")] public string SenderBankCode { get; set; }
    [JsonPropertyName("senderBankName")] public string SenderBankName { get; set; }
    [JsonPropertyName("recipientAccountName")] public string RecipientAccountName { get; set; }
    [JsonPropertyName("recipientAccountNumber")] public string RecipientAccountNumber { get; set; }
    [JsonPropertyName("recipientBankCode")] public string RecipientBankCode { get; set; }
    [JsonPropertyName("recipientBankName")] public string RecipientBankName { get; set; }
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
    [JsonPropertyName("feeCharge")] public decimal FeeCharge { get; set; }
    [JsonPropertyName("narration")] public string Narration { get; set; }
    [JsonPropertyName("transactionStatus")] public string TransactionStatus { get; set; } // Completed, Failed, Processing
    [JsonPropertyName("transactionType")] public string TransactionType { get; set; }
    [JsonPropertyName("responseCode")] public string ResponseCode { get; set; }
    [JsonPropertyName("responseMessage")] public string ResponseMessage { get; set; }
    [JsonPropertyName("channelCode")] public int ChannelCode { get; set; }
    [JsonPropertyName("transactionDate")] public string TransactionDate { get; set; }
    [JsonPropertyName("createdDateTime")] public string CreatedDateTime { get; set; }
}
