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

    public async Task<T> InitiateLoanApplicationAsync<T>(InitiateLoanApplicationRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/loans/onboardcustomer_loanrequest",
            requestBody
        );

        // Ensure success or handle errors before deserializing
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<GetCustomerLoansResponse> GetCustomerLoansAsync(string customerId)
    {
        var response = await _httpClient.GetAsync(
            $"/loans/borrower/{customerId}"
        );

        // Ensure success or handle errors before deserializing
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetCustomerLoansResponse>();
    }

    public async Task<LoanDetailsResponse> GetLoanDetailsAsync<LoanDetailsResponse>(string loanRefNo)
    {
        var response = await _httpClient.GetAsync(
            $"/loans/{loanRefNo}"
        );

        // Ensure success or handle errors before deserializing
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<LoanDetailsResponse>();
    }

    public async Task<RepaymentResponse> InitiateRepaymentAsync(InitiateRepaymentRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/loans/initiate_repayment",
            requestBody
        );

        // Ensure success or handle errors before deserializing
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<RepaymentResponse>();
    }

    public async Task<T> GenerateLoanScheduleAsync<T>(GenerateLoanScheduleRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/loans/generate_loan_schedule",
            requestBody
        );

        // Ensure success or handle errors before deserializing
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T> RequestLoanAsync<T>(RequestLoanRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/loans/request_loan",
            requestBody
        );

        // Ensure success or handle errors before deserializing
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>();
    }
}