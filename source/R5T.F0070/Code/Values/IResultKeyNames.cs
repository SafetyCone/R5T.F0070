using System;

using R5T.T0131;


namespace R5T.F0070
{
	[DraftValuesMarker]
	public partial interface IResultKeyNames : IDraftValuesMarker
	{
		public string GlobalQuote => "Global Quote";
		public string Note => "Note";
	}
}