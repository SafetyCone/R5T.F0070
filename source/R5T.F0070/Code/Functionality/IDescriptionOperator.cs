using System;

using R5T.T0132;


namespace R5T.F0070
{
	[DraftFunctionalityMarker]
	public partial interface IDescriptionOperator : IDraftFunctionalityMarker
	{
		public string DescribeQuote(
			string ticker,
			string priceInUSD,
			string date)
        {
			var output = $"{ticker}: ${priceInUSD} ({date})";
			return output;
        }

		public string DescribeQuote(
			string ticker,
			double priceInUSD,
			DateOnly date)
		{
			var dateString = Instances.DateOperator.ToString_YYYY_MM_DD_Dash(date);

			var output = $"{ticker}: ${priceInUSD} ({dateString})";
			return output;
		}
	}
}