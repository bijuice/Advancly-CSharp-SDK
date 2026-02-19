using AdvanclySDK;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public class CustomerTests
{
    private readonly IOptions<AdvanclySDKOptions> _options;
    private readonly AdvanclySDK.AdvanclySDK _sdk;

    public CustomerTests()
    {
        _options = TestSettings.LoadOptions();
        _sdk = new AdvanclySDK.AdvanclySDK(_options);
    }

    [Fact]
    public void AdvanclySDK_InitializesSuccessfully_WithValidOptions()
    {
        // Act
        var sdk = new AdvanclySDK.AdvanclySDK(_options);

        // Assert
        Assert.NotNull(sdk);
        Assert.NotNull(sdk.Customer);
    }

    [Fact]
    public async Task OnboardIndividualCustomer_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new OnboardIndividualCustomerRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "+2348012345678",
            Bvn = "12345678901",
            IdentityNumber = "12345678901",
            CountryCode = "NG",
            Gender = "male",
            DateOfBirth = "1990-01-01",
            Address = "123 Test Street, Lagos",
            CustomerType = "Individual"
        };

        // Act
        var response = await _sdk.Customer.OnboardIndividualCustomerAsync<OnboardIndividualCustomerResponse>(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Message);
        Assert.True(response.BorrowerId > 0);
        Assert.Equal(request.FirstName, response.FirstName);
        Assert.Equal(request.LastName, response.LastName);
    }

    [Fact]
    public async Task OnboardCorporateCustomer_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new OnboardCorporateCustomerRequest
        {
            CompanyName = "Test Corp Ltd",
            Email = "contact@testcorp.com",
            PhoneNumber = "+2348087654321",
            IdentityNumber = "98765432109",
            CountryCode = "NG",
            Address = "456 Corporate Avenue, Lagos",
            CustomerType = "Corporate",
            RcNumber = "RC123456"
        };

        // Act
        var response = await _sdk.Customer.OnboardCorporateCustomerAsync<OnboardCorporateCustomerResponse>(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Message);
        Assert.True(response.BorrowerId > 0);
        Assert.Equal(request.CompanyName, response.CompanyName);
    }

    [Fact]
    public async Task GetCustomer_ByCustomerId_ReturnsCustomerData()
    {
        // Arrange
        var request = new GetCustomerRequest
        {
            CustomerId = "test-customer-123" // Replace with valid test customer ID from sandbox
        };

        // Act
        var response = await _sdk.Customer.GetCustomerAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotNull(response.Data.FirstName);
        Assert.NotNull(response.Data.LastName);
    }

    [Fact]
    public async Task GetCustomer_ByEmail_ReturnsCustomerData()
    {
        // Arrange
        var request = new GetCustomerRequest
        {
            Email = "john.doe@example.com" // Replace with valid test email from sandbox
        };

        // Act
        var response = await _sdk.Customer.GetCustomerAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.Email, response.Data.Email);
    }

    [Fact]
    public async Task GetCustomer_ByPhoneNumber_ReturnsCustomerData()
    {
        // Arrange
        var request = new GetCustomerRequest
        {
            PhoneNumber = "+2348012345678" // Replace with valid test phone number from sandbox
        };

        // Act
        var response = await _sdk.Customer.GetCustomerAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.PhoneNumber, response.Data.PhoneNumber);
    }

    [Fact]
    public async Task LoadCustomerStockData_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var customerId = "test-customer-123"; // Replace with valid test customer ID from sandbox
        var request = new LoadCustomerStockDataRequest
        {
            StockData = new
            {
                product_name = "Test Product",
                quantity = 100,
                unit_price = 50.00,
                total_value = 5000.00,
                last_updated = "2026-02-18"
            }
        };

        // Act
        var response = await _sdk.Customer.LoadCustomerStockDataAsync(request, customerId);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Message);
    }

    [Fact]
    public async Task LoadCustomerOrdersData_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var customerId = "test-customer-123"; // Replace with valid test customer ID from sandbox
        var request = new LoadCustomerOrdersDataRequest
        {
            OrdersData = new
            {
                order_id = "ORD-001",
                order_date = "2026-02-18",
                customer_name = "John Doe",
                total_amount = 15000.00,
                status = "completed"
            }
        };

        // Act
        var response = await _sdk.Customer.LoadCustomerOrdersDataAsync(request, customerId);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Message);
    }

    [Fact]
    public async Task OnboardIndividualCustomer_WithMissingRequiredFields_ThrowsException()
    {
        // Arrange
        var request = new OnboardIndividualCustomerRequest
        {
            FirstName = "John",
            // Missing required fields
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.OnboardIndividualCustomerAsync<OnboardIndividualCustomerResponse>(request)
        );
    }

    [Fact]
    public async Task OnboardCorporateCustomer_WithMissingCompanyName_ThrowsException()
    {
        // Arrange
        var request = new OnboardCorporateCustomerRequest
        {
            Email = "contact@testcorp.com",
            // Missing CompanyName and other required fields
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.OnboardCorporateCustomerAsync<OnboardCorporateCustomerResponse>(request)
        );
    }

    [Fact]
    public async Task GetCustomer_WithInvalidCustomerId_ThrowsException()
    {
        // Arrange
        var request = new GetCustomerRequest
        {
            CustomerId = "invalid-customer-999999"
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.GetCustomerAsync(request)
        );
    }

    [Fact]
    public async Task LoadCustomerStockData_WithInvalidCustomerId_ThrowsException()
    {
        // Arrange
        var invalidCustomerId = "invalid-customer-999999";
        var request = new LoadCustomerStockDataRequest
        {
            StockData = new { product_name = "Test Product" }
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.LoadCustomerStockDataAsync(request, invalidCustomerId)
        );
    }

    [Fact]
    public async Task LoadCustomerOrdersData_WithInvalidCustomerId_ThrowsException()
    {
        // Arrange
        var invalidCustomerId = "invalid-customer-999999";
        var request = new LoadCustomerOrdersDataRequest
        {
            OrdersData = new { order_id = "ORD-001" }
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.LoadCustomerOrdersDataAsync(request, invalidCustomerId)
        );
    }

    [Fact]
    public async Task OnboardIndividualCustomer_WithInvalidEmail_ThrowsException()
    {
        // Arrange
        var request = new OnboardIndividualCustomerRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "invalid-email", // Invalid email format
            PhoneNumber = "+2348012345678",
            Bvn = "12345678901",
            IdentityNumber = "12345678901",
            CountryCode = "NG",
            Gender = "male",
            DateOfBirth = "1990-01-01",
            Address = "123 Test Street, Lagos",
            CustomerType = "Individual"
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.OnboardIndividualCustomerAsync<OnboardIndividualCustomerResponse>(request)
        );
    }

    [Fact]
    public async Task OnboardIndividualCustomer_WithInvalidBvn_ThrowsException()
    {
        // Arrange
        var request = new OnboardIndividualCustomerRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "+2348012345678",
            Bvn = "123", // Invalid BVN (should be 11 digits)
            IdentityNumber = "12345678901",
            CountryCode = "NG",
            Gender = "male",
            DateOfBirth = "1990-01-01",
            Address = "123 Test Street, Lagos",
            CustomerType = "Individual"
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Customer.OnboardIndividualCustomerAsync<OnboardIndividualCustomerResponse>(request)
        );
    }

    [Fact]
    public async Task GetCustomer_WithMultipleParameters_ReturnsCustomerData()
    {
        // Arrange
        var request = new GetCustomerRequest
        {
            CustomerId = "test-customer-123",
            Email = "john.doe@example.com",
            PhoneNumber = "+2348012345678"
        };

        // Act
        var response = await _sdk.Customer.GetCustomerAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
    }

    [Fact]
    public async Task LoadCustomerStockData_WithComplexStockData_ReturnsSuccessResponse()
    {
        // Arrange
        var customerId = "test-customer-123";
        var request = new LoadCustomerStockDataRequest
        {
            StockData = new[]
            {
                new
                {
                    product_id = "PROD-001",
                    product_name = "Product A",
                    quantity = 50,
                    unit_price = 100.00,
                    category = "Electronics"
                },
                new
                {
                    product_id = "PROD-002",
                    product_name = "Product B",
                    quantity = 75,
                    unit_price = 75.00,
                    category = "Furniture"
                }
            }
        };

        // Act
        var response = await _sdk.Customer.LoadCustomerStockDataAsync(request, customerId);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
    }

    [Fact]
    public async Task LoadCustomerOrdersData_WithMultipleOrders_ReturnsSuccessResponse()
    {
        // Arrange
        var customerId = "test-customer-123";
        var request = new LoadCustomerOrdersDataRequest
        {
            OrdersData = new[]
            {
                new
                {
                    order_id = "ORD-001",
                    order_date = "2026-02-01",
                    total_amount = 15000.00,
                    status = "completed"
                },
                new
                {
                    order_id = "ORD-002",
                    order_date = "2026-02-10",
                    total_amount = 25000.00,
                    status = "pending"
                }
            }
        };

        // Act
        var response = await _sdk.Customer.LoadCustomerOrdersDataAsync(request, customerId);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
    }
}
