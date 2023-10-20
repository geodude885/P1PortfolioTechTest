using P1Portfolio.Data.Dto;

namespace P1Portfolio.Data.ViewModel
{
	public class PortfolioReportsViewModel
	{

		public DateTime? ReportsFromDate { get; set; } = null;
		public DateTime? ReportsToDate { get; set; } = null;

		public List<PortfolioReportDto> Reports { get; set; } = new();

		public bool isLoading = false;

        public long PaymentCount
        {
            get => Reports.Aggregate(0, (total, next) => total + 
			next.Payments.TransactionsIn.Count + next.Payments.TransactionsOut.Count);
        }
        public decimal PaymentsInTotal
		{
			get => Reports.SelectMany(r => r.Payments.TransactionsIn)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}

		public decimal PaymentsOutTotal
		{
			get => Reports.SelectMany(r => r.Payments.TransactionsOut)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}
        public decimal TransfersCount
        {
            get => Reports.Aggregate(0, (total, next) => total +
            next.Transfers.TransactionsIn.Count + next.Transfers.TransactionsOut.Count);
        }

        public decimal TransfersInTotal
		{
			get => Reports.SelectMany(r => r.Transfers.TransactionsIn)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}

		public decimal TransfersOutTotal
		{
			get => Reports.SelectMany(r => r.Transfers.TransactionsOut)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}

        public decimal InternalTransfersCount
        {
            get => Reports.Aggregate(0, (total, next) => total +
            next.InternalTransfers.TransactionsIn.Count + next.InternalTransfers.TransactionsOut.Count);
        }
        public decimal InternalTransfersInTotal
		{
			get => Reports.SelectMany(r => r.InternalTransfers.TransactionsIn)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}
		public decimal InternalTransfersOutTotal
		{
			get => Reports.SelectMany(r => r.InternalTransfers.TransactionsOut)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}

        public decimal IncomeCount
        {
            get => Reports.Aggregate(0, (total, next) => total +
            next.Income.Transactions.Count);
        }
        public decimal IncomeTotal
		{
			get => Reports.SelectMany(r => r.Income.Transactions)
			.Aggregate(0m, (total, next) => total + next.Amount);
		}

		public decimal OpeningValue
		{
			get => Reports.Aggregate(0m, (total, next) => total + next.OpeningValue);
		}

		public decimal ClosingValue
		{
			get => Reports.Aggregate(0m, (total, next) => total + next.ClosingValue);
		}

		public decimal TotalRealised
		{
			get => Reports.Aggregate(0m, (total, next) => total + next.Performance.TotalRealised);
		}

		public decimal TotalRetained
		{
			get => Reports.Aggregate(0m, (total, next) => total + next.Performance.TotalRetained);
		}

		public List<RetainedPositionViewModel> RetainedPositionsAggregate
		{
			get => RetainedPositionViewModel.AggregateRetainedPositions(Reports.SelectMany(r => r.Performance.PositionsRetained));
		}
	}
}
