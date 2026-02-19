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

}
