using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AdvanclySDK;


public interface IAdvanclySDK
{
    // Define methods for your SDK interface here
}

public class AdvanclySDK : IAdvanclySDK
{

    private readonly AdvanclySDKOptions _options;
    public Loans Loans { get; private set; }

    public AdvanclySDK(IOptions<AdvanclySDKOptions> options)
    {
        _options = options.Value;

        if (string.IsNullOrEmpty(_options.ClientId))
            throw new ArgumentException("ClientId is required", nameof(options));
        if (string.IsNullOrEmpty(_options.ApiKey))
            throw new ArgumentException("ApiKey is required", nameof(options));


        var httpClient = new HttpClient { BaseAddress = new Uri(_options.ApiUrl) };

        Loans = new Loans(httpClient);

        Console.WriteLine($"AdvanclySDK initialized with ClientId: {_options.ClientId}, ApiKey: {_options.ApiKey}, ApiUrl: {_options.ApiUrl}");
    }
}

// In your library
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMyLibrary(this IServiceCollection services, Action<AdvanclySDKOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddScoped<IAdvanclySDK, AdvanclySDK>();
        return services;
    }
}