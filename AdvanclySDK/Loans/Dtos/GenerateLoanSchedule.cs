using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class GenerateLoanScheduleRequest
{
    [JsonPropertyName("productId")] public int ProductId { get; set; }
    [JsonPropertyName("loanTenor")] public int LoanTenor { get; set; }
    [JsonPropertyName("principalAmount")] public decimal PrincipalAmount { get; set; }
    [JsonPropertyName("interest")] public decimal Interest { get; set; }
    [JsonPropertyName("loanEffectiveDate")] public string LoanEffectiveDate { get; set; }
}