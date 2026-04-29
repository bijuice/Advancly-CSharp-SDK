using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving the aggregator's payout account details.
/// GET /api/v2/client/payout/account_details
/// </summary>
public class PayoutAccountDetailsResponse
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
    [JsonPropertyName("status_code")] public int Status_Code { get; set; }

    /// <summary>
    /// The list of payout accounts associated with the aggregator.
    /// </summary>
    [JsonPropertyName("data")] public List<PayoutAccountData> Data { get; set; }
}

/// <summary>
/// Details of a single payout account belonging to the aggregator.
/// </summary>
public class PayoutAccountData
{
    /// <summary>
    /// The identifier of the wallet provider hosting this account.
    /// </summary>
    [JsonPropertyName("walletProviderId")] public int WalletProviderId { get; set; }

    /// <summary>
    /// The payout account number.
    /// </summary>
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }

    /// <summary>
    /// The name registered on the payout account.
    /// </summary>
    [JsonPropertyName("accountName")] public string AccountName { get; set; }

    /// <summary>
    /// The global account number linked to this payout account.
    /// </summary>
    [JsonPropertyName("globalAccountNumber")] public string GlobalAccountNumber { get; set; }

    /// <summary>
    /// The internal client identifier associated with this account.
    /// </summary>
    [JsonPropertyName("clientId")] public int ClientId { get; set; }

    /// <summary>
    /// The current ledger balance of the payout account.
    /// </summary>
    [JsonPropertyName("accountBalance")] public decimal AccountBalance { get; set; }

    /// <summary>
    /// The available balance that can be used for payouts.
    /// </summary>
    [JsonPropertyName("availableBalance")] public decimal AvailableBalance { get; set; }

    /// <summary>
    /// Indicates whether this is the aggregator's primary payout account.
    /// </summary>
    [JsonPropertyName("isPrimaryAccount")] public bool IsPrimaryAccount { get; set; }

    /// <summary>
    /// The ISO currency code for the account, e.g. "NGN".
    /// </summary>
    [JsonPropertyName("currencyCode")] public string CurrencyCode { get; set; }
}
