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
            "api/v2/client/loans/onboardcustomer_loanrequest",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        var content = await response.Content.ReadFromJsonAsync<T>();

        return content;
    }

    public async Task<GetCustomerLoansResponse> GetCustomerLoansAsync(string customerId)
    {
        var response = await _httpClient.GetAsync(
            $"api/v2/client/loans/borrower/{customerId}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetCustomerLoansResponse>();
    }

    public async Task<LoanDetailsResponse> GetLoanDetailsAsync<LoanDetailsResponse>(string loanRefNo)
    {
        var response = await _httpClient.GetAsync(
            $"api/v2/client/loans/{loanRefNo}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<LoanDetailsResponse>();
    }

    public async Task<RepaymentResponse> InitiateRepaymentAsync(InitiateRepaymentRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/loans/initiate_repayment",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<RepaymentResponse>();
    }

    public async Task<T> GenerateLoanScheduleAsync<T>(GenerateLoanScheduleRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/loans/generate_loan_schedule",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T> RequestLoanAsync<T>(RequestLoanRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/loans/request_loan",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }
}