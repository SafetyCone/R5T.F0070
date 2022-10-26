using System;

using R5T.T0131;


namespace R5T.F0070
{
	[ValuesMarker]
	public partial interface INoteTexts : IValuesMarker
	{
		public string MaximumRequestsPerMinuteReached => "Thank you for using Alpha Vantage! Our standard API call frequency is 5 calls per minute and 500 calls per day. Please visit https://www.alphavantage.co/premium/ if you would like to target a higher API call frequency.";
	}
}