using System.Text.Json.Serialization;

public class LoanApplicationResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public LoanApplicationData Data { get; set; }
}

public class LoanApplicationData
{
    [JsonPropertyName("customer_id")] public int CustomerId { get; set; }
    [JsonPropertyName("loan_ref")] public string LoanRef { get; set; }
    [JsonPropertyName("aggregator_loan_ref")] public string AggregatorLoanRef { get; set; }
    [JsonPropertyName("loan_amount")] public decimal LoanAmount { get; set; }
    [JsonPropertyName("loan_tenure")] public int LoanTenure { get; set; }
    [JsonPropertyName("loan_status")] public string LoanStatus { get; set; }
    [JsonPropertyName("pub_date")] public string PubDate { get; set; }
}
