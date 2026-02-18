using System.Text.Json.Serialization;

public class TransferRequest
{
    [JsonPropertyName("sender_account_number")] public string SenderAccountNumber { get; set; }
    [JsonPropertyName("recipient_account_number")] public string RecipientAccountNumber { get; set; }
    [JsonPropertyName("recipient_account_name")] public string RecipientAccountName { get; set; }
    [JsonPropertyName("recipient_bank_code")] public string RecipientBankCode { get; set; }
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
    [JsonPropertyName("narration")] public string Narration { get; set; }
    [JsonPropertyName("reference")] public string Reference { get; set; }
}

public class TransferResponse
{
    [JsonPropertyName("response_code")] public string ResponseCode { get; set; }
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public TransferData Data { get; set; }
}

public class TransferData
{
    [JsonPropertyName("currency")] public string Currency { get; set; }
    [JsonPropertyName("sender_account_name")] public string SenderAccountName { get; set; }
    [JsonPropertyName("sender_account_number")] public string SenderAccountNumber { get; set; }
    [JsonPropertyName("sender_bank_code")] public string SenderBankCode { get; set; }
    [JsonPropertyName("sender_bank_name")] public string SenderBankName { get; set; }
    [JsonPropertyName("recipient_account_name")] public string RecipientAccountName { get; set; }
    [JsonPropertyName("recipient_account_number")] public string RecipientAccountNumber { get; set; }
    [JsonPropertyName("recipient_bank_code")] public string RecipientBankCode { get; set; }
    [JsonPropertyName("recipient_bank_name")] public string RecipientBankName { get; set; }
    [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }
    [JsonPropertyName("transaction_reference")] public string TransactionReference { get; set; }
    [JsonPropertyName("session_id")] public string SessionId { get; set; }
    [JsonPropertyName("narration")] public string Narration { get; set; }
    [JsonPropertyName("transaction_status")] public string TransactionStatus { get; set; }
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
    [JsonPropertyName("transaction_charge")] public decimal TransactionCharge { get; set; }
    [JsonPropertyName("transaction_message")] public string TransactionMessage { get; set; }
    [JsonPropertyName("transaction_date")] public string TransactionDate { get; set; }
}
