using AdvanclySDK;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public class PayoutTests
{
    private readonly IOptions<AdvanclySDKOptions> _options;
    private readonly AdvanclySDK.AdvanclySDK _sdk;

    public PayoutTests()
    {
        _options = Options.Create(new AdvanclySDKOptions
        {
            ClientId = "your-client-id",
            ApiKey = "your-api-key",
            ApiUrl = "https://api-sandbox.advancly.com/api/v2/client"
        });

        _sdk = new AdvanclySDK.AdvanclySDK(_options);
    }

    [Fact]
    public void AdvanclySDK_InitializesSuccessfully_WithValidOptions()
    {
        // Act
        var sdk = new AdvanclySDK.AdvanclySDK(_options);

        // Assert
        Assert.NotNull(sdk);
        Assert.NotNull(sdk.Payout);
    }

    [Fact]
    public async Task GetAccountDetails_ReturnsAccountList()
    {
        // Act
        var response = await _sdk.Payout.GetAccountDetailsAsync();

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
        Assert.All(response.Data, account =>
        {
            Assert.NotNull(account.AccountNumber);
            Assert.NotNull(account.AccountName);
            Assert.NotNull(account.CurrencyCode);
        });
    }

    [Fact]
    public async Task GetAccountDetails_ReturnsPrimaryAccount()
    {
        // Act
        var response = await _sdk.Payout.GetAccountDetailsAsync();

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.Contains(response.Data, account => account.IsPrimaryAccount);
    }

    [Fact]
    public async Task GetFinancialInstitutions_ReturnsInstitutionsList()
    {
        // Act
        var response = await _sdk.Payout.GetFinancialInstitutionsAsync();

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotEmpty(response.Data);
        Assert.All(response.Data, institution =>
        {
            Assert.NotNull(institution.BankCode);
            Assert.NotNull(institution.BankName);
        });
    }

    [Fact]
    public async Task GetNameEnquiry_WithValidAccountAndBankCode_ReturnsAccountName()
    {
        // Arrange
        var request = new NameEnquiryRequest
        {
            AccountNumber = "9038299384", // Replace with valid test account number from sandbox
            BankCode = "999461"
        };

        // Act
        var response = await _sdk.Payout.GetNameEnquiryAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.AccountNumber, response.Data.AccountNumber);
        Assert.NotNull(response.Data.AccountName);
        Assert.NotNull(response.Data.KycTier);
    }

    [Fact]
    public async Task GetNameEnquiry_WithInvalidAccountNumber_ThrowsException()
    {
        // Arrange
        var request = new NameEnquiryRequest
        {
            AccountNumber = "0000000000",
            BankCode = "999461"
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Payout.GetNameEnquiryAsync(request)
        );
    }

    [Fact]
    public async Task Payout_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new TransferRequest
        {
            SenderAccountNumber = "9038299384",    // Replace with valid test sender from sandbox
            RecipientAccountNumber = "7037662603", // Replace with valid test recipient from sandbox
            RecipientAccountName = "PAUL IKHIDE",
            RecipientBankCode = "999461",
            Amount = 100,
            Narration = "Test payout",
            Reference = $"Advancly-TEST-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 18).ToUpper()}"
        };

        // Act
        var response = await _sdk.Payout.PayoutAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.Equal("00", response.ResponseCode);
        Assert.NotNull(response.Data);
        Assert.Equal(request.SenderAccountNumber, response.Data.SenderAccountNumber);
        Assert.Equal(request.RecipientAccountNumber, response.Data.RecipientAccountNumber);
        Assert.Equal(request.Amount, response.Data.Amount);
        Assert.Equal("Completed", response.Data.TransactionStatus);
    }

    [Fact]
    public async Task Payout_WithDuplicateReference_ThrowsException()
    {
        // Arrange
        var request = new TransferRequest
        {
            SenderAccountNumber = "9038299384",
            RecipientAccountNumber = "7037662603",
            RecipientAccountName = "PAUL IKHIDE",
            RecipientBankCode = "999461",
            Amount = 100,
            Narration = "Test payout",
            Reference = "Advancly-DUPLICATE-REFERENCE-001" // Already used reference
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Payout.PayoutAsync(request)
        );
    }

    [Fact]
    public async Task Payout_WithInsufficientFunds_ThrowsException()
    {
        // Arrange
        var request = new TransferRequest
        {
            SenderAccountNumber = "9038299384",
            RecipientAccountNumber = "7037662603",
            RecipientAccountName = "PAUL IKHIDE",
            RecipientBankCode = "999461",
            Amount = 999999999,
            Narration = "Test payout",
            Reference = $"Advancly-TEST-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 18).ToUpper()}"
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Payout.PayoutAsync(request)
        );
    }

    [Fact]
    public async Task GetTransaction_WithValidReference_ReturnsTransactionDetails()
    {
        // Arrange
        var transactionReference = "Advancly-HAUUSIKSNJWUWJSN617288292814"; // Replace with valid reference from sandbox

        // Act
        var response = await _sdk.Payout.GetTransactionAsync(transactionReference);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(transactionReference, response.Data.ExternalReferenceNumber);
        Assert.NotNull(response.Data.TransactionStatus);
        Assert.NotNull(response.Data.SenderAccountNumber);
        Assert.NotNull(response.Data.RecipientAccountNumber);
        Assert.True(response.Data.Amount > 0);
    }

    [Fact]
    public async Task GetTransaction_WithInvalidReference_ThrowsException()
    {
        // Arrange
        var invalidReference = "Advancly-INVALID-REFERENCE-999999";

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Payout.GetTransactionAsync(invalidReference)
        );
    }

    [Fact]
    public async Task GetTransactions_WithValidParams_ReturnsPagedTransactions()
    {
        // Arrange
        var request = new GetTransactionsRequest
        {
            AccountNumber = "9038299384", // Replace with valid test account number from sandbox
            StartDate = "2025-03-15",
            EndDate = "2025-03-21",
            Page = 1,
            PageSize = 10
        };

        // Act
        var response = await _sdk.Payout.GetTransactionsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.Page, response.Page);
        Assert.Equal(request.PageSize, response.PageSize);
        Assert.True(response.TotalPages >= 1);
        Assert.True(response.TotalCount >= 0);
    }

    [Fact]
    public async Task GetTransactions_WithPagination_ReturnsCorrectPage()
    {
        // Arrange
        var request = new GetTransactionsRequest
        {
            AccountNumber = "9038299384", // Replace with valid test account number from sandbox
            StartDate = "2025-01-01",
            EndDate = "2025-12-31",
            Page = 2,
            PageSize = 5
        };

        // Act
        var response = await _sdk.Payout.GetTransactionsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.Equal(2, response.Page);
        Assert.Equal(5, response.PageSize);
    }

    [Fact]
    public async Task GetTransactions_WithInvalidAccountNumber_ThrowsException()
    {
        // Arrange
        var request = new GetTransactionsRequest
        {
            AccountNumber = "0000000000",
            StartDate = "2025-03-15",
            EndDate = "2025-03-21",
            Page = 1,
            PageSize = 10
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Payout.GetTransactionsAsync(request)
        );
    }
}
