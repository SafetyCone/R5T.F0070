using System;

using R5T.T0131;


namespace R5T.F0070
{
	/// <summary>
	/// Function names in the AlphaVantage API.
	/// </summary>
	[ValuesMarker]
	public partial interface IFunctionNames : IValuesMarker
	{
		public string Global_Quote => "GLOBAL_QUOTE";
	}
}