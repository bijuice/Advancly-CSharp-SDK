using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AdvanclySDK;

public class Loans
{
    private readonly HttpClient _httpClient;

    public Loans(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Initiate Loan Application - Process borrower onboarding and loan application
    /// POST /api/v2/client/loans/onboardcustomer_loanrequest
    /// </summary>
    public async Task<HttpResponseMessage> InitiateLoanApplicationAsync(object requestBody)
    {

        return await _httpClient.PostAsJsonAsync(
            "/api/v2/client/loans/onboardcustomer_loanrequest",
            requestBody
        );
    }

    /// <summary>
    /// Get Customer Loans - Get all loans for a specific customer
    /// GET /api/v2/client/loans/borrower/{customer_id}
    /// </summary>
    public async Task<HttpResponseMessage> GetCustomerLoansAsync(string customerId)
    {
        return await _httpClient.GetAsync(
            $"/api/v2/client/loans/borrower/{customerId}"
        );
    }

    /// <summary>
    /// Get Loan Details - Get loan details using loan reference number
    /// GET /api/v2/client/loans/{loan_ref_no}
    /// </summary>
    public async Task<HttpResponseMessage> GetLoanDetailsAsync(string loanRefNo)
    {
        return await _httpClient.GetAsync(
            $"/api/v2/client/loans/{loanRefNo}"
        );
    }

    /// <summary>
    /// Initiate Repayment
    /// POST /api/v2/client/loans/initiate_repayment
    /// </summary>
    public async Task<HttpResponseMessage> InitiateRepaymentAsync(object requestBody)
    {


        return await _httpClient.PostAsJsonAsync(
            "/api/v2/client/loans/initiate_repayment",
            requestBody
        );
    }

    /// <summary>
    /// Generate Loan Schedule
    /// POST /api/v2/client/loans/generate_loan_schedule
    /// </summary>
    public async Task<HttpResponseMessage> GenerateLoanScheduleAsync(object requestBody)
    {


        return await _httpClient.PostAsJsonAsync(
            "/api/v2/client/loans/generate_loan_schedule",
            requestBody
        );
    }

    /// <summary>
    /// Request Loan
    /// POST /api/v2/client/loans/request_loan
    /// </summary>
    public async Task<HttpResponseMessage> RequestLoanAsync(object requestBody)
    {


        return await _httpClient.PostAsJsonAsync(
            "/api/v2/client/loans/request_loan",
            requestBody
        );
    }
}