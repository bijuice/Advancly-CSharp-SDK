using System.Text.Json.Serialization;

public class GetCustomerLoansResponse

{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("status_code")]
    public int StatusCode { get; set; }

    [JsonPropertyName("data")]
    public GetLoanDetailsData Data { get; set; }
}

public class GetLoanDetailsData
{
    [JsonPropertyName("customer")]
    public Customer Customer { get; set; }

    [JsonPropertyName("repayment_account")]
    public RepaymentAccount RepaymentAccount { get; set; }

    [JsonPropertyName("loan_details")]
    public LoanDetails LoanDetails { get; set; }

    [JsonPropertyName("repayments")]
    public List<object> Repayments { get; set; }

    [JsonPropertyName("repayment_schedule")]
    public RepaymentSchedule RepaymentSchedule { get; set; }
}

public class Customer
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("bank_name")]
    public string BankName { get; set; }

    [JsonPropertyName("bank_id")]
    public int BankId { get; set; }

    [JsonPropertyName("bank_account_number")]
    public string BankAccountNumber { get; set; }

    [JsonPropertyName("bank_account_name")]
    public string BankAccountName { get; set; }
}

public class RepaymentAccount
{
    [JsonPropertyName("customer_id")]
    public int CustomerId { get; set; }

    [JsonPropertyName("bank_name")]
    public string BankName { get; set; }

    [JsonPropertyName("bank_code")]
    public string BankCode { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("account_number")]
    public string AccountNumber { get; set; }

    [JsonPropertyName("account_name")]
    public string AccountName { get; set; }
}

public class LoanDetails
{
    [JsonPropertyName("loan_id")]
    public int LoanId { get; set; }

    [JsonPropertyName("decline_reason")]
    public string DeclineReason { get; set; }

    [JsonPropertyName("loan_interest_amount")]
    public decimal LoanInterestAmount { get; set; }

    [JsonPropertyName("loan_interest_rate")]
    public decimal LoanInterestRate { get; set; }

    [JsonPropertyName("loan_outstanding")]
    public decimal LoanOutstanding { get; set; }

    [JsonPropertyName("loan_due_date")]
    public DateTime LoanDueDate { get; set; }

    [JsonPropertyName("loan_status")]
    public string LoanStatus { get; set; }

    [JsonPropertyName("loan_status_code")]
    public int LoanStatusCode { get; set; }

    [JsonPropertyName("total_loan_collected")]
    public decimal TotalLoanCollected { get; set; }

    [JsonPropertyName("total_loan_repaid")]
    public decimal TotalLoanRepaid { get; set; }

    [JsonPropertyName("is_active")]
    public bool IsActive { get; set; }

    [JsonPropertyName("loan_tenure")]
    public int LoanTenure { get; set; }

    [JsonPropertyName("loan_amount")]
    public decimal LoanAmount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("loan_amount_repay")]
    public decimal LoanAmountRepay { get; set; }

    [JsonPropertyName("settlement_day")]
    public DateTime SettlementDay { get; set; }

    [JsonPropertyName("has_disburse")]
    public bool HasDisburse { get; set; }

    [JsonPropertyName("loan_repayment_balance")]
    public decimal LoanRepaymentBalance { get; set; }

    [JsonPropertyName("loan_ref")]
    public string LoanRef { get; set; }

    [JsonPropertyName("aggregator_loan_ref")]
    public string AggregatorLoanRef { get; set; }

    [JsonPropertyName("parent_rollover_loan_reference")]
    public string ParentRolloverLoanReference { get; set; }

    [JsonPropertyName("rollover_loan_reference")]
    public string RolloverLoanReference { get; set; }

    [JsonPropertyName("is_rollover")]
    public bool IsRollover { get; set; }

    [JsonPropertyName("can_rollover")]
    public bool CanRollover { get; set; }

    [JsonPropertyName("has_repaid")]
    public bool HasRepaid { get; set; }

    [JsonPropertyName("loan_transfer_status")]
    public string LoanTransferStatus { get; set; }

    [JsonPropertyName("loan_effective_date")]
    public DateTime LoanEffectiveDate { get; set; }

    [JsonPropertyName("pub_date")]
    public DateTime PubDate { get; set; }

    [JsonPropertyName("modified_date")]
    public DateTime ModifiedDate { get; set; }

    [JsonPropertyName("repayment_type")]
    public string RepaymentType { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}

public class RepaymentSchedule
{
    [JsonPropertyName("currency")]
    public Currency Currency { get; set; }

    [JsonPropertyName("loanTermInDays")]
    public int LoanTermInDays { get; set; }

    [JsonPropertyName("totalPrincipalDisbursed")]
    public decimal TotalPrincipalDisbursed { get; set; }

    [JsonPropertyName("totalPrincipalExpected")]
    public decimal TotalPrincipalExpected { get; set; }

    [JsonPropertyName("totalPrincipalPaid")]
    public decimal TotalPrincipalPaid { get; set; }

    [JsonPropertyName("totalInterestCharged")]
    public decimal TotalInterestCharged { get; set; }

    [JsonPropertyName("totalFeeChargesCharged")]
    public decimal TotalFeeChargesCharged { get; set; }

    [JsonPropertyName("totalPenaltyChargesCharged")]
    public decimal TotalPenaltyChargesCharged { get; set; }

    [JsonPropertyName("totalWaived")]
    public decimal TotalWaived { get; set; }

    [JsonPropertyName("totalWrittenOff")]
    public decimal TotalWrittenOff { get; set; }

