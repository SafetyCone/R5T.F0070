using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0070
{
	[DraftFunctionalityMarker]
	public partial interface ITickersOperator : IDraftFunctionalityMarker
	{
		public string[] Get_ExampleTickersList()
        {
			var output = new[]
			{
				Instances.Tickers.AAPL,
				Instances.Tickers.AFRM,
				Instances.Tickers.AMZN,
				Instances.Tickers.APC,
				Instances.Tickers.APD,
				Instances.Tickers.BA,
				Instances.Tickers.BMY,
				Instances.Tickers.INTC,
				Instances.Tickers.KO,
				Instances.Tickers.LYB,
				Instances.Tickers.MSFT,
				Instances.Tickers.NVDA,
			};

			return output;
        }

		public string[] ProcessTickersList(IEnumerable<string> tickers)
        {
			var output = tickers
				.Distinct()
				.OrderAlphabetically()
				.ToArray();

			return output;
        }
	}
}