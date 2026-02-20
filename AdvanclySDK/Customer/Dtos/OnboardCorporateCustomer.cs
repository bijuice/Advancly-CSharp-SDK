using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for onboarding a corporate customer (investor or borrower).
/// POST /api/v2/client/customers/onboard_corporate
/// </summary>
public class OnboardCorporateCustomerRequest
{
    /// <summary>
    /// The registered name of the company.
    /// </summary>
    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    /// <summary>
    /// The email address of the corporate customer.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The phone number of the corporate customer.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The unique identification number used for KYC verification.
    /// </summary>
    [JsonPropertyName("identity_number")]
    public string IdentityNumber { get; set; }

    /// <summary>
    /// The ISO country code of the company, e.g. "NG", "GH", "SA".
    /// </summary>
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    /// <summary>
    /// The business address of the company.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    /// The type of customer being onboarded (e.g. borrower or investor).
    /// </summary>
    [JsonPropertyName("customer_type")]
    public string CustomerType { get; set; }

    /// <summary>
    /// The company's CAC registration number (RC Number).
    /// </summary>
    [JsonPropertyName("rc_number")]
    public string RcNumber { get; set; }
}

/// <summary>
/// Response model returned after successfully onboarding a corporate customer.
/// </summary>
public class OnboardCorporateCustomerResponse
{
    /// <summary>
    /// The unique identifier assigned to the newly created borrower.
    /// </summary>
    [JsonPropertyName("borrower_id")]
    public int BorrowerId { get; set; }

    /// <summary>
    /// The first name of the corporate contact (empty for corporate customers).
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the corporate contact (empty for corporate customers).
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// The registered company name.
    /// </summary>
    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    /// <summary>
    /// The phone number of the corporate borrower.
    /// </summary>
    [JsonPropertyName("borrower_phone")]
    public string BorrowerPhone { get; set; }

    /// <summary>
    /// The SSO (Single Sign-On) user ID assigned to the customer.
    /// </summary>
    [JsonPropertyName("sso_user_id")]
    public string SsoUserId { get; set; }

    /// <summary>
    /// The Bank Verification Number (BVN) of the customer (null for corporate).
    /// </summary>
    [JsonPropertyName("bvn")]
    public string Bvn { get; set; }

    /// <summary>
    /// A descriptive message about the onboarding result.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Indicates whether the onboarding was successful.
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }
}
