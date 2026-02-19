using AdvanclySDK;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public static class TestSettings
{
    public static IOptions<AdvanclySDKOptions> LoadOptions()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        var sdkOptions = new AdvanclySDKOptions();
        config.GetSection("AdvanclySDK").Bind(sdkOptions);

        return Options.Create(sdkOptions);
    }
}
