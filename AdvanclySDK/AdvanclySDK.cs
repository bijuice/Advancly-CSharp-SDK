using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AdvanclySDK;

/// <summary>
/// Provides access to all Advancly API service clients.
/// </summary>
public interface IAdvanclySDK
{
    /// <summary>Customer onboarding and management operations.</summary>
    Customer Customer { get; }

    /// <summary>Loan application, repayment, and enquiry operations.</summary>
    Loans Loans { get; }

    /// <summary>Virtual account creation, transfers, and transaction operations.</summary>
    VirtualAccount VirtualAccount { get; }

    /// <summary>Payout disbursement and transaction operations.</summary>
    Payout Payout { get; }

    /// <summary>Aggregator-level reference data (states, banks, sectors).</summary>
    Aggregator Aggregator { get; }
}

/// <summary>
/// Main entry point for the Advancly SDK.
/// </summary>
public class AdvanclySDK : IAdvanclySDK
{
    private readonly AdvanclySDKOptions _options;

    /// <inheritdoc/>
    public Customer Customer { get; private set; }

    /// <inheritdoc/>
    public Loans Loans { get; private set; }

    /// <inheritdoc/>
    public VirtualAccount VirtualAccount { get; private set; }

    /// <inheritdoc/>
    public Payout Payout { get; private set; }

    /// <inheritdoc/>
    public Aggregator Aggregator { get; private set; }

    /// <summary>
    /// Initializes a new instance of <see cref="AdvanclySDK"/>.
    /// </summary>
    /// <param name="options">SDK configuration options.</param>
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

        Customer = new Customer(httpClient);
        Loans = new Loans(httpClient);
        VirtualAccount = new VirtualAccount(httpClient);
        Payout = new Payout(httpClient);
        Aggregator = new Aggregator(httpClient);
    }
}

/// <summary>
/// Extension methods for registering the Advancly SDK with Microsoft Dependency Injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="IAdvanclySDK"/> with the DI container using the supplied configuration action.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configureOptions">Action to configure <see cref="AdvanclySDKOptions"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining.</returns>
    public static IServiceCollection AddAdvanclySDK(this IServiceCollection services, Action<AdvanclySDKOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddScoped<IAdvanclySDK, AdvanclySDK>();
        return services;
    }
}