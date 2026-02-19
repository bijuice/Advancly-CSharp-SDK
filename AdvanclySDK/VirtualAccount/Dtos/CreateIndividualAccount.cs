using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class CreateIndividualAccountRequest
{
    [JsonPropertyName("first_name")] public string FirstName { get; set; }
    [JsonPropertyName("last_name")] public string LastName { get; set; }
    [JsonPropertyName("dob")] public string Dob { get; set; }
    [JsonPropertyName("address")] public string Address { get; set; }
    [JsonPropertyName("gender")] public string Gender { get; set; } // Male or Female
    [JsonPropertyName("phone")] public string Phone { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonPropertyName("bvn")] public string Bvn { get; set; }
}

public class CreateAccountResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public CreatedAccountData Data { get; set; }
}

public class CreatedAccountData
{
    [JsonPropertyName("account_name")] public string AccountName { get; set; }
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }
}
