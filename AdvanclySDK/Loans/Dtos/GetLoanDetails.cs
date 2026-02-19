
using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class LoanDetailsResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public LoanData Data { get; set; }
}

public class LoanData
{
    [JsonPropertyName("customer")] public CustomerInfo Customer { get; set; }
    [JsonPropertyName("repayment_account")] public RepaymentAccount RepaymentAccount { get; set; }
    [JsonPropertyName("loan_details")] public LoanItemDetails LoanDetails { get; set; }
    [JsonPropertyName("repayment_schedule")] public RepaymentSchedule RepaymentSchedule { get; set; }
}

public class CustomerInfo
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("first_name")] public string FirstName { get; set; }
    [JsonPropertyName("last_name")] public string LastName { get; set; }
    [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; }
    [JsonPropertyName("bank_name")] public string BankName { get; set; }
    [JsonPropertyName("bank_account_number")] public string BankAccountNumber { get; set; }
}

public class LoanItemDetails
{
    [JsonPropertyName("loan_id")] public int LoanId { get; set; }
    [JsonPropertyName("loan_amount")] public decimal LoanAmount { get; set; }
    [JsonPropertyName("loan_outstanding")] public decimal LoanOutstanding { get; set; }
    [JsonPropertyName("loan_status")] public string LoanStatus { get; set; }
    [JsonPropertyName("loan_status_code")] public int LoanStatusCode { get; set; }
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }
}