namespace P1Portfolio.Data.Dto;

using System;
using System.Collections.Generic;

public class PortfolioReportResponseDto
{
    public PortfolioReportDto Data { get; set; }
}

public class PortfolioReportDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string FirmId { get; set; }
    public string Currency { get; set; }
    public PaymentDto Payments { get; set; }
    public ChargeDto Charges { get; set; }
    public IncomeDto Income { get; set; }
    public TransferDto Transfers { get; set; }
    public InternalTransferDto InternalTransfers { get; set; }
    public PerformanceDto Performance { get; set; }
    public decimal OpeningValue { get; set; }
    public decimal ClosingValue { get; set; }
}

public class PaymentDto
{
    public List<TransactionDto> TransactionsIn { get; set; }
    public List<TransactionDto> TransactionsOut { get; set; }
    public decimal TotalIn { get; set; }
    public decimal TotalOut { get; set; }
}

public class ChargeDto
{
    public List<TransactionDto> Transactions { get; set; }
    public decimal Total { get; set; }
}

public class IncomeDto
{
    public List<TransactionDto> Transactions { get; set; }
    public decimal Total { get; set; }
}

public class TransferDto
{
    public List<TransactionDto> TransactionsIn { get; set; }
    public List<TransactionDto> TransactionsOut { get; set; }
    public decimal TotalIn { get; set; }
    public decimal TotalOut { get; set; }
}

public class InternalTransferDto
{
    public List<TransactionDto> TransactionsIn { get; set; }
    public List<TransactionDto> TransactionsOut { get; set; }
    public decimal TotalIn { get; set; }
    public decimal TotalOut { get; set; }
}

public class PerformanceDto
{
    public List<RealisedTransaction> TransactionsRealised { get; set; }
    public List<RetainedPosition> PositionsRetained { get; set; }
    public decimal TotalRealised { get; set; }
    public decimal TotalRetained { get; set; }
}

public class TransactionDto
{
    public string TransactionId { get; set; }
    public string TransactionCode { get; set; }
    public string Narrative { get; set; }
    public DateTime PostDate { get; set; }
    public DateTime ValueDate { get; set; }
    public decimal SubscriptionAmount { get; set; }
    public decimal Amount { get; set; }
}

public class RealisedTransaction
{
}

public class RetainedPosition
{
    public string Isin { get; set; }
    public string AssetName { get; set; }
    public decimal Quantity { get; set; }
    public decimal BookValue { get; set; }
    public decimal TransferBookValue { get; set; }
    public decimal NonTransferBookValue { get; set; }
    public decimal CurrentValue { get; set; }
    public decimal Growth { get; set; }
    public decimal AdjustedGrowth { get; set; }
}
