using System.Text.Json.Serialization;

namespace AdvanclySDK;

/// <summary>
/// Response model for retrieving all loans belonging to a specific customer.
/// GET /api/v2/client/loans/borrower/{customer_id}
/// </summary>
public class GetCustomerLoansResponse
{
    /// <summary>
    /// A descriptive message about the response.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Indicates whether the request was successful.
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }

    /// <summary>
    /// The HTTP status code of the response.
    /// </summary>
    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }

    /// <summary>
    /// The loan data payload for the customer.
    /// </summary>
    [JsonPropertyName("data")]
    public GetLoanDetailsData Data { get; set; }
}

/// <summary>
/// Data payload containing a customer's loan information.
/// </summary>
public class GetLoanDetailsData
{
    /// <summary>
    /// Information about the borrower.
    /// </summary>
    [JsonPropertyName("customer")]
    public LoanCustomer Customer { get; set; }

    /// <summary>
    /// The repayment account associated with the loan.
    /// </summary>
    [JsonPropertyName("repayment_account")]
    public RepaymentAccount RepaymentAccount { get; set; }

    /// <summary>
    /// The core details of the loan.
    /// </summary>
    [JsonPropertyName("loan_details")]
    public LoanDetails LoanDetails { get; set; }

    /// <summary>
    /// A list of recorded repayments made against the loan.
    /// </summary>
    [JsonPropertyName("repayments")]
    public List<object> Repayments { get; set; }

    /// <summary>
    /// The repayment schedule for the loan.
    /// </summary>
    [JsonPropertyName("repayment_schedule")]
    public RepaymentSchedule RepaymentSchedule { get; set; }
}

/// <summary>
/// Borrower information associated with a loan.
/// </summary>
public class LoanCustomer
{
    /// <summary>
    /// The unique identifier of the customer.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// The first name of the customer.
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// The last name of the customer.
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// The phone number of the customer.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The name of the customer's bank.
    /// </summary>
    [JsonPropertyName("bank_name")]
    public string BankName { get; set; }

    /// <summary>
    /// The identifier of the customer's bank.
    /// </summary>
    [JsonPropertyName("bank_id")]
    public int BankId { get; set; }

    /// <summary>
    /// The customer's bank account number.
    /// </summary>
    [JsonPropertyName("bank_account_number")]
    public string BankAccountNumber { get; set; }

    /// <summary>
    /// The customer's bank account name.
    /// </summary>
    [JsonPropertyName("bank_account_name")]
    public string BankAccountName { get; set; }
}

/// <summary>
/// The bank account used for loan repayment.
/// </summary>
public class RepaymentAccount
{
    /// <summary>
    /// The unique identifier of the customer who owns this repayment account.
    /// </summary>
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; set; }

    /// <summary>
    /// The name of the repayment bank.
    /// </summary>
    [JsonPropertyName("bank_name")]
    public string BankName { get; set; }

    /// <summary>
    /// The code of the repayment bank.
    /// </summary>
    [JsonPropertyName("bank_code")]
    public string BankCode { get; set; }

    /// <summary>
    /// The currency of the repayment account.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// The repayment account number.
    /// </summary>
    [JsonPropertyName("account_number")]
    public string AccountNumber { get; set; }

    /// <summary>
    /// The name on the repayment account.
    /// </summary>
    [JsonPropertyName("account_name")]
    public string AccountName { get; set; }
}

/// <summary>
/// Detailed information about a customer's loan.
/// </summary>
public class LoanDetails
{
    /// <summary>
    /// The unique identifier of the loan.
    /// </summary>
    [JsonPropertyName("loan_id")]
    public int LoanId { get; set; }

    /// <summary>
    /// The reason the loan was declined, if applicable.
    /// </summary>
    [JsonPropertyName("decline_reason")]
    public string DeclineReason { get; set; }

    /// <summary>
    /// The total interest amount charged on the loan.
    /// </summary>
    [JsonPropertyName("loan_interest_amount")]
    public decimal LoanInterestAmount { get; set; }

    /// <summary>
    /// The interest rate applied to the loan.
    /// </summary>
    [JsonPropertyName("loan_interest_rate")]
    public decimal LoanInterestRate { get; set; }

