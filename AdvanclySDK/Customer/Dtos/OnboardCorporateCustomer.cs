using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class OnboardCorporateCustomerRequest
{
    
   
    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }
    
    [JsonPropertyName("email")]
    public string Email { get; set; }
 
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("identity_number")]
    public string IdentityNumber { get; set; }
    
    [JsonPropertyName("country_code")]
    public string CountryCode { get; set; }
    
    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("customer_type")]
    public string CustomerType { get; set; }
    
    [JsonPropertyName("rc_number")]
    public string RcNumber { get; set; }
}

public class OnboardCorporateCustomerResponse
{
    [JsonPropertyName("borrower_id")]
    public int BorrowerId { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("company_name")]
    public string CompanyName { get; set; }

    [JsonPropertyName("borrower_phone")]
    public string BorrowerPhone { get; set; }

    [JsonPropertyName("sso_user_id")]
    public string SsoUserId { get; set; }

    [JsonPropertyName("bvn")]
    public string Bvn { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }
}
