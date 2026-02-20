using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Query parameters for retrieving a paged list of transactions for a virtual account.
/// GET /api/v2/client/wallet/transactions
/// </summary>
public class GetTransactionsRequest
{
    /// <summary>
    /// The virtual account number to retrieve transactions for.
    /// </summary>
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }

    /// <summary>
    /// The start of the date range filter in yyyy-MM-dd format.
    /// </summary>
    [JsonPropertyName("start_date")] public string StartDate { get; set; }

    /// <summary>
    /// The end of the date range filter in yyyy-MM-dd format.
    /// </summary>
    [JsonPropertyName("end_date")] public string EndDate { get; set; }

    /// <summary>
    /// The page number to retrieve. Defaults to 1.
    /// </summary>
    [JsonPropertyName("page")] public int Page { get; set; } = 1;

    /// <summary>
    /// The number of records per page. Defaults to 10.
    /// </summary>
    [JsonPropertyName("page_size")] public int PageSize { get; set; } = 10;
}

/// <summary>
/// Response model for a paged list of virtual account transactions.
/// </summary>
public class GetTransactionsResponse
{
    /// <summary>
    /// The current page number.
    /// </summary>
    [JsonPropertyName("page")] public int Page { get; set; }

    /// <summary>
    /// The number of records returned per page.
    /// </summary>
    [JsonPropertyName("pageSize")] public int PageSize { get; set; }

    /// <summary>
    /// The total number of transactions matching the query.
    /// </summary>
    [JsonPropertyName("totalCount")] public int TotalCount { get; set; }

    /// <summary>
    /// The total number of pages available.
    /// </summary>
    [JsonPropertyName("totalPages")] public int TotalPages { get; set; }

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
    /// The list of transactions for the current page.
    /// </summary>
    [JsonPropertyName("data")] public List<WalletTransaction> Data { get; set; }
}

/// <summary>
/// Represents a single transaction entry on a virtual account.
/// </summary>
public class WalletTransaction
{
    /// <summary>
    /// The virtual account number associated with the transaction.
    /// </summary>
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }

    /// <summary>
    /// The amount of the transaction.
    /// </summary>
    [JsonPropertyName("transactionAmount")] public decimal TransactionAmount { get; set; }

    /// <summary>
    /// The account balance after the transaction.
    /// </summary>
    [JsonPropertyName("balance")] public decimal Balance { get; set; }

    /// <summary>
    /// The date and time the transaction was processed.
    /// </summary>
    [JsonPropertyName("transactionDate")] public string TransactionDate { get; set; }

    /// <summary>
    /// The date and time the transaction record was created.
    /// </summary>
    [JsonPropertyName("createdDate")] public string CreatedDate { get; set; }

    /// <summary>
    /// The type of transaction (e.g. debit, credit).
    /// </summary>
    [JsonPropertyName("transactionType")] public string TransactionType { get; set; }

    /// <summary>
    /// The narration or description of the transaction.
    /// </summary>
    [JsonPropertyName("narration")] public string Narration { get; set; }

    /// <summary>
    /// The internal client identifier associated with this transaction.
    /// </summary>
    [JsonPropertyName("clientId")] public int ClientId { get; set; }

    /// <summary>
    /// The ISO currency code for the transaction, e.g. "NGN".
    /// </summary>
    [JsonPropertyName("currencyCode")] public string CurrencyCode { get; set; }

    /// <summary>
    /// Details about the sender of the transaction.
    /// </summary>
    [JsonPropertyName("senderDetails")] public WalletPartyDetails SenderDetails { get; set; }

    /// <summary>
    /// Details about the receiver of the transaction.
    /// </summary>
    [JsonPropertyName("receiverDetails")] public WalletPartyDetails ReceiverDetails { get; set; }

    /// <summary>
    /// The NIP session ID for the interbank transaction.
    /// </summary>
    [JsonPropertyName("sessionId")] public string SessionId { get; set; }
}

/// <summary>
/// Represents the sender or receiver party details within a wallet transaction.
/// </summary>
public class WalletPartyDetails
{
    /// <summary>
    /// The account name of the party.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; }

    /// <summary>
    /// The bank name of the party.
    /// </summary>
    [JsonPropertyName("bankName")] public string BankName { get; set; }

    /// <summary>
    /// The account number of the party.
    /// </summary>
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }
}
