using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for generating a loan repayment schedule.
/// POST /api/v2/client/loans/generate_loan_schedule
/// </summary>
public class GenerateLoanScheduleRequest
{
    /// <summary>
    /// The ID of the loan product.
    /// </summary>
    [JsonPropertyName("productId")] public int ProductId { get; set; }

    /// <summary>
    /// The tenor/duration of the loan in months.
    /// </summary>
    [JsonPropertyName("loanTenor")] public int LoanTenor { get; set; }

    /// <summary>
    /// The principal amount of the loan.
    /// </summary>
    [JsonPropertyName("principalAmount")] public decimal PrincipalAmount { get; set; }

    /// <summary>
    /// The interest rate for the loan.
    /// </summary>
    [JsonPropertyName("interest")] public decimal Interest { get; set; }

    /// <summary>
    /// The effective start date of the loan in yyyy-MM-dd format.
    /// </summary>
    [JsonPropertyName("loanEffectiveDate")] public string LoanEffectiveDate { get; set; }
}