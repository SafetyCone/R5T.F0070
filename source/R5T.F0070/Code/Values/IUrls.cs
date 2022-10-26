using System;

using R5T.T0131;


namespace R5T.F0070
{
	[ValuesMarker]
	public partial interface IUrls : IValuesMarker
	{
		/// <summary>
		/// Note, *must* have trailing slack to work with <see cref="System.Net.Http.HttpClient.BaseAddress"/>.
		/// </summary>
		public string AlphaVantage => "https://www.alphavantage.co/";
	}
}