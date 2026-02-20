using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Request model for loading a customer's stock data.
/// POST /api/v2/client/customers/data/stock
/// </summary>
public class LoadCustomerStockDataRequest
{
    /// <summary>
    /// The stock data to load for the customer.
    /// </summary>
    [JsonPropertyName("stock_data")]
    public object StockData { get; set; }
}

/// <summary>
/// Response model returned after loading customer stock data.
/// </summary>
public class LoadCustomerStockDataResponse
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
