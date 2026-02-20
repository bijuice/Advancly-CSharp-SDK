using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for loading a customer's orders data.
/// POST /api/v2/client/customers/data/orders
/// </summary>
public class LoadCustomerOrdersDataRequest
{
    /// <summary>
    /// The orders data to load for the customer.
    /// </summary>
    [JsonPropertyName("orders_data")]
    public object OrdersData { get; set; }
}

/// <summary>
/// Response model returned after loading customer orders data.
/// </summary>
public class LoadCustomerOrdersDataResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }
}
