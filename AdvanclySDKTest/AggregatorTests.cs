using AdvanclySDK;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public class AggregatorTests
{
    private readonly IOptions<AdvanclySDKOptions> _options;
    private readonly AdvanclySDK.AdvanclySDK _sdk;

    public AggregatorTests()
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
        Assert.NotNull(sdk.Aggregator);
    }

    [Fact]
    public async Task GetCountryStates_WithCountryCode_ReturnsStateList()
    {
        // Arrange
        var request = new GetCountryStatesRequest
        {
            CountryCode = "NG"
        };

        // Act
        var response = await _sdk.Aggregator.GetCountryStatesAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
        Assert.All(response.Data, state =>
        {
            Assert.NotNull(state.Name);
            Assert.NotNull(state.CountryCode);
        });
    }

    [Fact]
    public async Task GetCountryStates_WithNoParams_ReturnsStateList()
    {
        // Arrange
        var request = new GetCountryStatesRequest();

        // Act
        var response = await _sdk.Aggregator.GetCountryStatesAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
    }

    [Fact]
    public async Task GetCountryBankList_WithValidCountryCode_ReturnsBankList()
    {
        // Act
        var response = await _sdk.Aggregator.GetCountryBankListAsync("NG");

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
        Assert.All(response.Data, bank =>
        {
            Assert.NotNull(bank.Code);
            Assert.NotNull(bank.Name);
        });
    }

    [Fact]
    public async Task GetSectors_ReturnsSectorList()
    {
        // Act
        var response = await _sdk.Aggregator.GetSectorsAsync();

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
        Assert.All(response.Data, sector =>
        {
            Assert.NotNull(sector.CategoryName);
            Assert.NotNull(sector.Code);
        });
    }

    [Fact]
    public async Task GetAggregatorProducts_ReturnsProductList()
    {
        // Act
        var response = await _sdk.Aggregator.GetAggregatorProductsAsync();

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
        Assert.All(response.Data, product =>
        {
            Assert.NotNull(product.ProductName);
            Assert.True(product.Id > 0);
        });
    }

    [Fact]
    public async Task LoanApplication_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new InitiateLoanApplicationRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = $"john.doe.{Guid.NewGuid().ToString("N").Substring(0, 8)}@example.com",
            PhoneNumber = "08012345678",
            Gender = "male",
            BorrowerType = 1,
            DateOfBirth = "1990-01-01",
            State = "Lagos",
            City = "Lagos",
            ResidenceAddress = "1 Test Street, Lagos",
            CountryCode = "NG",
            SectorCode = "1001",
            ProductId = 1,
            AggregatorLoanRef = $"AGG-TEST-{Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper()}",
            BankCode = "044",
            BankAccountNum = "0123456789",
            LoanAmount = 50000,
            LoanTenure = 3
        };

        // Act
        var response = await _sdk.Aggregator.LoanApplicationAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotNull(response.Data.LoanRef);
        Assert.Equal(request.AggregatorLoanRef, response.Data.AggregatorLoanRef);
        Assert.Equal(request.LoanAmount, response.Data.LoanAmount);
    }

    [Fact]
    public async Task LoanApplication_WithDuplicateRef_ThrowsException()
    {
        // Arrange
        var request = new InitiateLoanApplicationRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe.duplicate@example.com",
            PhoneNumber = "08012345678",
            Gender = "male",
            BorrowerType = 1,
            DateOfBirth = "1990-01-01",
            State = "Lagos",
            City = "Lagos",
            ResidenceAddress = "1 Test Street, Lagos",
            CountryCode = "NG",
            SectorCode = "1001",
            ProductId = 1,
            AggregatorLoanRef = "AGG-DUPLICATE-REF-001", // Already used reference
            BankCode = "044",
            BankAccountNum = "0123456789",
            LoanAmount = 50000,
            LoanTenure = 3
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Aggregator.LoanApplicationAsync(request)
        );
    }

    [Fact]
    public async Task GetLoanByReference_WithAggregatorRef_ReturnsLoanDetails()
    {
        // Arrange
        var request = new GetLoanByReferenceRequest
        {
            AggregatorLoanRef = "AGG-TEST-REF-001" // Replace with valid ref from sandbox
        };

        // Act
        var response = await _sdk.Aggregator.GetLoanByReferenceAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.AggregatorLoanRef, response.Data.AggregatorLoanRef);
        Assert.NotNull(response.Data.LoanRef);
        Assert.NotNull(response.Data.LoanStatus);
    }

    [Fact]
    public async Task GetLoanByReference_WithInvalidRef_ThrowsException()
    {
        // Arrange
        var request = new GetLoanByReferenceRequest
        {
            AggregatorLoanRef = "INVALID-REF-DOES-NOT-EXIST"
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Aggregator.GetLoanByReferenceAsync(request)
        );
    }
}
