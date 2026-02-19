using AdvanclySDK;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public class VirtualAccountTests
{
    private readonly IOptions<AdvanclySDKOptions> _options;
    private readonly AdvanclySDK.AdvanclySDK _sdk;

    public VirtualAccountTests()
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
        Assert.NotNull(sdk.VirtualAccount);
    }

    [Fact]
    public async Task CreateIndividualAccount_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new CreateIndividualAccountRequest
        {
            FirstName = "Emeka",
            LastName = "Okoro",
            Dob = "1979-08-12",
            Address = "75464 Lowell Lane",
            Gender = "Male",
            Phone = "09118310000",
            Email = "emeka.okoro@yopmail.com",
            Bvn = "28030300000"
        };

        // Act
        var response = await _sdk.VirtualAccount.CreateIndividualAccountAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotNull(response.Data.AccountNumber);
        Assert.NotNull(response.Data.AccountName);
    }

    [Fact]
    public async Task CreateIndividualAccount_WithMissingRequiredFields_ThrowsException()
    {
        // Arrange
        var request = new CreateIndividualAccountRequest
        {
            FirstName = "Emeka",
            // Missing required fields
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.VirtualAccount.CreateIndividualAccountAsync(request)
        );
    }

    [Fact]
    public async Task CreateCorporateAccount_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new CreateCorporateAccountRequest
        {
            RcNumber = "744500",
            BusinessName = "Schoen, Beier and Predovic",
            IncorporationDate = "1979-08-12",
            Address = "7199 Emilio Islands",
            Phone = "09118310000",
            Email = "contact@schoen.com",
            Bvn = "28030300000"
        };

        // Act
        var response = await _sdk.VirtualAccount.CreateCorporateAccountAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotNull(response.Data.AccountNumber);
        Assert.NotNull(response.Data.AccountName);
    }

    [Fact]
    public async Task CreateCorporateAccount_WithMissingRequiredFields_ThrowsException()
    {
        // Arrange
        var request = new CreateCorporateAccountRequest
        {
            BusinessName = "Schoen, Beier and Predovic",
            // Missing required fields
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.VirtualAccount.CreateCorporateAccountAsync(request)
        );
    }

    [Fact]
    public async Task GetAccountDetails_WithValidAccountNumber_ReturnsAccountDetails()
    {
        // Arrange
        var accountNumber = "0094714140"; // Replace with valid test account number from sandbox

        // Act
        var response = await _sdk.VirtualAccount.GetAccountDetailsAsync(accountNumber);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(accountNumber, response.Data.AccountNumber);
    }

    [Fact]
    public async Task GetAccountDetails_WithInvalidAccountNumber_ThrowsException()
    {
        // Arrange
        var invalidAccountNumber = "0000000000";

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.VirtualAccount.GetAccountDetailsAsync(invalidAccountNumber)
        );
    }

    [Fact]
    public async Task GetFinancialInstitutions_ReturnsInstitutionsList()
    {
        // Act
        var response = await _sdk.VirtualAccount.GetFinancialInstitutionsAsync();

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
        var response = await _sdk.VirtualAccount.GetNameEnquiryAsync(request);

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
            async () => await _sdk.VirtualAccount.GetNameEnquiryAsync(request)
        );
    }

    [Fact]
    public async Task Transfer_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new TransferRequest
        {
            SenderAccountNumber = "3996711153",  
            RecipientAccountNumber = "9038299384", 
            RecipientAccountName = "PAUL IKHIDE",
            RecipientBankCode = "999461",
            Amount = 100,
            Narration = "Glorious test battle",
            Reference = $"Advancly-{Guid.NewGuid().ToString().Substring(0, 8)}"
        };

        // Act
        var response = await _sdk.VirtualAccount.TransferAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.Equal("00", response.ResponseCode);
        Assert.NotNull(response.Data);
        Assert.Equal(request.SenderAccountNumber, response.Data.SenderAccountNumber);
        Assert.Equal(request.RecipientAccountNumber, response.Data.RecipientAccountNumber);
        Assert.Equal(request.Amount, response.Data.Amount);
        Assert.Equal("Success", response.Data.TransactionStatus);
    }

    [Fact]
    public async Task Transfer_WithDuplicateReference_ThrowsException()
    {
        // Arrange
        var request = new TransferRequest
        {
            SenderAccountNumber = "9038299384",
            RecipientAccountNumber = "7037662603",
            RecipientAccountName = "PAUL IKHIDE",
            RecipientBankCode = "999461",
            Amount = 100,
            Narration = "Test transfer",
            Reference = "Advancly-DUPLICATE-REFERENCE-001" // Already used reference
        };

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.VirtualAccount.TransferAsync(request)
        );
    }

   
    [Fact]
    public async Task GetTransaction_WithValidReference_ReturnsTransactionDetails()
    {
        // Arrange
        var transactionReference = "Advancly-e2f4g6h8"; 

        // Act
        var response = await _sdk.VirtualAccount.GetTransactionAsync(transactionReference);

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
            async () => await _sdk.VirtualAccount.GetTransactionAsync(invalidReference)
        );
    }

    [Fact]
    public async Task GetTransactions_WithValidParams_ReturnsPagedTransactions()
    {
        // Arrange
        var request = new GetTransactionsRequest
        {
            AccountNumber = "3996711153", 
            StartDate = "2025-03-15",
            EndDate = "2026-03-21",
            Page = 1,
            PageSize = 10
        };

        // Act
        var response = await _sdk.VirtualAccount.GetTransactionsAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.Page, response.Page);
        Assert.Equal(request.PageSize, response.PageSize);
    }

    [Fact]
    public async Task GetTransactions_WithPagination_ReturnsCorrectPage()
    {
        // Arrange
        var request = new GetTransactionsRequest
        {
            AccountNumber = "3996711153", // Replace with valid test account number from sandbox
            StartDate = "2025-01-01",
            EndDate = "2025-12-31",
            Page = 2,
            PageSize = 5
        };

        // Act
        var response = await _sdk.VirtualAccount.GetTransactionsAsync(request);

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
            async () => await _sdk.VirtualAccount.GetTransactionsAsync(request)
        );
    }
}
