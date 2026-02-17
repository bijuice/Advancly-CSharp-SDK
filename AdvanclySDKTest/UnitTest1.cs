using AdvanclySDK;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public class UnitTest1
{
    [Fact]
    public void AdvanclySDK_InitializesSuccessfully_WithValidOptions()
    {
        // Arrange
        var options = Options.Create(new AdvanclySDKOptions
        {
            ClientId = "test-client-id",
            ApiKey = "test-api-key",
            ApiUrl = "https://api-sandbox.advancly.com/"
        });

        // Act
        var sdk = new AdvanclySDK.AdvanclySDK(options);

        // Assert
        Assert.NotNull(sdk);
    }

}