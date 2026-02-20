using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for creating a virtual account for a corporate entity.
/// POST /api/v2/client/wallet/corporate/create
/// </summary>
public class CreateCorporateAccountRequest
{
    /// <summary>
    /// The CAC registration number (RC Number) of the company.
    /// </summary>
    [JsonPropertyName("rc_number")] public string RcNumber { get; set; }

    /// <summary>
    /// The registered business name of the company.
    /// </summary>
    [JsonPropertyName("business_name")] public string BusinessName { get; set; }

    /// <summary>
    /// The date the company was incorporated in yyyy-MM-dd format.
    /// </summary>
    [JsonPropertyName("incorporation_date")] public string IncorporationDate { get; set; }

    /// <summary>
    /// The registered business address of the company.
    /// </summary>
    [JsonPropertyName("address")] public string Address { get; set; }

    /// <summary>
    /// The phone number associated with the business.
    /// </summary>
    [JsonPropertyName("phone")] public string Phone { get; set; }

    /// <summary>
    /// The email address associated with the business.
    /// </summary>
    [JsonPropertyName("email")] public string Email { get; set; }

    /// <summary>
    /// The Bank Verification Number (BVN) of the business director or signatory.
    /// </summary>
    [JsonPropertyName("bvn")] public string Bvn { get; set; }
}
