using System;

using R5T.T0131;


namespace R5T.F0070
{
	[ValuesMarker]
	public partial interface IFilePaths : IValuesMarker
	{
        /// <summary>
        /// <para><value>C:\Users\David\Dropbox\Organizations\Rivet\Shared\Data\Secrets\AlphaVantage-API Key.txt</value></para>
        /// </summary>
        public string ApiKeyTextFilePath => @"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Data\Secrets\AlphaVantage-API Key.txt";
	}
}