    /// <summary>
    /// The outstanding balance remaining on the loan.
    /// </summary>
    [JsonPropertyName("loan_outstanding")]
    public decimal LoanOutstanding { get; set; }

    /// <summary>
    /// The due date by which the loan must be fully repaid.
    /// </summary>
    [JsonPropertyName("loan_due_date")]
    public DateTime LoanDueDate { get; set; }

    /// <summary>
    /// The human-readable status of the loan.
    /// </summary>
    [JsonPropertyName("loan_status")]
    public string LoanStatus { get; set; }

    /// <summary>
    /// The numeric status code of the loan. See Loan Status for meanings.
    /// </summary>
    [JsonPropertyName("loan_status_code")]
    public int LoanStatusCode { get; set; }

    /// <summary>
    /// The total principal amount disbursed to the borrower across all loans.
    /// </summary>
    [JsonPropertyName("total_loan_collected")]
    public decimal TotalLoanCollected { get; set; }

    /// <summary>
    /// The total amount repaid by the borrower.
    /// </summary>
    [JsonPropertyName("total_loan_repaid")]
    public decimal TotalLoanRepaid { get; set; }

    /// <summary>
    /// Indicates whether the loan is currently active.
    /// </summary>
    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// The duration of the loan in months.
    /// </summary>
    [JsonPropertyName("loan_tenure")]
    public int LoanTenure { get; set; }

    /// <summary>
    /// The original principal amount of the loan.
    /// </summary>
    [JsonPropertyName("loan_amount")]
    public decimal LoanAmount { get; set; }

    /// <summary>
    /// The currency of the loan.
    /// </summary>
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// The total amount (principal + interest) required to fully repay the loan.
    /// </summary>
    [JsonPropertyName("loan_amount_repay")]
    public decimal LoanAmountRepay { get; set; }

    /// <summary>
    /// The scheduled settlement date of the loan.
    /// </summary>
    [JsonPropertyName("settlement_day")]
    public DateTime SettlementDay { get; set; }

    /// <summary>
    /// Indicates whether the loan has been disbursed.
    /// </summary>
    [JsonPropertyName("has_disburse")]
    public bool HasDisburse { get; set; }

    /// <summary>
    /// The remaining repayment balance on the loan.
    /// </summary>
    [JsonPropertyName("loan_repayment_balance")]
    public decimal LoanRepaymentBalance { get; set; }

    /// <summary>
    /// The unique reference number of the loan generated by Advancly.
    /// </summary>
    [JsonPropertyName("loan_ref")]
    public string LoanRef { get; set; }

    /// <summary>
    /// The unique loan reference generated by the aggregator/client.
    /// </summary>
    [JsonPropertyName("aggregator_loan_ref")]
    public string AggregatorLoanRef { get; set; }

    /// <summary>
    /// The reference of the parent loan from which this loan was rolled over, if applicable.
    /// </summary>
    [JsonPropertyName("parent_rollover_loan_reference")]
    public string ParentRolloverLoanReference { get; set; }

    /// <summary>
    /// The reference of the new loan created after a rollover, if applicable.
    /// </summary>
    [JsonPropertyName("rollover_loan_reference")]
    public string RolloverLoanReference { get; set; }

    /// <summary>
    /// Indicates whether this loan is a rollover of a previous loan.
    /// </summary>
    [JsonPropertyName("is_rollover")]
    public bool IsRollover { get; set; }

    /// <summary>
    /// Indicates whether this loan is eligible for rollover.
    /// </summary>
    [JsonPropertyName("can_rollover")]
    public bool CanRollover { get; set; }

    /// <summary>
    /// Indicates whether the loan has been fully repaid.
    /// </summary>
    [JsonPropertyName("has_repaid")]
    public bool HasRepaid { get; set; }

    /// <summary>
    /// The transfer status of the loan disbursement.
    /// </summary>
    [JsonPropertyName("loan_transfer_status")]
    public string LoanTransferStatus { get; set; }

    /// <summary>
    /// The date on which the loan became effective.
    /// </summary>
    [JsonPropertyName("loan_effective_date")]
    public DateTime LoanEffectiveDate { get; set; }

