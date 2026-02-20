using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for the aggregated borrower onboarding and loan application endpoint.
/// POST /api/v1/account/loan_application
/// </summary>
public class LoanApplicationResponse
{
    /// <summary>
    /// A descriptive message about the loan application result.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the loan application was submitted successfully.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The loan application data payload.
    /// </summary>
    [JsonPropertyName("data")] public LoanApplicationData Data { get; set; }
}

/// <summary>
/// Data payload returned after a successful loan application submission.
/// </summary>
public class LoanApplicationData
{
    /// <summary>
    /// The unique identifier of the borrower.
    /// </summary>
    [JsonPropertyName("customer_id")] public int CustomerId { get; set; }

    /// <summary>
    /// The Advancly-generated loan reference number.
    /// </summary>
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }

    /// <summary>
    /// The client-generated aggregator loan reference number.
    /// </summary>
    [JsonPropertyName("aggregator_loan_ref")] public string AggregatorLoanRef { get; set; }

    /// <summary>
    /// The requested loan amount.
    /// </summary>
    [JsonPropertyName("loan_amount")] public decimal LoanAmount { get; set; }

    /// <summary>
    /// The loan duration in months.
    /// </summary>
    [JsonPropertyName("loan_tenure")] public int LoanTenure { get; set; }

    /// <summary>
    /// The current status of the loan application.
    /// </summary>
    [JsonPropertyName("loan_status")] public string LoanStatus { get; set; }

    /// <summary>
    /// The date and time the loan application was created.
    /// </summary>
    [JsonPropertyName("pub_date")] public string PubDate { get; set; }
}
