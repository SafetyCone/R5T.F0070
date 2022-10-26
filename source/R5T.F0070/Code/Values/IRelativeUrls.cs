using System;

using R5T.T0131;


namespace R5T.F0070
{
	[ValuesMarker]
	public partial interface IRelativeUrls : IValuesMarker
	{
		/// <summary>
		/// Note, must *not* have trailing slash to work with <see cref="System.Net.Http.HttpClient.BaseAddress"/>
		/// </summary>
		public string Query => "query";
	}
}