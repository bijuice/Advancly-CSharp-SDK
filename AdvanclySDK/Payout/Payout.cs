using System.Net.Http.Json;
namespace AdvanclySDK;

public class Payout
{
    private readonly HttpClient _httpClient;

    public Payout(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PayoutAccountDetailsResponse> GetAccountDetailsAsync()
    {
        var response = await _httpClient.GetAsync(
            "api/v2/client/payout/account_details"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<PayoutAccountDetailsResponse>();
    }

    public async Task<FinancialInstitutionsResponse> GetFinancialInstitutionsAsync()
    {
        var response = await _httpClient.GetAsync(
            "api/v2/client/payout/financial_institutions"
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
            $"api/v2/client/payout/name_enquiry?account_number={Uri.EscapeDataString(request.AccountNumber)}&bank_code={Uri.EscapeDataString(request.BankCode)}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<NameEnquiryResponse>();
    }

    public async Task<TransferResponse> PayoutAsync(TransferRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/payout/payout",
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
            $"api/v2/client/payout/transaction/{Uri.EscapeDataString(transactionReference)}"
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
            $"api/v2/client/payout/transactions?account_number={Uri.EscapeDataString(request.AccountNumber)}&start_date={Uri.EscapeDataString(request.StartDate)}&end_date={Uri.EscapeDataString(request.EndDate)}&page={request.Page}&page_size={request.PageSize}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetTransactionsResponse>();
    }
}
