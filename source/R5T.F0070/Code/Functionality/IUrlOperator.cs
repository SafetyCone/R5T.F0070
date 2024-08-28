using System;
using System.Web;

using R5T.T0132;


namespace R5T.F0070
{
	[FunctionalityMarker]
	public partial interface IUrlOperator : IFunctionalityMarker
	{
		public Uri GetAlphaVantageUrl()
        {
			var alphaVantageUrl = new Uri(Instances.Urls.AlphaVantage);
			return alphaVantageUrl;
		}

		public Uri GetQueryUrl()
        {
			var alphaVantageUrl = this.GetAlphaVantageUrl();

			var queryUrl = new Uri(alphaVantageUrl, Instances.RelativeUrls.Query);
			return queryUrl;
		}

        public string GetQuoteQueryString(
            string ticker,
            string apiKey)
        {
            var queryValues = HttpUtility.ParseQueryString(Instances.Strings.QuestionMark);

            queryValues["function"] = Instances.FunctionNames.Global_Quote;
            queryValues["symbol"] = ticker;
            // Be explicit, even though JSON is the default.
            queryValues["datatype"] = Instances.DataTypeNames.Json;
            queryValues["apikey"] = apiKey;

            var queryString = queryValues.ToString();
            return queryString;
        }

        public Uri GetQuoteUrl(
            string ticker,
            string apiKey)
        {
            var queryUrl = this.GetQueryUrl();

            var queryValues = HttpUtility.ParseQueryString(Instances.Strings.Empty);

            queryValues["function"] = Instances.FunctionNames.Global_Quote;
            queryValues["symbol"] = ticker;
            // Be explicit, even though JSON is the default.
            queryValues["datatype"] = Instances.DataTypeNames.Json;
            queryValues["apikey"] = apiKey;

            var queryString = queryValues.ToString();

            var uriBuilder = new UriBuilder(queryUrl)
            {
                //Port = -1,
                Query = queryString,
            };

            var quoteUrl = uriBuilder.Uri;
            return quoteUrl;
        }

        public Uri GetQuoteUrl(
            string ticker)
        {
            var apiKey = Instances.AlphaVantageOperator.GetApiKey_Synchronous();

            var quoteUrl = this.GetQuoteUrl(
                ticker,
                apiKey);

            return quoteUrl;
        }
    }
}