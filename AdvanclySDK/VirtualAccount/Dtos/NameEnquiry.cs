using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Query parameters for performing a name enquiry on a bank account.
/// GET /api/v2/client/wallet/name_enquiry
/// </summary>
public class NameEnquiryRequest
{
    /// <summary>
    /// The account number to perform name enquiry on.
    /// </summary>
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }

    /// <summary>
    /// The bank code of the account's financial institution. See Get Financial Institutions endpoint.
    /// </summary>
    [JsonPropertyName("bank_code")] public string BankCode { get; set; }
}

/// <summary>
/// Response model returned after a name enquiry.
/// </summary>
public class NameEnquiryResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the name enquiry was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The name enquiry result data.
    /// </summary>
    [JsonPropertyName("data")] public NameEnquiryData Data { get; set; }
}

/// <summary>
/// Data payload returned from a name enquiry.
/// </summary>
public class NameEnquiryData
{
    /// <summary>
    /// The account number that was queried.
    /// </summary>
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }

    /// <summary>
    /// The account name resolved for the given account number.
    /// </summary>
    [JsonPropertyName("account_name")] public string AccountName { get; set; }

    /// <summary>
    /// The KYC tier level of the account holder.
    /// </summary>
    [JsonPropertyName("kyc_tier")] public string KycTier { get; set; }
}
