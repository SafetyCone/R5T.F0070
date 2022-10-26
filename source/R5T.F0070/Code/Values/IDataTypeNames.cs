using System;

using R5T.T0131;


namespace R5T.F0070
{
	[ValuesMarker]
	public partial interface IDataTypeNames : IValuesMarker
	{
		public string Json => "json";
	}
}