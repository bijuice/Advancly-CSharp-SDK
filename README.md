# Advancly SDK for .NET

Official .NET client library for the [Advancly API](https://docs.advancly.com/). Provides strongly-typed, async clients for Customers, Loans, Virtual Accounts, Payouts, and Aggregator operations.

This SDK does not implement a webhook endpoint. You'll need to implement using the instructions [here](https://docs.advancly.com/webhook)

## Installation

```
dotnet add package Advancly.SDK
```

Or via the NuGet Package Manager:

```
Install-Package Advancly.SDK
```

## Requirements

- .NET 6.0 or .NET 8.0

## Configuration

You will need a **Client ID** and **API Key** from the [Advancly dashboard](https://advancly.com).

### With Microsoft Dependency Injection (recommended)

```csharp
// Program.cs / Startup.cs
builder.Services.AddAdvanclySDK(options =>
{
    options.ClientId = "your-client-id";
    options.ApiKey   = "your-api-key";
    options.ApiUrl   = "https://api-sandbox.advancly.com/api/v2/client"; // sandbox (default)
    // options.ApiUrl = "https://api.advancly.com/api/v2/client";        // production
});
```

Then inject `IAdvanclySDK` wherever you need it:

```csharp
public class MyService
{
    private readonly IAdvanclySDK _sdk;

    public MyService(IAdvanclySDK sdk) => _sdk = sdk;
}
```

### Without dependency injection

```csharp
var sdk = new AdvanclySDK(Options.Create(new AdvanclySDKOptions
{
    ClientId = "your-client-id",
    ApiKey   = "your-api-key",
}));
```



## License

This project is licensed under the [MIT License](LICENSE).
