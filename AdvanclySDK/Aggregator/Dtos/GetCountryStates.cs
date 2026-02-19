using System.Text.Json.Serialization;

public class GetCountryStatesRequest
{
    [JsonPropertyName("aggregator_id")] public string AggregatorId { get; set; }
    [JsonPropertyName("state_id")] public int? StateId { get; set; }
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}

public class GetCountryStatesResponse
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("status")] public bool Status { get; set; }
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }
    [JsonPropertyName("data")] public List<StateData> Data { get; set; }
}

public class StateData
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("state_code")] public string StateCode { get; set; }
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}
