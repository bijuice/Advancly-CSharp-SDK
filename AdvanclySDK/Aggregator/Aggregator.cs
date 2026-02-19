using System.Net.Http.Json;
namespace AdvanclySDK;

public class Aggregator
{
    private readonly HttpClient _httpClient;

    public Aggregator(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetCountryStatesResponse> GetCountryStatesAsync(GetCountryStatesRequest request)
    {
        var query = "/api/v1/account/all_state?";
        if (!string.IsNullOrEmpty(request.AggregatorId))
            query += $"aggregator_id={Uri.EscapeDataString(request.AggregatorId)}&";
        if (request.StateId.HasValue)
            query += $"state_id={request.StateId.Value}&";
        if (!string.IsNullOrEmpty(request.CountryCode))
            query += $"country_code={Uri.EscapeDataString(request.CountryCode)}&";
        query = query.TrimEnd('&', '?');

        var response = await _httpClient.GetAsync(query);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetCountryStatesResponse>();
    }

    public async Task<GetCountryBankListResponse> GetCountryBankListAsync(string countryCode)
    {
        var response = await _httpClient.GetAsync(
            $"/api/v1/account/signed_banks_country?country_code={Uri.EscapeDataString(countryCode)}"
        );

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetCountryBankListResponse>();
    }

    public async Task<GetSectorsResponse> GetSectorsAsync()
    {
        var response = await _httpClient.GetAsync("/api/v1/misc/sectors");

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorContent}");
        }

        return await response.Content.ReadFromJsonAsync<GetSectorsResponse>();
    }


}
