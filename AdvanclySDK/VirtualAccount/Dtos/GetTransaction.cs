using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving a single transaction by reference (TSQ).
/// GET /api/v2/client/wallet/transaction/{transactionReference}
/// </summary>
public class GetTransactionResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The transaction details data payload.
    /// </summary>
    [JsonPropertyName("data")] public TransactionData Data { get; set; }
}

/// <summary>
/// Detailed data for a single virtual account transaction.
/// </summary>
public class TransactionData
{
    /// <summary>
    /// The internal unique identifier of the transaction.
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// The external reference number provided by the client when initiating the transfer.
    /// </summary>
    [JsonPropertyName("externalReferenceNumber")] public string ExternalReferenceNumber { get; set; }

    /// <summary>
    /// The NIP session ID for the interbank transaction.
    /// </summary>
    [JsonPropertyName("sessionId")] public string SessionId { get; set; }

    /// <summary>
    /// The account name of the sender.
    /// </summary>
    [JsonPropertyName("senderAccountName")] public string SenderAccountName { get; set; }

    /// <summary>
    /// The account number of the sender.
    /// </summary>
    [JsonPropertyName("senderAccountNumber")] public string SenderAccountNumber { get; set; }

    /// <summary>
    /// The bank code of the sender's bank.
    /// </summary>
    [JsonPropertyName("senderBankCode")] public string SenderBankCode { get; set; }

    /// <summary>
    /// The name of the sender's bank.
    /// </summary>
    [JsonPropertyName("senderBankName")] public string SenderBankName { get; set; }

    /// <summary>
    /// The account name of the recipient.
    /// </summary>
    [JsonPropertyName("recipientAccountName")] public string RecipientAccountName { get; set; }

    /// <summary>
    /// The account number of the recipient.
    /// </summary>
    [JsonPropertyName("recipientAccountNumber")] public string RecipientAccountNumber { get; set; }

    /// <summary>
    /// The bank code of the recipient's bank.
    /// </summary>
    [JsonPropertyName("recipientBankCode")] public string RecipientBankCode { get; set; }

    /// <summary>
    /// The name of the recipient's bank.
    /// </summary>
    [JsonPropertyName("recipientBankName")] public string RecipientBankName { get; set; }

    /// <summary>
    /// The transaction amount.
    /// </summary>
    [JsonPropertyName("amount")] public decimal Amount { get; set; }

    /// <summary>
    /// The fee charged for processing the transaction.
    /// </summary>
    [JsonPropertyName("feeCharge")] public decimal FeeCharge { get; set; }

    /// <summary>
    /// The narration or description of the transaction.
    /// </summary>
    [JsonPropertyName("narration")] public string Narration { get; set; }

    /// <summary>
    /// The status of the transaction. Possible values: Completed, Failed, Processing.
    /// </summary>
    [JsonPropertyName("transactionStatus")] public string TransactionStatus { get; set; }

    /// <summary>
    /// The type of transaction (e.g. debit, credit).
    /// </summary>
    [JsonPropertyName("transactionType")] public string TransactionType { get; set; }

    /// <summary>
    /// The response code returned by the payment processor.
    /// </summary>
    [JsonPropertyName("responseCode")] public string ResponseCode { get; set; }

    /// <summary>
    /// The response message returned by the payment processor.
    /// </summary>
    [JsonPropertyName("responseMessage")] public string ResponseMessage { get; set; }

    /// <summary>
    /// The channel code used to process the transaction.
    /// </summary>
    [JsonPropertyName("channelCode")] public int ChannelCode { get; set; }

    /// <summary>
    /// The date and time the transaction was processed.
    /// </summary>
    [JsonPropertyName("transactionDate")] public string TransactionDate { get; set; }

    /// <summary>
    /// The date and time the transaction record was created.
    /// </summary>
    [JsonPropertyName("createdDateTime")] public string CreatedDateTime { get; set; }
}
