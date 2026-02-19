using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace AdvanclySDK;

public class Customer
{
    private readonly HttpClient _httpClient;

    public Customer(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> OnboardIndividualCustomerAsync<T>(OnboardIndividualCustomerRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/customers/onboard_individual",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T> OnboardCorporateCustomerAsync<T>(OnboardCorporateCustomerRequest requestBody)
    {
        var response = await _httpClient.PostAsJsonAsync(
            "api/v2/client/customers/onboard_corporate",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<T>();
    }

    public async Task<GetCustomerResponse> GetCustomerAsync(GetCustomerRequest request)
    {
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(request.CustomerId))
            queryParams.Add($"customer_id={Uri.EscapeDataString(request.CustomerId)}");

        if (!string.IsNullOrEmpty(request.Email))
            queryParams.Add($"email={Uri.EscapeDataString(request.Email)}");

        if (!string.IsNullOrEmpty(request.PhoneNumber))
            queryParams.Add($"phone_number={Uri.EscapeDataString(request.PhoneNumber)}");

        var queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

        var response = await _httpClient.GetAsync(
            $"api/v2/client/customers{queryString}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetCustomerResponse>();
    }

    public async Task<LoadCustomerStockDataResponse> LoadCustomerStockDataAsync(LoadCustomerStockDataRequest requestBody, string customerId)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"api/v2/client/customers/data/stock?customer_id={Uri.EscapeDataString(customerId)}",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<LoadCustomerStockDataResponse>();
    }

    public async Task<LoadCustomerOrdersDataResponse> LoadCustomerOrdersDataAsync(LoadCustomerOrdersDataRequest requestBody, string customerId)
    {
        var response = await _httpClient.PostAsJsonAsync(
            $"api/v2/client/customers/data/orders?customer_id={Uri.EscapeDataString(customerId)}",
            requestBody
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<LoadCustomerOrdersDataResponse>();
    }
}
