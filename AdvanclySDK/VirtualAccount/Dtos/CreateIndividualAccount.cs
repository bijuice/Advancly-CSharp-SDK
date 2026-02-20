using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for creating a virtual account for an individual.
/// POST /api/v2/client/wallet/individual/create
/// </summary>
public class CreateIndividualAccountRequest
{
    /// <summary>
    /// The first name of the individual.
    /// </summary>
    [JsonPropertyName("first_name")] public string FirstName { get; set; }

    /// <summary>
    /// The last name of the individual.
    /// </summary>
    [JsonPropertyName("last_name")] public string LastName { get; set; }

    /// <summary>
    /// The date of birth of the individual in yyyy-MM-dd format.
    /// </summary>
    [JsonPropertyName("dob")] public string Dob { get; set; }

    /// <summary>
    /// The residential address of the individual.
    /// </summary>
    [JsonPropertyName("address")] public string Address { get; set; }

    /// <summary>
    /// The gender of the individual. Must be "Male" or "Female".
    /// </summary>
    [JsonPropertyName("gender")] public string Gender { get; set; }

    /// <summary>
    /// The phone number of the individual.
    /// </summary>
    [JsonPropertyName("phone")] public string Phone { get; set; }

    /// <summary>
    /// The email address of the individual.
    /// </summary>
    [JsonPropertyName("email")] public string Email { get; set; }

    /// <summary>
    /// The Bank Verification Number (BVN) of the individual.
    /// </summary>
    [JsonPropertyName("bvn")] public string Bvn { get; set; }
}

/// <summary>
/// Response model returned after successfully creating an individual or corporate virtual account.
/// </summary>
public class CreateAccountResponse
{
    /// <summary>
    /// A descriptive message about the account creation result.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the account creation was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The newly created virtual account data.
    /// </summary>
    [JsonPropertyName("data")] public CreatedAccountData Data { get; set; }
}

/// <summary>
/// Data payload containing the newly created virtual account details.
/// </summary>
public class CreatedAccountData
{
    /// <summary>
    /// The name registered on the newly created virtual account.
    /// </summary>
    [JsonPropertyName("account_name")] public string AccountName { get; set; }

    /// <summary>
    /// The newly assigned virtual account number.
    /// </summary>
    [JsonPropertyName("account_number")] public string AccountNumber { get; set; }
}
