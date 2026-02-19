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
    public Customer Customer { get; private set; }
    public VirtualAccount VirtualAccount { get; private set; }
    public Payout Payout { get; private set; }
    public Aggregator Aggregator { get; private set; }

    public AdvanclySDK(IOptions<AdvanclySDKOptions> options)
    {
        _options = options.Value;

        if (string.IsNullOrEmpty(_options.ClientId))
            throw new ArgumentException("ClientId is required", nameof(options));
        if (string.IsNullOrEmpty(_options.ApiKey))
            throw new ArgumentException("ApiKey is required", nameof(options));


        var httpClient = new HttpClient { BaseAddress = new Uri(_options.ApiUrl.TrimEnd('/') + "/") };

        httpClient.DefaultRequestHeaders.Add("client-id", _options.ClientId);
        httpClient.DefaultRequestHeaders.Add("api-key", _options.ApiKey);

        Loans = new Loans(httpClient);
        Customer = new Customer(httpClient);
        VirtualAccount = new VirtualAccount(httpClient);
        Payout = new Payout(httpClient);
        Aggregator = new Aggregator(httpClient);

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