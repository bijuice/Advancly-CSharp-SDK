using System.Text.Json.Serialization;

public class LoadCustomerStockDataRequest
{
    /// <summary>
    /// The stock data to load for the customer.
    /// </summary>
    [JsonPropertyName("stock_data")]
    public object StockData { get; set; }
}

public class LoadCustomerStockDataResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }
}
