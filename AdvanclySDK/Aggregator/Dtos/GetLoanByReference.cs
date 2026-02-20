using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Query parameters for fetching a loan by its reference number.
/// GET /api/v1/eco/agg_search_loans
/// </summary>
public class GetLoanByReferenceRequest
{
    /// <summary>
    /// The aggregator-generated loan reference number to search by.
    /// </summary>
    [JsonPropertyName("aggregator_loan_ref")] public string AggregatorLoanRef { get; set; }

    /// <summary>
    /// The Advancly-generated loan reference number to search by.
    /// </summary>
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }
}

/// <summary>
/// Response model for retrieving full loan details by reference number.
/// </summary>
public class GetLoanByReferenceResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The full loan data payload.
    /// </summary>
    [JsonPropertyName("data")] public LoanByReferenceData Data { get; set; }
}

/// <summary>
/// Comprehensive data for a loan retrieved by reference.
/// </summary>
public class LoanByReferenceData
{
    /// <summary>
    /// The Advancly-generated loan reference number.
    /// </summary>
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }

    /// <summary>
    /// The client-generated aggregator loan reference number.
    /// </summary>
    [JsonPropertyName("aggregator_loan_ref")] public string AggregatorLoanRef { get; set; }

    /// <summary>
    /// The principal loan amount.
    /// </summary>
    [JsonPropertyName("loan_amount")] public decimal LoanAmount { get; set; }

    /// <summary>
    /// The loan duration in months.
    /// </summary>
    [JsonPropertyName("loan_tenure")] public int LoanTenure { get; set; }

    /// <summary>
    /// The current status of the loan.
    /// </summary>
    [JsonPropertyName("loan_status")] public string LoanStatus { get; set; }

    /// <summary>
    /// The date and time the loan record was created.
    /// </summary>
    [JsonPropertyName("pub_date")] public string PubDate { get; set; }

    /// <summary>
    /// Details about the aggregator associated with this loan.
    /// </summary>
    [JsonPropertyName("aggregator_details")] public AggregatorDetails AggregatorDetails { get; set; }

    /// <summary>
    /// Details about the borrower associated with this loan.
    /// </summary>
    [JsonPropertyName("borrower_details")] public BorrowerDetails BorrowerDetails { get; set; }

    /// <summary>
    /// Details about the loan product under which this loan was issued.
    /// </summary>
    [JsonPropertyName("product_detail")] public ProductDetail ProductDetail { get; set; }

    /// <summary>
    /// Open Banking (Okra) details linked to this loan, if any.
    /// </summary>
    [JsonPropertyName("okra_details")] public OkraDetails OkraDetails { get; set; }

    /// <summary>
    /// The repayment schedule for this loan.
    /// </summary>
    [JsonPropertyName("repay_schedule")] public List<RepayScheduleItem> RepaySchedule { get; set; }
}

/// <summary>
/// High-level details about the aggregator associated with a loan.
/// </summary>
public class AggregatorDetails
{
    /// <summary>
    /// The unique identifier of the aggregator.
    /// </summary>
    [JsonPropertyName("aggregator_id")] public int AggregatorId { get; set; }

    /// <summary>
    /// The business name of the aggregator.
    /// </summary>
    [JsonPropertyName("aggregator_name")] public string AggregatorName { get; set; }

    /// <summary>
    /// The ISO country code of the aggregator.
    /// </summary>
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}

/// <summary>
/// Key details about the borrower associated with a loan.
/// </summary>
public class BorrowerDetails
{
    /// <summary>
    /// The unique identifier of the borrower.
    /// </summary>
    [JsonPropertyName("customer_id")] public int CustomerId { get; set; }

    /// <summary>
    /// The first name of the borrower.
    /// </summary>
    [JsonPropertyName("first_name")] public string FirstName { get; set; }

    /// <summary>
    /// The last name of the borrower.
    /// </summary>
    [JsonPropertyName("last_name")] public string LastName { get; set; }

    /// <summary>
    /// The email address of the borrower.
    /// </summary>
    [JsonPropertyName("email")] public string Email { get; set; }

    /// <summary>
    /// The phone number of the borrower.
    /// </summary>
    [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; }

    /// <summary>
    /// The Bank Verification Number (BVN) of the borrower.
    /// </summary>
    [JsonPropertyName("bvn")] public string Bvn { get; set; }
}

/// <summary>
/// Details about the loan product under which a loan was issued.
/// </summary>
public class ProductDetail
{
    /// <summary>
    /// The unique identifier of the product.
    /// </summary>
    [JsonPropertyName("product_id")] public int ProductId { get; set; }

    /// <summary>
    /// The name of the loan product.
    /// </summary>
    [JsonPropertyName("product_name")] public string ProductName { get; set; }

    /// <summary>
    /// The interest rate for this loan product.
    /// </summary>
    [JsonPropertyName("interest_rate")] public decimal InterestRate { get; set; }

    /// <summary>
    /// The maximum tenor (in months) allowed for this product.
    /// </summary>
    [JsonPropertyName("maximum_tenor")] public int MaximumTenor { get; set; }
}

/// <summary>
/// Open Banking (Okra) identifiers linked to a borrower's loan, if applicable.
/// </summary>
public class OkraDetails
{
    /// <summary>
    /// The Okra customer ID associated with the borrower.
    /// </summary>
    [JsonPropertyName("okra_customer_id")] public string OkraCustomerId { get; set; }

    /// <summary>
    /// The Okra record ID linked to the loan.
    /// </summary>
    [JsonPropertyName("okra_record_id")] public string OkraRecordId { get; set; }
}

/// <summary>
/// Represents a single repayment schedule entry for a loan.
/// </summary>
public class RepayScheduleItem
{
    /// <summary>
    /// The scheduled repayment date.
    /// </summary>
    [JsonPropertyName("repayment_date")] public string RepaymentDate { get; set; }

    /// <summary>
    /// The total amount due on the repayment date (principal + interest).
    /// </summary>
    [JsonPropertyName("repayment_amount")] public decimal RepaymentAmount { get; set; }

    /// <summary>
    /// The principal component of this repayment installment.
    /// </summary>
    [JsonPropertyName("principal")] public decimal Principal { get; set; }

    /// <summary>
    /// The interest component of this repayment installment.
    /// </summary>
    [JsonPropertyName("interest")] public decimal Interest { get; set; }

    /// <summary>
    /// The outstanding loan balance after this repayment.
    /// </summary>
    [JsonPropertyName("balance")] public decimal Balance { get; set; }

    /// <summary>
    /// The repayment status for this installment (e.g. paid, pending).
    /// </summary>
    [JsonPropertyName("status")] public string Status { get; set; }
}
