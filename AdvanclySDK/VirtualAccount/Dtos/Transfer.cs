using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for initiating a funds transfer from a virtual account.
/// POST /api/v2/client/wallet/transfer
/// </summary>
public class TransferRequest
{
    /// <summary>
    /// The virtual account number to debit (sender).
    /// </summary>
    [JsonPropertyName("sender_account_number")] public string SenderAccountNumber { get; set; }

    /// <summary>
    /// The account number to credit (recipient).
    /// </summary>
    [JsonPropertyName("recipient_account_number")] public string RecipientAccountNumber { get; set; }

    /// <summary>
    /// The account name of the recipient, as returned by a name enquiry.
    /// </summary>
    [JsonPropertyName("recipient_account_name")] public string RecipientAccountName { get; set; }

    /// <summary>
    /// The bank code of the recipient's financial institution. See Get Financial Institutions endpoint.
    /// </summary>
    [JsonPropertyName("recipient_bank_code")] public string RecipientBankCode { get; set; }

    /// <summary>
    /// The amount to transfer.
    /// </summary>
    [JsonPropertyName("amount")] public decimal Amount { get; set; }

    /// <summary>
    /// A description or note for the transfer.
    /// </summary>
    [JsonPropertyName("narration")] public string Narration { get; set; }

    /// <summary>
    /// A unique client-generated reference for the transaction. Used for idempotency and TSQ.
    /// </summary>
    [JsonPropertyName("reference")] public string Reference { get; set; }
}

/// <summary>
/// Response model returned after initiating a transfer.
/// </summary>
public class TransferResponse
{
    /// <summary>
    /// The response code from the payment processor (e.g. "00" for success).
    /// </summary>
    [JsonPropertyName("response_code")] public string ResponseCode { get; set; }

    /// <summary>
    /// A descriptive message about the transfer result.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the transfer request was accepted successfully.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The transfer transaction data payload.
    /// </summary>
    [JsonPropertyName("data")] public TransferData Data { get; set; }
}

/// <summary>
/// Data payload containing the details of a completed transfer transaction.
/// </summary>
public class TransferData
{
    /// <summary>
    /// The currency of the transaction, e.g. "NGN".
    /// </summary>
    [JsonPropertyName("currency")] public string Currency { get; set; }

    /// <summary>
    /// The account name of the sender.
    /// </summary>
    [JsonPropertyName("sender_account_name")] public string SenderAccountName { get; set; }

    /// <summary>
    /// The account number of the sender.
    /// </summary>
    [JsonPropertyName("sender_account_number")] public string SenderAccountNumber { get; set; }

    /// <summary>
    /// The bank code of the sender's financial institution.
    /// </summary>
    [JsonPropertyName("sender_bank_code")] public string SenderBankCode { get; set; }

    /// <summary>
    /// The name of the sender's bank.
    /// </summary>
    [JsonPropertyName("sender_bank_name")] public string SenderBankName { get; set; }

    /// <summary>
    /// The account name of the recipient.
    /// </summary>
    [JsonPropertyName("recipient_account_name")] public string RecipientAccountName { get; set; }

    /// <summary>
    /// The account number of the recipient.
    /// </summary>
    [JsonPropertyName("recipient_account_number")] public string RecipientAccountNumber { get; set; }

    /// <summary>
    /// The bank code of the recipient's financial institution.
    /// </summary>
    [JsonPropertyName("recipient_bank_code")] public string RecipientBankCode { get; set; }

    /// <summary>
    /// The name of the recipient's bank.
    /// </summary>
    [JsonPropertyName("recipient_bank_name")] public string RecipientBankName { get; set; }

    /// <summary>
    /// The internal transaction ID assigned by the system.
    /// </summary>
    [JsonPropertyName("transaction_id")] public string TransactionId { get; set; }

    /// <summary>
    /// The client-provided reference number echoed back in the response.
    /// </summary>
    [JsonPropertyName("transaction_reference")] public string TransactionReference { get; set; }

    /// <summary>
    /// The NIP session ID for the interbank transaction.
    /// </summary>
    [JsonPropertyName("session_id")] public string SessionId { get; set; }

    /// <summary>
    /// The narration or description of the transfer.
    /// </summary>
    [JsonPropertyName("narration")] public string Narration { get; set; }

    /// <summary>
    /// The status of the transaction (e.g. "Success", "Failed", "Pending").
    /// </summary>
    [JsonPropertyName("transaction_status")] public string TransactionStatus { get; set; }

    /// <summary>
    /// The amount that was transferred.
    /// </summary>
    [JsonPropertyName("amount")] public decimal Amount { get; set; }

    /// <summary>
    /// The fee charged for processing the transfer.
    /// </summary>
    [JsonPropertyName("transaction_charge")] public decimal TransactionCharge { get; set; }

    /// <summary>
    /// A human-readable message describing the transaction outcome.
    /// </summary>
    [JsonPropertyName("transaction_message")] public string TransactionMessage { get; set; }

    /// <summary>
    /// The date and time the transaction was processed.
    /// </summary>
    [JsonPropertyName("transaction_date")] public string TransactionDate { get; set; }
}
