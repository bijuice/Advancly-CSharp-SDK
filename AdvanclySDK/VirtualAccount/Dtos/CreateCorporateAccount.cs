using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class CreateCorporateAccountRequest
{
    [JsonPropertyName("rc_number")] public string RcNumber { get; set; }
    [JsonPropertyName("business_name")] public string BusinessName { get; set; }
    [JsonPropertyName("incorporation_date")] public string IncorporationDate { get; set; }
    [JsonPropertyName("address")] public string Address { get; set; }
    [JsonPropertyName("phone")] public string Phone { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonPropertyName("bvn")] public string Bvn { get; set; }
}
