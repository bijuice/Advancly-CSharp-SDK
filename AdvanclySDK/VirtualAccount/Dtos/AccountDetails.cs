using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving virtual account details.
/// GET /api/v2/client/wallet?account_number={account_number}
/// </summary>
public class AccountDetailsResponse
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
    /// The list of virtual account details data payloads.
    /// </summary>
    [JsonPropertyName("data")] public List<AccountDetailsData> Data { get; set; }
}

/// <summary>
/// Data payload containing virtual account balance and identification details.
/// </summary>
public class AccountDetailsData
{
    /// <summary>
    /// The name registered on the virtual account.
    /// </summary>
    [JsonPropertyName("accountName")] public string AccountName { get; set; }

    /// <summary>
    /// The virtual account number.
    /// </summary>
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }

    /// <summary>
    /// The global account number linked to this virtual account.
    /// </summary>
    [JsonPropertyName("globalAccountNumber")] public string GlobalAccountNumber { get; set; }

    /// <summary>
    /// The current ledger balance of the account.
    /// </summary>
    [JsonPropertyName("accountBalance")] public decimal AccountBalance { get; set; }

    /// <summary>
    /// The available balance that can be withdrawn or transferred.
    /// </summary>
    [JsonPropertyName("availableBalance")] public decimal AvailableBalance { get; set; }
}
