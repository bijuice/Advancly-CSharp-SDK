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
            "/wallet/individual/create",
            requestBody
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateAccountResponse>();
    }

    public async Task<CreateAccountResponse> CreateCorporateAccountAsync(CreateCorporateAccountRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/wallet/corporate/create",
            requestBody
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<CreateAccountResponse>();
    }

    public async Task<AccountDetailsResponse> GetAccountDetailsAsync(string accountNumber)
    {
        var response = await _httpClient.GetAsync(
            $"/wallet?account_number={Uri.EscapeDataString(accountNumber)}"
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<AccountDetailsResponse>();
    }

    public async Task<FinancialInstitutionsResponse> GetFinancialInstitutionsAsync()
    {
        var response = await _httpClient.GetAsync(
            "/wallet/financial_institutions"
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<FinancialInstitutionsResponse>();
    }

    public async Task<NameEnquiryResponse> GetNameEnquiryAsync(NameEnquiryRequest request)
    {
        var response = await _httpClient.GetAsync(
            $"/wallet/name_enquiry?account_number={Uri.EscapeDataString(request.AccountNumber)}&bank_code={Uri.EscapeDataString(request.BankCode)}"
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<NameEnquiryResponse>();
    }

    public async Task<TransferResponse> TransferAsync(TransferRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "/wallet/transfer",
            requestBody
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<TransferResponse>();
    }

    public async Task<GetTransactionResponse> GetTransactionAsync(string transactionReference)
    {
        var response = await _httpClient.GetAsync(
            $"/wallet/transaction/{Uri.EscapeDataString(transactionReference)}"
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetTransactionResponse>();
    }

    public async Task<GetTransactionsResponse> GetTransactionsAsync(GetTransactionsRequest request)
    {
        var response = await _httpClient.GetAsync(
            $"/wallet/transactions?account_number={Uri.EscapeDataString(request.AccountNumber)}&start_date={Uri.EscapeDataString(request.StartDate)}&end_date={Uri.EscapeDataString(request.EndDate)}&page={request.Page}&page_size={request.PageSize}"
        );

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<GetTransactionsResponse>();
    }
}
