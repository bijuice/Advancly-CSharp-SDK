using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class InitiateRepaymentRequest
{
    [JsonPropertyName("loan_ref_no")] public string LoanRefNo { get; set; }
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
}

public class RepaymentResponse
{
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("data")] public RepaymentData Data { get; set; }
}

public class RepaymentData
{
    [JsonPropertyName("loanRef")] public string LoanRef { get; set; }
    [JsonPropertyName("accountNumber")] public string AccountNumber { get; set; }
    [JsonPropertyName("bank")] public string Bank { get; set; }
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
    [JsonPropertyName("repaymentStatus")] public int RepaymentStatus { get; set; } // 1=Pending, 2=Success
}