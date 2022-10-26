using System;

using R5T.T0131;


namespace R5T.F0070
{
	[DraftValuesMarker]
	public partial interface IRawPropertyNames : IDraftValuesMarker
	{
		public interface IForGlobalQuote : IDraftValuesMarker
		{
			public const string Symbol = "01. symbol";
			public const string Open = "02. open";
			public const string High = "03. high";
			public const string Low = "04. low";
			public const string Price = "05. price";
			public const string Volume = "06. volume";
			public const string LatestTradingDay = "07. latest trading day";
			public const string PreviousClose = "08. previous close";
			public const string Change = "09. change";
			public const string ChangePercent = "10. change percent";
		}
	}
}