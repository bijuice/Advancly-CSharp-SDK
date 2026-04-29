using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for creating a dynamic virtual account.
/// POST /api/v2/client/wallet/dynamic/generate
/// </summary>
public class CreateDynamicAccountRequest
{
    /// <summary>
    /// The name to be registered on the dynamic account.
    /// </summary>
    [JsonPropertyName("account_name")] public string Account_Name { get; set; }

    /// <summary>
    /// A unique transaction reference for this dynamic account request.
    /// </summary>
    [JsonPropertyName("transaction_ref")] public string Transaction_Ref { get; set; }

    /// <summary>
    /// The transaction amount for which the dynamic account is being created.
    /// </summary>
    [JsonPropertyName("transaction_amount")] public decimal Transaction_Amount { get; set; }

    /// <summary>
    /// The duration (in days) for which the dynamic account should remain active.
    /// </summary>
    [JsonPropertyName("duration")] public int Duration { get; set; }
}

/// <summary>
/// Response model for creating a dynamic virtual account.
/// </summary>
public class CreateDynamicAccountResponse
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
    /// The dynamic account details data payload.
    /// </summary>
    [JsonPropertyName("data")] public CreateDynamicAccountData Data { get; set; }
}

/// <summary>
/// Data payload containing the created dynamic account information.
/// </summary>
public class CreateDynamicAccountData
{
    /// <summary>
    /// The name registered on the dynamic account.
    /// </summary>
    [JsonPropertyName("account_name")] public string Account_Name { get; set; }

    /// <summary>
    /// The dynamically generated account number.
    /// </summary>
    [JsonPropertyName("account_number")] public string Account_Number { get; set; }

    /// <summary>
    /// The duration (in days) for which the dynamic account is active.
    /// </summary>
    [JsonPropertyName("duration")] public int Duration { get; set; }

    /// <summary>
    /// The expiration date and time of the dynamic account in ISO 8601 format.
    /// </summary>
    [JsonPropertyName("expiry_datetime")] public string Expiry_DateTime { get; set; }
}