    /// <summary>
    /// The date the loan record was published/created.
    /// </summary>
    [JsonPropertyName("pub_date")]
    public DateTime PubDate { get; set; }

    /// <summary>
    /// The date the loan record was last modified.
    /// </summary>
    [JsonPropertyName("modified_date")]
    public DateTime ModifiedDate { get; set; }

    /// <summary>
    /// The repayment type of the loan (e.g. monthly, weekly).
    /// </summary>
    [JsonPropertyName("repayment_type")]
    public string RepaymentType { get; set; }

    /// <summary>
    /// The current status of the loan.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}

/// <summary>
/// Aggregate repayment schedule information for a loan.
/// </summary>
public class RepaymentSchedule
{
    /// <summary>
    /// The currency details for the repayment schedule.
    /// </summary>
    [JsonPropertyName("currency")]
    public LoanCurrency Currency { get; set; }

    /// <summary>
    /// The total term of the loan expressed in days.
    /// </summary>
    [JsonPropertyName("loanTermInDays")]
    public int LoanTermInDays { get; set; }

    /// <summary>
    /// The total principal amount that has been disbursed.
    /// </summary>
    [JsonPropertyName("totalPrincipalDisbursed")]
    public decimal TotalPrincipalDisbursed { get; set; }

    /// <summary>
    /// The total principal amount expected to be repaid.
    /// </summary>
    [JsonPropertyName("totalPrincipalExpected")]
    public decimal TotalPrincipalExpected { get; set; }

    /// <summary>
    /// The total principal amount paid to date.
    /// </summary>
    [JsonPropertyName("totalPrincipalPaid")]
    public decimal TotalPrincipalPaid { get; set; }

    /// <summary>
    /// The total interest amount charged on the loan.
    /// </summary>
    [JsonPropertyName("totalInterestCharged")]
    public decimal TotalInterestCharged { get; set; }

    /// <summary>
    /// The total fee charges applied to the loan.
    /// </summary>
    [JsonPropertyName("totalFeeChargesCharged")]
    public decimal TotalFeeChargesCharged { get; set; }

    /// <summary>
    /// The total penalty charges applied to the loan.
    /// </summary>
    [JsonPropertyName("totalPenaltyChargesCharged")]
    public decimal TotalPenaltyChargesCharged { get; set; }

    /// <summary>
    /// The total amount waived on the loan.
    /// </summary>
    [JsonPropertyName("totalWaived")]
    public decimal TotalWaived { get; set; }

    /// <summary>
    /// The total amount written off on the loan.
    /// </summary>
    [JsonPropertyName("totalWrittenOff")]
    public decimal TotalWrittenOff { get; set; }

    /// <summary>
    /// The total repayment amount expected (principal + interest + fees).
    /// </summary>
    [JsonPropertyName("totalRepaymentExpected")]
    public decimal TotalRepaymentExpected { get; set; }

    /// <summary>
    /// The total amount repaid to date.
    /// </summary>
    [JsonPropertyName("totalRepayment")]
    public decimal TotalRepayment { get; set; }

    /// <summary>
    /// The total amount paid in advance.
    /// </summary>
    [JsonPropertyName("totalPaidInAdvance")]
    public decimal TotalPaidInAdvance { get; set; }

    /// <summary>
    /// The total amount paid late.
    /// </summary>
    [JsonPropertyName("totalPaidLate")]
    public decimal TotalPaidLate { get; set; }

    /// <summary>
    /// The total outstanding balance remaining on the loan.
    /// </summary>
    [JsonPropertyName("totalOutstanding")]
    public decimal TotalOutstanding { get; set; }

    /// <summary>
    /// The individual repayment periods that make up the schedule.
    /// </summary>
    [JsonPropertyName("periods")]
    public List<RepaymentPeriod> Periods { get; set; }
}

/// <summary>
/// Currency information used in loan and repayment schedule responses.
/// </summary>
public class LoanCurrency
{
    /// <summary>
    /// The ISO currency code, e.g. "NGN", "GHS".
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }

    /// <summary>
    /// The full name of the currency.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// The number of decimal places used by the currency.
    /// </summary>
    [JsonPropertyName("decimalPlaces")]
    public int DecimalPlaces { get; set; }

