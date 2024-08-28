using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.L0089.T000;
using R5T.T0132;


namespace R5T.F0070
{
	[FunctionalityMarker]
	public partial interface IOperations : IFunctionalityMarker
	{
        public async Task<GlobalQuote> GetQuote(string ticker)
        {
            var quoteJsonText = await this.GetQuote_AsRawJsonText(ticker);

            var rawGlobalQuote = Instances.JsonOperator.Parse_FromJsonText<Raw.GlobalQuote>(
                quoteJsonText,
                Instances.ResultKeyNames.GlobalQuote);

            var globalQuote = rawGlobalQuote.ToGlobalQuote();
            return globalQuote;
        }

        public async Task<string> GetQuote_AsRawJsonText(string ticker)
        {
            var quoteUrl = Instances.UrlOperator.GetQuoteUrl(ticker);

            using var client = new HttpClient();

            var output = await client.GetStringAsync(quoteUrl);
            return output;
        }

        public async Task<string> GetQuote_AsRawJsonText(
            string ticker,
            string apiKey,
            ILogger logger)
        {
            var baseUri = new Uri("https://www.alphavantage.co");
            var queryUri = new Uri(baseUri, "query");

            var query = HttpUtility.ParseQueryString(Instances.Strings.Empty);

            query["function"] = "GLOBAL_QUOTE";
            query["symbol"] = ticker;
            query["datatype"] = "json"; // Be explicit, even though this is the default.
            query["apikey"] = apiKey;

            var uriBuilder = new UriBuilder(queryUri)
            {
                //Port = -1,
                Query = query.ToString(),
            };

            var uri = uriBuilder.Uri;

            using var client = new HttpClient();

            logger.LogInformation($"URL:\n\t{uri}");

            var output = await client.GetStringAsync(uri);
            return output;
        }

        public async Task<Dictionary<string, GlobalQuote>> GetQuotes(
            IEnumerable<string> tickers,
            string apiKey,
            ILogger logger)
        {
            var output = new Dictionary<string, GlobalQuote>();

            var distinctTickers = tickers
                .Distinct()
                .OrderAlphabetically_OnlyIfDebug()
                .Now();

            foreach (var ticker in distinctTickers)
            {
                // No need to get a quote for money (cash).
                if (ticker == Instances.Tickers.Cash)
                {
                    logger.LogInformation($"Skipped cash-money ticker '{ticker}'.");

                    continue;
                }

                async Task<WasFound<string>> HasQuote_AsRawJsonText_WithRetry(string ticker)
                {
                    var quoteRawJsonText = await this.GetQuote_AsRawJsonText(
                        ticker,
                        apiKey,
                        logger);

                    logger.LogInformation($"Quote raw JSON:\n{quoteRawJsonText}");

                    var responseJObject = JsonObject.Parse(quoteRawJsonText);

                    var globalQuote = responseJObject[Instances.ResultKeyNames.GlobalQuote].AsObject();
                    if(globalQuote is null)
                    {
                        var note = responseJObject["Note"];
                        if(note is not null)
                        {
                            logger.LogInformation(note.ToString());
                            logger.LogInformation("Maximum requests per minute reached.");

                            var now = DateTime.Now;
                            var timeToWait = new TimeSpan(0, 1, 0); // Wait one minute.
                            var nextMinute = now + timeToWait;

                            logger.LogInformation($"Waiting until {nextMinute} to retry...");

                            await Task.Delay(Convert.ToInt32(timeToWait.TotalMilliseconds));

                            logger.LogInformation($"Retrying ticker '{ticker}'...");

                            var newQuoteRawJsonText = await HasQuote_AsRawJsonText_WithRetry(ticker);
                            return newQuoteRawJsonText;
                        }
                        else
                        {
                            throw new Exception("Unknown error.");
                        }
                    }
                    else
                    {
                        var globalQuoteValue = globalQuote;
                        if (globalQuoteValue.Any())
                        {
                            logger.LogDebug($"Succesfully retrieved quote for ticker '{ticker}'.");

                            return WasFound.Found(quoteRawJsonText);
                        }
                        else
                        {
                            logger.LogWarning($"Unable to get quote for: {ticker}.");

                            return WasFound.NotFound<string>();
                        }
                    }
                }

                await logger.InSuccessFailureLogContext(
                    $"Getting quote for ticker '{ticker}'...",
                    $"Got quote for ticker '{ticker}'.",
                    $"Unable to get quote for ticker '{ticker}'.",
                    async () =>
                    {
                        var hasQuote = await HasQuote_AsRawJsonText_WithRetry(ticker);
                        if (hasQuote)
                        {
                            var rawJsonText = hasQuote.Result;

                            var globalQuote = Instances.GlobalQuoteOperator.FromRawJsonText(rawJsonText);

                            output.Add(ticker, globalQuote);
                        }

                        return hasQuote.Exists;
                    });
            }

            return output;
        }
    }
}