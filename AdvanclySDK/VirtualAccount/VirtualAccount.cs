using System.Net.Http.Json;
using System.Web;
namespace AdvanclySDK;

public class VirtualAccount
{
    private readonly HttpClient _httpClient;

    public VirtualAccount(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CreateAccountResponse> CreateIndividualAccountAsync(CreateIndividualAccountRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/wallet/individual/create",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<CreateAccountResponse>();
    }

    public async Task<CreateAccountResponse> CreateCorporateAccountAsync(CreateCorporateAccountRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/wallet/corporate/create",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<CreateAccountResponse>();
    }

    public async Task<CreateDynamicAccountResponse> CreateDynamicAccountAsync(CreateDynamicAccountRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/wallet/dynamic/generate",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<CreateDynamicAccountResponse>();
    }

    public async Task<AccountDetailsResponse> GetAccountDetailsAsync(string accountNumber)
    {
        var response = await _httpClient.GetAsync(
            $"api/v2/client/wallet?account_number={Uri.EscapeDataString(accountNumber)}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<AccountDetailsResponse>();
    }

    public async Task<FinancialInstitutionsResponse> GetFinancialInstitutionsAsync()
    {
        var response = await _httpClient.GetAsync(
            "api/v2/client/wallet/financial_institutions"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<FinancialInstitutionsResponse>();
    }

    public async Task<NameEnquiryResponse> GetNameEnquiryAsync(NameEnquiryRequest request)
    {
        var response = await _httpClient.GetAsync(
            $"api/v2/client/wallet/name_enquiry?account_number={Uri.EscapeDataString(request.AccountNumber)}&bank_code={Uri.EscapeDataString(request.BankCode)}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<NameEnquiryResponse>();
    }

    public async Task<TransferResponse> TransferAsync(TransferRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/wallet/transfer",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<TransferResponse>();
    }

    public async Task<GetTransactionResponse> GetTransactionAsync(string transactionReference)
    {
        var response = await _httpClient.GetAsync(
            $"api/v2/client/wallet/transaction/{Uri.EscapeDataString(transactionReference)}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetTransactionResponse>();
    }

    public async Task<GetTransactionsResponse> GetTransactionsAsync(GetTransactionsRequest request)
    {
        var response = await _httpClient.GetAsync(
            $"api/v2/client/wallet/transactions?account_number={Uri.EscapeDataString(request.AccountNumber)}&start_date={Uri.EscapeDataString(request.StartDate)}&end_date={Uri.EscapeDataString(request.EndDate)}&page={request.Page}&page_size={request.PageSize}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetTransactionsResponse>();
    }
}
