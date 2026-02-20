using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for onboarding an individual customer (investor or borrower).
/// POST /api/v2/client/customers/onboard_individual
/// </summary>
public class OnboardIndividualCustomerRequest
{
    /// <summary>
    /// The first name of the individual customer.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the individual customer.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// The email address of the individual customer.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The phone number of the individual customer.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The Bank Verification Number (BVN) of the customer.
    /// </summary>
    [JsonPropertyName("bvn")]
    public string Bvn { get; set; }

    /// <summary>
    /// The unique valid identification number used for KYC verification.
    /// </summary>
    [JsonPropertyName("identity_number")]
    public string IdentityNumber { get; set; }

    /// <summary>
    /// The ISO country code of the customer, e.g. "NG", "GH", "SA".
    /// </summary>
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }

    /// <summary>
    /// The gender of the customer (male or female).
    /// </summary>
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    /// <summary>
    /// The date of birth of the customer in yyyy-MM-dd format.
    /// </summary>
    [JsonPropertyName("date_of_birth")]
    public string DateOfBirth { get; set; }

    /// <summary>
    /// The residential address of the customer.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    /// The type of customer being onboarded (e.g. borrower or investor).
    /// </summary>
    [JsonPropertyName("customer_type")]
    public string CustomerType { get; set; }
}

/// <summary>
/// Response model returned after successfully onboarding an individual customer.
/// </summary>
public class OnboardIndividualCustomerResponse
{
    /// <summary>
    /// The unique identifier assigned to the newly created borrower.
    /// </summary>
    [JsonPropertyName("borrower_id")]
    public int BorrowerId { get; set; }

    /// <summary>
    /// The first name of the individual customer.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the individual customer.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// The company name (empty for individual customers).
    /// </summary>
    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    /// <summary>
    /// The phone number of the borrower.
    /// </summary>
    [JsonPropertyName("borrower_phone")]
    public string BorrowerPhone { get; set; }

    /// <summary>
    /// The SSO (Single Sign-On) user ID assigned to the customer.
    /// </summary>
    [JsonPropertyName("sso_user_id")]
    public string SsoUserId { get; set; }

    /// <summary>
    /// The Bank Verification Number (BVN) of the customer.
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
