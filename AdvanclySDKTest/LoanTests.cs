using AdvanclySDK;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AdvanclySDKTest;

public class LoanTests
{
    private readonly IOptions<AdvanclySDKOptions> _options;
    private readonly AdvanclySDK.AdvanclySDK _sdk;

    public LoanTests()
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
        Assert.NotNull(sdk.Loans);
    }

    [Fact]
    public async Task InitiateLoanApplication_WithValidData_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new InitiateLoanApplicationRequest
        {
            LastName = "Doe",
            FirstName = "John",
            IdentityNumber = "12345678901",
            PhotoUrl = "https://example.com/photo.jpg",
            Gender = "male",
            PhoneNumber = "+2348012345678",
            Email = "johndoe@example.com",
            BorrowerType = 1, 
            DateOfBirth = "1990-01-01",
            State = "Lagos",
            City = "Lagos",
            ResidenceAddress = "123 Test Street, Lagos",
            CountryCode = "NG",
            SectorCode = "001",
            ProductId = 1,
            AggregatorLoanRef = $"TEST-{Guid.NewGuid().ToString().Substring(0, 8)}",
            BankCode = "058",
            BankAccountNum = "1234567890",
            BankAccountName = "Abbey Mortgage Bank",
            CreateWallet = false,
            CustomerCategory = "Salary Earner",
            LoanPurpose = "Business Expansion",
            AnnualInterestRate = "15.5",
            LoanAmount = 50000,
            LoanTenure = 30
        };

        // Act
        var response = await _sdk.Loans.InitiateLoanApplicationAsync<dynamic>(request);

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetCustomerLoans_WithValidCustomerId_ReturnsLoans()
    {
        // Arrange
        var customerId = "test-customer-123"; // Replace with valid test customer ID from sandbox

        // Act
        var response = await _sdk.Loans.GetCustomerLoansAsync(customerId);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
    }

    [Fact]
    public async Task GetLoanDetails_WithValidLoanRefNo_ReturnsLoanDetails()
    {
        // Arrange
        var loanRefNo = "LN-TEST-001"; // Replace with valid test loan reference from sandbox

        // Act
        var response = await _sdk.Loans.GetLoanDetailsAsync<LoanDetailsResponse>(loanRefNo);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.NotNull(response.Data.LoanDetails);
        Assert.Equal(loanRefNo, response.Data.LoanDetails.LoanRef);
    }

    [Fact]
    public async Task InitiateRepayment_WithValidData_ReturnsRepaymentResponse()
    {
        // Arrange
        var request = new InitiateRepaymentRequest
        {
            LoanRefNo = "LN-TEST-001", // Replace with valid test loan reference from sandbox
            Amount = 10000
        };

        // Act
        var response = await _sdk.Loans.InitiateRepaymentAsync(request);

        // Assert
        Assert.NotNull(response);
        Assert.True(response.Status);
        Assert.NotNull(response.Data);
        Assert.Equal(request.LoanRefNo, response.Data.LoanRef);
        Assert.Equal(request.Amount, response.Data.Amount);
    }

    [Fact]
    public async Task GenerateLoanSchedule_WithValidData_ReturnsSchedule()
    {
        // Arrange
        var request = new GenerateLoanScheduleRequest
        {
            ProductId = 1,
            LoanTenor = 12,
            PrincipalAmount = 100000,
            Interest = 15.5m,
            LoanEffectiveDate = "2026-03-01"
        };

        // Act
        var response = await _sdk.Loans.GenerateLoanScheduleAsync<dynamic>(request);

        // Assert
        Assert.NotNull(response);
        // Add more specific assertions based on your API response structure
    }

    [Fact]
    public async Task RequestLoan_WithValidData_ReturnsLoanResponse()
    {
        // Arrange
        var request = new RequestLoanRequest
        {
            IdentityNumber = "12345678901",
            CountryCode = "NG",
            ProductId = 1,
            LoanAmount = 50000,
            LoanTenure = 6,
            AnnualInterestRate = "15.5",
            LoanPurpose = "Business Expansion",
            UseCustomerWallet = false
        };

        // Act
        var response = await _sdk.Loans.RequestLoanAsync<dynamic>(request);

        // Assert
        Assert.NotNull(response);
        // Add more specific assertions based on your API response structure
    }

    [Fact]
    public async Task InitiateLoanApplication_WithCorporateBorrower_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new InitiateLoanApplicationRequest
        {
            LastName = "Smith",
            FirstName = "Jane",
            CompanyName = "Test Corp Ltd",
            IdentityNumber = "98765432109",
            PhotoUrl = "https://example.com/photo.jpg",
            Gender = "female",
            PhoneNumber = "+2348087654321",
            Email = "jane.smith@testcorp.com",
            BorrowerType = 2, // Corporate
            DateOfBirth = "1985-05-15",
            State = "Lagos",
            City = "Lagos",
            ResidenceAddress = "456 Corporate Avenue, Lagos",
            CompanyCity = "Lagos",
            CompanyAddress = "456 Corporate Avenue, Lagos",
            CompanyState = "Lagos",
            RegistrationNumber = "RC123456",
            CountryCode = "NG",
            SectorCode = "002",
            ProductId = 1,
            AggregatorLoanRef = $"TEST-CORP-{Guid.NewGuid().ToString().Substring(0, 8)}",
            BankCode = "058",
            BankAccountNum = "9876543210",
            BankAccountName = "Test Corp Ltd",
            CreateWallet = false,
            CustomerCategory = "Business Owner",
            LoanPurpose = "Working Capital",
            AnnualInterestRate = "18.0",
            LoanAmount = 500000,
            LoanTenure = 12
        };

        // Act
        var response = await _sdk.Loans.InitiateLoanApplicationAsync<dynamic>(request);

        // Assert
        Assert.NotNull(response);
    }

    [Fact]
    public async Task GetCustomerLoans_WithInvalidCustomerId_ThrowsException()
    {
        // Arrange
        var invalidCustomerId = "invalid-customer-999999";

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Loans.GetCustomerLoansAsync(invalidCustomerId)
        );
    }

    [Fact]
    public async Task GetLoanDetails_WithInvalidLoanRefNo_ThrowsException()
    {
        // Arrange
        var invalidLoanRefNo = "INVALID-LOAN-999999";

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(
            async () => await _sdk.Loans.GetLoanDetailsAsync<LoanDetailsResponse>(invalidLoanRefNo)
        );
    }
}