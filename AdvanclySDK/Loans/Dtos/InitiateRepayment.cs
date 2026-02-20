using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for initiating a loan repayment.
/// POST /api/v2/client/loans/initiate_repayment
/// </summary>
public class InitiateRepaymentRequest
{
    /// <summary>
    /// The unique reference number of the loan to repay.
    /// </summary>
    [JsonPropertyName("loan_ref_no")] public string LoanRefNo { get; set; }

    /// <summary>
    /// The repayment amount.
    /// </summary>
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
}

/// <summary>
/// Response model returned after initiating a loan repayment.
/// </summary>
public class RepaymentResponse
{
    /// <summary>
    /// Indicates whether the repayment initiation was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// A descriptive message about the repayment initiation result.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// The repayment data returned from the API.
    /// </summary>
    [JsonPropertyName("data")] public RepaymentData Data { get; set; }
}

/// <summary>
/// Data payload returned after initiating a loan repayment.
/// </summary>
public class RepaymentData
{
    /// <summary>
    /// The loan reference number.
    /// </summary>
    [JsonPropertyName("loanRef")] public string LoanRef { get; set; }

    /// <summary>
    /// The account number associated with the repayment.
    /// </summary>
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }

    /// <summary>
    /// The bank associated with the repayment account.
    /// </summary>
    [JsonPropertyName("bank")] public string Bank { get; set; }

    /// <summary>
    /// The repayment amount.
    /// </summary>
    [JsonPropertyName("amount")] public decimal Amount { get; set; }

    /// <summary>
    /// The repayment status code. 1 = Pending, 2 = Success.
    /// </summary>
    [JsonPropertyName("repaymentStatus")] public int RepaymentStatus { get; set; }
}