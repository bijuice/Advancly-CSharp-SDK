using System.Text.Json.Serialization;

namespace AdvanclySDK;

public class LoadCustomerOrdersDataRequest
{
    /// <summary>
    /// The orders data to load for the customer.
    /// </summary>
    [JsonPropertyName("orders_data")]
    public object OrdersData { get; set; }
}

public class LoadCustomerOrdersDataResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }
}