    /// <summary>
    /// The smallest unit multiple supported by the currency.
    /// </summary>
    [JsonPropertyName("inMultiplesOf")]
    public int InMultiplesOf { get; set; }

    /// <summary>
    /// The display symbol for the currency, e.g. "₦".
    /// </summary>
    [JsonPropertyName("displaySymbol")]
    public string DisplaySymbol { get; set; }

    /// <summary>
    /// The localisation name code for the currency.
    /// </summary>
    [JsonPropertyName("nameCode")]
    public string NameCode { get; set; }

    /// <summary>
    /// A human-readable display label for the currency.
    /// </summary>
    [JsonPropertyName("displayLabel")]
    public string DisplayLabel { get; set; }
}

/// <summary>
/// Represents a single period within a loan's repayment schedule.
/// </summary>
public class RepaymentPeriod
{
    /// <summary>
    /// The due date of this repayment period as a date component array [year, month, day].
    /// </summary>
    [JsonPropertyName("dueDate")]
    public List<int> DueDate { get; set; }

    /// <summary>
    /// The principal disbursed during this period.
    /// </summary>
    [JsonPropertyName("principalDisbursed")]
    public decimal PrincipalDisbursed { get; set; }

    /// <summary>
    /// The outstanding principal loan balance at the end of this period.
    /// </summary>
    [JsonPropertyName("principalLoanBalanceOutstanding")]
    public decimal PrincipalLoanBalanceOutstanding { get; set; }

    /// <summary>
    /// The fee charges due in this period.
    /// </summary>
    [JsonPropertyName("feeChargesDue")]
    public decimal FeeChargesDue { get; set; }

    /// <summary>
    /// The fee charges paid in this period.
    /// </summary>
    [JsonPropertyName("feeChargesPaid")]
    public decimal FeeChargesPaid { get; set; }

    /// <summary>
    /// The original total amount due for this period before any adjustments.
    /// </summary>
    [JsonPropertyName("totalOriginalDueForPeriod")]
    public decimal TotalOriginalDueForPeriod { get; set; }

    /// <summary>
    /// The total amount due for this period.
    /// </summary>
    [JsonPropertyName("totalDueForPeriod")]
    public decimal TotalDueForPeriod { get; set; }

    /// <summary>
    /// The total amount paid in this period.
    /// </summary>
    [JsonPropertyName("totalPaidForPeriod")]
    public decimal TotalPaidForPeriod { get; set; }

    /// <summary>
    /// The total actual cost of the loan for this period.
    /// </summary>
    [JsonPropertyName("totalActualCostOfLoanForPeriod")]
    public decimal TotalActualCostOfLoanForPeriod { get; set; }

    /// <summary>
    /// The sequential period number within the repayment schedule.
    /// </summary>
    [JsonPropertyName("period")]
    public int Period { get; set; }

    /// <summary>
    /// The start date of this period as a date component array [year, month, day].
    /// </summary>
    [JsonPropertyName("fromDate")]
    public List<int> FromDate { get; set; }

    /// <summary>
    /// The date on which obligations were met for this period, as a date component array [year, month, day].
    /// </summary>
    [JsonPropertyName("obligationsMetOnDate")]
    public List<int> ObligationsMetOnDate { get; set; }

    /// <summary>
    /// Indicates whether this period has been fully completed.
    /// </summary>
    [JsonPropertyName("complete")]
    public bool Complete { get; set; }

    /// <summary>
    /// The number of days in this repayment period.
    /// </summary>
    [JsonPropertyName("daysInPeriod")]
    public int DaysInPeriod { get; set; }

    /// <summary>
    /// The original principal amount due in this period before any adjustments.
    /// </summary>
    [JsonPropertyName("principalOriginalDue")]
    public decimal PrincipalOriginalDue { get; set; }

    /// <summary>
    /// The principal amount due in this period.
    /// </summary>
    [JsonPropertyName("principalDue")]
    public decimal PrincipalDue { get; set; }

    /// <summary>
    /// The principal amount paid in this period.
    /// </summary>
    [JsonPropertyName("principalPaid")]
    public decimal PrincipalPaid { get; set; }

    /// <summary>
    /// The principal amount written off in this period.
    /// </summary>
    [JsonPropertyName("principalWrittenOff")]
    public decimal PrincipalWrittenOff { get; set; }

