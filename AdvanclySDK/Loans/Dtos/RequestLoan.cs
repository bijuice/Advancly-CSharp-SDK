using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for requesting a loan for an existing borrower.
/// POST /api/v2/client/loans/request_loan
/// </summary>
public class RequestLoanRequest
{
    /// <summary>
    /// The unique identification number of the borrower used for KYC.
    /// </summary>
    [JsonPropertyName("identity_number")] public string IdentityNumber { get; set; }

    /// <summary>
    /// The ISO country code of the borrower, e.g. "NG" (Nigeria), "GH" (Ghana), "SA" (South Africa).
    /// </summary>
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }

    /// <summary>
    /// The ID of the loan product being requested. See Get Aggregator Products endpoint.
    /// </summary>
    [JsonPropertyName("product_id")] public int ProductId { get; set; }

    /// <summary>
    /// The loan amount being requested.
    /// </summary>
    [JsonPropertyName("loan_amount")] public int LoanAmount { get; set; }

    /// <summary>
    /// The loan duration in months.
    /// </summary>
    [JsonPropertyName("loan_tenure")] public int LoanTenure { get; set; }

    /// <summary>
    /// The annual interest rate for the loan. If zero, the loan product's interest rate will be used.
    /// </summary>
    [JsonPropertyName("annual_interest_rate")] public string AnnualInterestRate { get; set; }

    /// <summary>
    /// The purpose for which the loan is requested.
    /// </summary>
    [JsonPropertyName("loan_purpose")] public string LoanPurpose { get; set; }

    /// <summary>
    /// Indicates whether the customer's wallet should be used for disbursement.
    /// </summary>
    [JsonPropertyName("use_customer_wallet")] public bool UseCustomerWallet { get; set; }
}