using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class RequestLoanRequest
{
    [JsonPropertyName("identity_number")] public string IdentityNumber { get; set; }
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
    [JsonPropertyName("product_id")] public int ProductId { get; set; }
    [JsonPropertyName("loan_amount")] public int LoanAmount { get; set; }
    [JsonPropertyName("loan_tenure")] public int LoanTenure { get; set; }
    [JsonPropertyName("annual_interest_rate")] public string AnnualInterestRate { get; set; }
    [JsonPropertyName("loan_purpose")] public string LoanPurpose { get; set; }
    [JsonPropertyName("use_customer_wallet")] public bool UseCustomerWallet { get; set; }
}