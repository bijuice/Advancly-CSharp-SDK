using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class GetLoanByReferenceRequest
{
    [JsonPropertyName("aggregator_loan_ref")] public string AggregatorLoanRef { get; set; }
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }
}

public class GetLoanByReferenceResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public LoanByReferenceData Data { get; set; }
}

public class LoanByReferenceData
{
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }
    [JsonPropertyName("aggregator_loan_ref")] public string AggregatorLoanRef { get; set; }
    [JsonPropertyName("loan_amount")] public decimal LoanAmount { get; set; }
    [JsonPropertyName("loan_tenure")] public int LoanTenure { get; set; }
    [JsonPropertyName("loan_status")] public string LoanStatus { get; set; }
    [JsonPropertyName("pub_date")] public string PubDate { get; set; }
    [JsonPropertyName("aggregator_details")] public AggregatorDetails AggregatorDetails { get; set; }
    [JsonPropertyName("borrower_details")] public BorrowerDetails BorrowerDetails { get; set; }
    [JsonPropertyName("product_detail")] public ProductDetail ProductDetail { get; set; }
    [JsonPropertyName("okra_details")] public OkraDetails OkraDetails { get; set; }
    [JsonPropertyName("repay_schedule")] public List<RepayScheduleItem> RepaySchedule { get; set; }
}

public class AggregatorDetails
{
    [JsonPropertyName("aggregator_id")] public int AggregatorId { get; set; }
    [JsonPropertyName("aggregator_name")] public string AggregatorName { get; set; }
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}

public class BorrowerDetails
{
    [JsonPropertyName("customer_id")] public int CustomerId { get; set; }
    [JsonPropertyName("first_name")] public string FirstName { get; set; }
    [JsonPropertyName("last_name")] public string LastName { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; }
    [JsonPropertyName("bvn")] public string Bvn { get; set; }
}

public class ProductDetail
{
    [JsonPropertyName("product_id")] public int ProductId { get; set; }
    [JsonPropertyName("product_name")] public string ProductName { get; set; }
    [JsonPropertyName("interest_rate")] public decimal InterestRate { get; set; }
    [JsonPropertyName("maximum_tenor")] public int MaximumTenor { get; set; }
}

public class OkraDetails
{
    [JsonPropertyName("okra_customer_id")] public string OkraCustomerId { get; set; }
    [JsonPropertyName("okra_record_id")] public string OkraRecordId { get; set; }
}

public class RepayScheduleItem
{
    [JsonPropertyName("repayment_date")] public string RepaymentDate { get; set; }
    [JsonPropertyName("repayment_amount")] public decimal RepaymentAmount { get; set; }
    [JsonPropertyName("principal")] public decimal Principal { get; set; }
    [JsonPropertyName("interest")] public decimal Interest { get; set; }
    [JsonPropertyName("balance")] public decimal Balance { get; set; }
    [JsonPropertyName("status")] public string Status { get; set; }
}
