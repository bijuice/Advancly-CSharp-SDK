using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving all banks for a specific aggregator's country.
/// GET /api/v1/account/signed_banks_country?country_code={country_code}
/// </summary>
public class GetCountryBankListResponse
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
    /// The list of banks available for the specified country.
    /// </summary>
    [JsonPropertyName("data")] public List<BankData> Data { get; set; }
}

/// <summary>
/// Represents a single bank entry for a country.
/// </summary>
public class BankData
{
    /// <summary>
    /// The unique identifier of the bank.
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// The name of the bank.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; }

    /// <summary>
    /// The URL-friendly slug identifier for the bank.
    /// </summary>
    [JsonPropertyName("slug")] public string Slug { get; set; }

    /// <summary>
    /// The short bank code used for transfers and identification.
    /// </summary>
    [JsonPropertyName("code")] public string Code { get; set; }

    /// <summary>
    /// The full long-form bank code.
    /// </summary>
    [JsonPropertyName("longcode")] public string LongCode { get; set; }

    /// <summary>
    /// The bank's identifier within the Vigipay system.
    /// </summary>
    [JsonPropertyName("vigipay_bank_id")] public string VigipayBankId { get; set; }

    /// <summary>
    /// The ISO country code the bank belongs to.
    /// </summary>
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}
