
using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving loan details by loan reference number.
/// GET /api/v2/client/loans/{loan_ref_no}
/// </summary>
public class LoanDetailsResponse
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
    /// The loan details data payload.
    /// </summary>
    [JsonPropertyName("data")] public LoanData Data { get; set; }
}

/// <summary>
/// Data payload containing detailed information about a loan.
/// </summary>
public class LoanData
{
    /// <summary>
    /// Basic information about the borrower.
    /// </summary>
    [JsonPropertyName("customer")] public CustomerInfo Customer { get; set; }

    /// <summary>
    /// The repayment account associated with the loan.
    /// </summary>
    [JsonPropertyName("repayment_account")] public RepaymentAccount RepaymentAccount { get; set; }

    /// <summary>
    /// The core details of the loan.
    /// </summary>
    [JsonPropertyName("loan_details")] public LoanItemDetails LoanDetails { get; set; }

    /// <summary>
    /// The repayment schedule for the loan.
    /// </summary>
    [JsonPropertyName("repayment_schedule")] public RepaymentSchedule RepaymentSchedule { get; set; }
}

/// <summary>
/// Basic customer/borrower information associated with a loan.
/// </summary>
public class CustomerInfo
{
    /// <summary>
    /// The unique identifier of the customer.
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    [JsonPropertyName("first_name")] public string FirstName { get; set; }

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    [JsonPropertyName("last_name")] public string LastName { get; set; }

    /// <summary>
    /// The phone number of the customer.
    /// </summary>
    [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; }

    /// <summary>
    /// The name of the customer's bank.
    /// </summary>
    [JsonPropertyName("bank_name")] public string BankName { get; set; }

    /// <summary>
    /// The customer's bank account number.
    /// </summary>
    [JsonPropertyName("bank_account_number")] public string BankAccountNumber { get; set; }
}

/// <summary>
/// Core details of a specific loan.
/// </summary>
public class LoanItemDetails
{
    /// <summary>
    /// The unique identifier of the loan.
    /// </summary>
    [JsonPropertyName("loan_id")] public int LoanId { get; set; }

    /// <summary>
    /// The original principal amount of the loan.
    /// </summary>
    [JsonPropertyName("loan_amount")] public decimal LoanAmount { get; set; }

    /// <summary>
    /// The outstanding balance remaining on the loan.
    /// </summary>
    [JsonPropertyName("loan_outstanding")] public decimal LoanOutstanding { get; set; }

    /// <summary>
    /// The human-readable status of the loan.
    /// </summary>
    [JsonPropertyName("loan_status")] public string LoanStatus { get; set; }

    /// <summary>
    /// The numeric status code of the loan. See Loan Status for meanings.
    /// </summary>
    [JsonPropertyName("loan_status_code")] public int LoanStatusCode { get; set; }

    /// <summary>
    /// The unique reference number of the loan.
    /// </summary>
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }
}