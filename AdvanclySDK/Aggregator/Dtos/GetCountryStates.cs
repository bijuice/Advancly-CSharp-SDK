using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Query parameters for retrieving states for an aggregator's country.
/// GET /api/v1/account/all_state
/// </summary>
public class GetCountryStatesRequest
{
    /// <summary>
    /// The unique identifier of the aggregator. Filters states by aggregator nationality when provided.
    /// </summary>
    [JsonPropertyName("aggregator_id")] public string AggregatorId { get; set; }

    /// <summary>
    /// The ID of a specific state to retrieve.
    /// </summary>
    [JsonPropertyName("state_id")] public int? StateId { get; set; }

    /// <summary>
    /// The ISO country code to filter states by, e.g. "NG", "GH", "SA".
    /// </summary>
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}

/// <summary>
/// Response model for retrieving a list of states for an aggregator's country.
/// </summary>
public class GetCountryStatesResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")] public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")] public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")] public int StatusCode { get; set; }

    /// <summary>
    /// The list of states matching the query.
    /// </summary>
    [JsonPropertyName("data")] public List<StateData> Data { get; set; }
}

/// <summary>
/// Represents a single state entry.
/// </summary>
public class StateData
{
    /// <summary>
    /// The unique identifier of the state.
    /// </summary>
    [JsonPropertyName("id")] public int Id { get; set; }

    /// <summary>
    /// The name of the state.
    /// </summary>
    [JsonPropertyName("name")] public string Name { get; set; }

    /// <summary>
    /// The short code identifying the state.
    /// </summary>
    [JsonPropertyName("state_code")] public string StateCode { get; set; }

    /// <summary>
    /// The ISO country code the state belongs to.
    /// </summary>
    [JsonPropertyName("country_code")] public string CountryCode { get; set; }
}
