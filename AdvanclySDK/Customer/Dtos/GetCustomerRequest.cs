using System.Text.Json.Serialization;

public class GetCustomerRequest
{
    /// <summary>
    /// The unique identifier for the customer.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public string CustomerId { get; set; }

    /// <summary>
    /// The email address of the customer.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// The phone number of the customer.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }
}