    [JsonPropertyName("totalRepaymentExpected")]
    public decimal TotalRepaymentExpected { get; set; }

    [JsonPropertyName("totalRepayment")]
    public decimal TotalRepayment { get; set; }

    [JsonPropertyName("totalPaidInAdvance")]
    public decimal TotalPaidInAdvance { get; set; }

    [JsonPropertyName("totalPaidLate")]
    public decimal TotalPaidLate { get; set; }

    [JsonPropertyName("totalOutstanding")]
    public decimal TotalOutstanding { get; set; }

    [JsonPropertyName("periods")]
    public List<RepaymentPeriod> Periods { get; set; }
}

public class Currency
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("decimalPlaces")]
    public int DecimalPlaces { get; set; }

    [JsonPropertyName("inMultiplesOf")]
    public int InMultiplesOf { get; set; }

    [JsonPropertyName("displaySymbol")]
    public string DisplaySymbol { get; set; }

    [JsonPropertyName("nameCode")]
    public string NameCode { get; set; }

    [JsonPropertyName("displayLabel")]
    public string DisplayLabel { get; set; }
}

public class RepaymentPeriod
{
    [JsonPropertyName("dueDate")]
    public List<int> DueDate { get; set; }

    [JsonPropertyName("principalDisbursed")]
    public decimal PrincipalDisbursed { get; set; }

    [JsonPropertyName("principalLoanBalanceOutstanding")]
    public decimal PrincipalLoanBalanceOutstanding { get; set; }

    [JsonPropertyName("feeChargesDue")]
    public decimal FeeChargesDue { get; set; }

    [JsonPropertyName("feeChargesPaid")]
    public decimal FeeChargesPaid { get; set; }

    [JsonPropertyName("totalOriginalDueForPeriod")]
    public decimal TotalOriginalDueForPeriod { get; set; }

    [JsonPropertyName("totalDueForPeriod")]
    public decimal TotalDueForPeriod { get; set; }

    [JsonPropertyName("totalPaidForPeriod")]
    public decimal TotalPaidForPeriod { get; set; }

    [JsonPropertyName("totalActualCostOfLoanForPeriod")]
    public decimal TotalActualCostOfLoanForPeriod { get; set; }

    [JsonPropertyName("period")]
    public int Period { get; set; }

    [JsonPropertyName("fromDate")]
    public List<int> FromDate { get; set; }

    [JsonPropertyName("obligationsMetOnDate")]
    public List<int> ObligationsMetOnDate { get; set; }

    [JsonPropertyName("complete")]
    public bool Complete { get; set; }

    [JsonPropertyName("daysInPeriod")]
    public int DaysInPeriod { get; set; }

    [JsonPropertyName("principalOriginalDue")]
    public decimal PrincipalOriginalDue { get; set; }

    [JsonPropertyName("principalDue")]
    public decimal PrincipalDue { get; set; }

    [JsonPropertyName("principalPaid")]
    public decimal PrincipalPaid { get; set; }

    [JsonPropertyName("principalWrittenOff")]
    public decimal PrincipalWrittenOff { get; set; }

    [JsonPropertyName("principalOutstanding")]
    public decimal PrincipalOutstanding { get; set; }

    [JsonPropertyName("interestOriginalDue")]
    public decimal InterestOriginalDue { get; set; }

    [JsonPropertyName("interestDue")]
    public decimal InterestDue { get; set; }

    [JsonPropertyName("interestPaid")]
    public decimal InterestPaid { get; set; }

    [JsonPropertyName("interestWaived")]
    public decimal InterestWaived { get; set; }

    [JsonPropertyName("interestWrittenOff")]
    public decimal InterestWrittenOff { get; set; }

    [JsonPropertyName("interestOutstanding")]
    public decimal InterestOutstanding { get; set; }

    [JsonPropertyName("feeChargesWaived")]
    public decimal FeeChargesWaived { get; set; }

    [JsonPropertyName("feeChargesWrittenOff")]
    public decimal FeeChargesWrittenOff { get; set; }

    [JsonPropertyName("feeChargesOutstanding")]
    public decimal FeeChargesOutstanding { get; set; }

    [JsonPropertyName("penaltyChargesDue")]
    public decimal PenaltyChargesDue { get; set; }

    [JsonPropertyName("penaltyChargesPaid")]
    public decimal PenaltyChargesPaid { get; set; }

    [JsonPropertyName("penaltyChargesWaived")]
    public decimal PenaltyChargesWaived { get; set; }

    [JsonPropertyName("penaltyChargesWrittenOff")]
    public decimal PenaltyChargesWrittenOff { get; set; }

    [JsonPropertyName("penaltyChargesOutstanding")]
    public decimal PenaltyChargesOutstanding { get; set; }

    [JsonPropertyName("totalPaidInAdvanceForPeriod")]
    public decimal TotalPaidInAdvanceForPeriod { get; set; }

    [JsonPropertyName("totalPaidLateForPeriod")]
    public decimal TotalPaidLateForPeriod { get; set; }

    [JsonPropertyName("totalWaivedForPeriod")]
    public decimal TotalWaivedForPeriod { get; set; }

    [JsonPropertyName("totalWrittenOffForPeriod")]
    public decimal TotalWrittenOffForPeriod { get; set; }

    [JsonPropertyName("totalOutstandingForPeriod")]
    public decimal TotalOutstandingForPeriod { get; set; }

    [JsonPropertyName("totalInstallmentAmountForPeriod")]
    public decimal TotalInstallmentAmountForPeriod { get; set; }
}
