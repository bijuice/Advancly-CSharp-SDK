using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving a customer's profile.
/// GET /api/v2/client/customers
/// </summary>
public class GetCustomerResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }

    /// <summary>
    /// The customer profile data.
    /// </summary>
    [JsonPropertyName("data")]
    public CustomerData Data { get; set; }
}

/// <summary>
/// Profile data for a customer returned by the Get Customer endpoint.
/// </summary>
public class CustomerData
{
    /// <summary>
    /// The unique identifier of the customer.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// The company name for corporate customers.
    /// </summary>
    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    /// <summary>
    /// The email address of the customer.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The phone number of the customer.
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
    /// The residential or business address of the customer.
    /// </summary>
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    /// The type of customer (e.g. borrower or investor).
    /// </summary>
    [JsonPropertyName("customer_type")]
    public string CustomerType { get; set; }

    /// <summary>
    /// The SSO (Single Sign-On) user ID associated with the customer.
    /// </summary>
    [JsonPropertyName("sso_user_id")]
    public string SsoUserId { get; set; }

    /// <summary>
    /// The timestamp when the customer record was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the customer record was last updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; }
}