    /// <summary>
    /// The outstanding principal balance for this period.
    /// </summary>
    [JsonPropertyName("principalOutstanding")]
    public decimal PrincipalOutstanding { get; set; }

    /// <summary>
    /// The original interest amount due in this period.
    /// </summary>
    [JsonPropertyName("interestOriginalDue")]
    public decimal InterestOriginalDue { get; set; }

    /// <summary>
    /// The interest amount due in this period.
    /// </summary>
    [JsonPropertyName("interestDue")]
    public decimal InterestDue { get; set; }

    /// <summary>
    /// The interest amount paid in this period.
    /// </summary>
    [JsonPropertyName("interestPaid")]
    public decimal InterestPaid { get; set; }

    /// <summary>
    /// The interest amount waived in this period.
    /// </summary>
    [JsonPropertyName("interestWaived")]
    public decimal InterestWaived { get; set; }

    /// <summary>
    /// The interest amount written off in this period.
    /// </summary>
    [JsonPropertyName("interestWrittenOff")]
    public decimal InterestWrittenOff { get; set; }

    /// <summary>
    /// The outstanding interest balance for this period.
    /// </summary>
    [JsonPropertyName("interestOutstanding")]
    public decimal InterestOutstanding { get; set; }

    /// <summary>
    /// The fee charges waived in this period.
    /// </summary>
    [JsonPropertyName("feeChargesWaived")]
    public decimal FeeChargesWaived { get; set; }

    /// <summary>
    /// The fee charges written off in this period.
    /// </summary>
    [JsonPropertyName("feeChargesWrittenOff")]
    public decimal FeeChargesWrittenOff { get; set; }

    /// <summary>
    /// The outstanding fee charges for this period.
    /// </summary>
    [JsonPropertyName("feeChargesOutstanding")]
    public decimal FeeChargesOutstanding { get; set; }

    /// <summary>
    /// The penalty charges due in this period.
    /// </summary>
    [JsonPropertyName("penaltyChargesDue")]
    public decimal PenaltyChargesDue { get; set; }

    /// <summary>
    /// The penalty charges paid in this period.
    /// </summary>
    [JsonPropertyName("penaltyChargesPaid")]
    public decimal PenaltyChargesPaid { get; set; }

    /// <summary>
    /// The penalty charges waived in this period.
    /// </summary>
    [JsonPropertyName("penaltyChargesWaived")]
    public decimal PenaltyChargesWaived { get; set; }

    /// <summary>
    /// The penalty charges written off in this period.
    /// </summary>
    [JsonPropertyName("penaltyChargesWrittenOff")]
    public decimal PenaltyChargesWrittenOff { get; set; }

    /// <summary>
    /// The outstanding penalty charges for this period.
    /// </summary>
    [JsonPropertyName("penaltyChargesOutstanding")]
    public decimal PenaltyChargesOutstanding { get; set; }

    /// <summary>
    /// The amount paid in advance during this period.
    /// </summary>
    [JsonPropertyName("totalPaidInAdvanceForPeriod")]
    public decimal TotalPaidInAdvanceForPeriod { get; set; }

    /// <summary>
    /// The amount paid late during this period.
    /// </summary>
    [JsonPropertyName("totalPaidLateForPeriod")]
    public decimal TotalPaidLateForPeriod { get; set; }

    /// <summary>
    /// The total amount waived during this period.
    /// </summary>
    [JsonPropertyName("totalWaivedForPeriod")]
    public decimal TotalWaivedForPeriod { get; set; }

    /// <summary>
    /// The total amount written off during this period.
    /// </summary>
    [JsonPropertyName("totalWrittenOffForPeriod")]
    public decimal TotalWrittenOffForPeriod { get; set; }

    /// <summary>
    /// The total outstanding balance for this period.
    /// </summary>
    [JsonPropertyName("totalOutstandingForPeriod")]
    public decimal TotalOutstandingForPeriod { get; set; }

    /// <summary>
    /// The total installment amount due for this period.
    /// </summary>
    [JsonPropertyName("totalInstallmentAmountForPeriod")]
    public decimal TotalInstallmentAmountForPeriod { get; set; }
}
