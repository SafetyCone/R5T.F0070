using System;

using R5T.T0131;


namespace R5T.F0070
{
	[DraftValuesMarker]
	public partial interface ITickers : IDraftValuesMarker
	{
		/// <summary>
		/// Cash in the bank, not a ticker.
		/// </summary>
		public string Cash => "<cash>";


		/// <summary>
		/// Apple Computers.
		/// </summary>
		public string AAPL => "AAPL";
		public string AFRM => "AFRM";
		public string AMZN => "AMZN";
		public string APC => "APC";
		public string APD => "APD";
		public string BA => "BA";
		public string BMY => "BMY";
		public string INTC => "INTC";
		public string KO => "KO";
		public string LYB => "LYB";
		public string MSFT => "MSFT";
		public string NVDA => "NVDA";
	}
}