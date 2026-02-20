using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving a list of supported financial institutions.
/// GET /api/v2/client/wallet/financial_institutions
/// </summary>
public class FinancialInstitutionsResponse
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
    /// The list of supported financial institutions.
    /// </summary>
    [JsonPropertyName("data")] public List<FinancialInstitution> Data { get; set; }
}

/// <summary>
/// Represents a single supported financial institution (bank).
/// </summary>
public class FinancialInstitution
{
    /// <summary>
    /// The unique bank code identifying the financial institution.
    /// </summary>
    [JsonPropertyName("bank_code")] public string BankCode { get; set; }

    /// <summary>
    /// The name of the financial institution.
    /// </summary>
    [JsonPropertyName("bank_name")] public string BankName { get; set; }

    /// <summary>
    /// The URL of the bank's logo in PNG format.
    /// </summary>
    [JsonPropertyName("png_logo_url")] public string PngLogoUrl { get; set; }

    /// <summary>
    /// The URL of the bank's logo in SVG format.
    /// </summary>
    [JsonPropertyName("svg_logo_url")] public string SvgLogoUrl { get; set; }
}
