using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json.Linq;

using R5T.F0000;
using R5T.T0132;


namespace R5T.F0070
{
	[FunctionalityMarker]
	public partial interface IAlphaVantageOperator : IFunctionalityMarker
	{
		public async Task<string> GetApiKey()
        {
			var apiKey = await Instances.FileOperator.ReadText(
				Instances.FilePaths.ApiKeyTextFilePath);

			return apiKey;
        }

		public string GetApiKey_Synchronous()
		{
			var apiKey = Instances.FileOperator.ReadText_Synchronous(
				Instances.FilePaths.ApiKeyTextFilePath);

			return apiKey;
		}

		public HttpClient GetAlphaVantageQueryHttpClient()
        {
			var queryUrl = Instances.UrlOperator.GetQueryUrl();

			var queryHttpClient = new HttpClient
			{
				BaseAddress = queryUrl,
			};

			return queryHttpClient;
        }

		public bool ResponseHasGlobalQuoteAndIsNonEmpty(JObject response)
        {
			var globalQuote = response.Property(Instances.ResultKeyNames.GlobalQuote);

			// Global quote is not null and has some children.
			var output = globalQuote?.Value.Children().Any() ?? false;
			return output;
        }

		public bool ResponseHasGlobalQuote(JObject response)
		{
			var globalQuote = response.Property(Instances.ResultKeyNames.GlobalQuote);

			// Global quote is not null;
			var output = globalQuote is not null;
			return output;
		}

		public bool ResponseHasNote(JObject response)
		{
			var note = response.Property(Instances.ResultKeyNames.Note);

			// Note is not null;
			var output = note is not null;
			return output;
		}

		public bool ResponseIsMaximumRequestsPerMinuteReached(JObject response)
        {
			var note = response.Property(Instances.ResultKeyNames.Note);

			// Note is not null and has the text of the mamimum request per minute note text.
			var noteValue = note?.Value.ToString() ?? System.String.Empty;

			var output = noteValue == Instances.NoteTexts.MaximumRequestsPerMinuteReached;
			return output;
        }

		/// <summary>
		/// Chooses <see cref="HasQuote_AsRawJsonText_WithRetry(string, string, HttpClient, ILogger)"/> as the default.
		/// </summary>
		public Task<WasFound<string>> HasQuote_AsRawJsonText(
			string ticker,
			string apiKey,
			HttpClient alphaVantageQueryHttpClient,
			ILogger logger)
		{
			return HasQuote_AsRawJsonText_WithRetry(
				ticker,
				apiKey,
				alphaVantageQueryHttpClient,
				logger);
		}

		public async Task<WasFound<string>> HasQuote_AsRawJsonText_WithRetry(
			string ticker,
			string apiKey,
			HttpClient alphaVantageQueryHttpClient,
			ILogger logger)
		{
			var hasQuote = await HasQuote_AsRawJsonText_WithoutRetry(
				ticker,
				apiKey,
				alphaVantageQueryHttpClient,
				logger);

			if(hasQuote)
            {
				return hasQuote;
            }
			// Else, diagnose and retry.

			var quoteRawJsonText = hasQuote.Result;

			var responseJObject = JObject.Parse(quoteRawJsonText);

			var responseHasGlobalQuote = this.ResponseHasGlobalQuote(responseJObject);
			if(responseHasGlobalQuote)
            {
				logger.LogWarning($"Unable to get quote for: {ticker}.");

				return WasFound.NotFound<string>();
			}

			var responseIsMaximumRequestsPerMinuteReached = this.ResponseIsMaximumRequestsPerMinuteReached(responseJObject);
			if(responseIsMaximumRequestsPerMinuteReached)
            {
				logger.LogInformation("Maximum requests per minute reached.");
				logger.LogInformation("Will wait and re-try.");

				var now = DateTime.Now;
				var timeToWait = new TimeSpan(0, 1, 0); // Wait one minute.
				var nextMinute = now + timeToWait;

				logger.LogInformation($"Waiting until {nextMinute} to retry...");

				await Task.Delay(Convert.ToInt32(timeToWait.TotalMilliseconds));

				logger.LogInformation($"Retrying ticker '{ticker}'...");

				var newQuoteRawJsonText = await HasQuote_AsRawJsonText_WithRetry(
					ticker,
					apiKey,
					alphaVantageQueryHttpClient,
					logger);

				return newQuoteRawJsonText;
			}

			var responseHasNote = this.ResponseHasNote(responseJObject);
			if(responseHasNote)
            {
				var note = responseJObject.Property(Instances.ResultKeyNames.Note);

				logger.LogWarning($"Response has note:\n\t{note.Value}");

				// No return, continue on to error.
            }

			// If we are 
			throw new Exception($"Unknown error retrieving AlphaVantage quote for ticker '{ticker}'.");
		}

		public async Task<WasFound<string>> HasQuote_AsRawJsonText_WithoutRetry(
			string ticker,
			string apiKey,
			HttpClient alphaVantageQueryHttpClient,
			ILogger logger)
		{
			var quoteRawJsonText = await this.GetQuote_AsRawJsonText_WithoutRetry(
				ticker,
				apiKey,
				alphaVantageQueryHttpClient,
				logger);

			var responseJObject = JObject.Parse(quoteRawJsonText);

			var responseHasGlobalQuoteAndIsNonEmpty = this.ResponseHasGlobalQuoteAndIsNonEmpty(responseJObject);
			if (responseHasGlobalQuoteAndIsNonEmpty)
			{
				logger.LogDebug($"Succesfully retrieved quote for ticker '{ticker}'.");

				return WasFound.Found(quoteRawJsonText);
			}
			else
			{
				logger.LogWarning($"Unsuccesful in retrieving quote for ticker '{ticker}'.");

				return WasFound.NotFound(quoteRawJsonText);
			}
		}

		public async Task<string> GetQuote_AsRawJsonText_WithoutRetry(
			string ticker,
			string apiKey,
			HttpClient alphaVantageQueryHttpClient,
			ILogger logger)
		{
			var quoteQueryString = Instances.UrlOperator.GetQuoteQueryString(
				ticker,
				apiKey);

			var quoteRawJsonText = await logger.InLogContext(
				$"Getting quote for ticker '{ticker}'...",
				$"Got quote for ticker '{ticker}'.",
				async () =>
				{
					var uriBuilder = new UriBuilder(alphaVantageQueryHttpClient.BaseAddress)
					{
						Query = quoteQueryString,
					};

					var queryUrl = uriBuilder.ToString();

					logger.LogInformation($"HTTP GET:\n\t{queryUrl}");

					var quoteRawJsonText = await alphaVantageQueryHttpClient.GetStringAsync("?" + quoteQueryString);

					logger.LogInformation($"Response raw JSON:\n{quoteRawJsonText}");

					return quoteRawJsonText;
				});

			return quoteRawJsonText;
		}

		public async Task<WasFound<GlobalQuote>> HasQuote(
			string ticker,
			string apiKey,
			HttpClient alphaVantageQueryHttpClient,
			ILogger logger)
		{
			var hasQuoteAsRawJsonText = await this.HasQuote_AsRawJsonText(
				ticker,
				apiKey,
				alphaVantageQueryHttpClient,
				logger);

			var hasQuote = hasQuoteAsRawJsonText.Convert(Instances.GlobalQuoteOperator.FromRawJsonText);
			return hasQuote;
		}

		/// <summary>
		/// Only if the cache file does not exist is a query sent to the AlphaVantage API.
		/// If the cache file exits, the global quote is loaded from the cache file.
		/// </summary>
		public async Task<WasFound<GlobalQuote>> HasQuote_UseFileCache(
			string ticker,
			string apiKey,
			HttpClient alphaVantageHttpClient,
			string cacheJsonFilePath,
			ILogger logger)
        {
			var cacheFileExists = Instances.FileSystemOperator.FileExists(cacheJsonFilePath);
			if(cacheFileExists)
            {
				var cachedGlobalQuote = await Instances.JsonOperator.DeserializeGlobalQuote(cacheJsonFilePath);
				
				return WasFound.Found(cachedGlobalQuote);
            }

			// If the quote was previously not found.
			var quoteNotFoundCacheFilePath = Instances.PathOperator.AppendToFileNameStem(cacheJsonFilePath, "-Not Found");

			var quoteNotFoundCacheFileExists = Instances.FileSystemOperator.FileExists(quoteNotFoundCacheFilePath);
			if(quoteNotFoundCacheFileExists)
            {
				return WasFound.NotFound<GlobalQuote>();
            }

			// Else, perform the query.
			var hasQuote = await this.HasQuote(
				ticker,
				apiKey,
				alphaVantageHttpClient,
				logger);

			// Then save the quote, if it was found.
			if (hasQuote)
			{
				Instances.FileSystemOperator.EnsureDirectoryForFilePathExists(cacheJsonFilePath);

				await Instances.JsonOperator.SerializeGlobalQuote(
					cacheJsonFilePath,
					hasQuote.Result);
			}
            else
            {
				await Instances.FileOperator.WriteLines(
					quoteNotFoundCacheFilePath,
					// Use ellipsis just for fun.
					EnumerableOperator.Instance.From(Z0000.Strings.Instance.Ellipsis));
            }

			return hasQuote;
        }

		public async Task<Dictionary<string, WasFound<GlobalQuote>>> HasQuotes_UseFileCache(
			IEnumerable<string> tickers,
			string apiKey,
			HttpClient alphaVantageHttpClient,
			Func<string, string> cacheJsonFilePathFromTickerProvider,
			ILogger logger)
		{
			var output = new Dictionary<string, WasFound<GlobalQuote>>();

			var processedTickers = Instances.TickersOperator.ProcessTickersList(tickers);
			foreach (var ticker in processedTickers)
            {
				var cacheJsonFilePath = cacheJsonFilePathFromTickerProvider(ticker);

				var hasQuote = await this.HasQuote_UseFileCache(
					ticker,
					apiKey,
					alphaVantageHttpClient,
					cacheJsonFilePath,
					logger);

				output.Add(ticker, hasQuote);
            }

			return output;
		}

		public async Task<Dictionary<string, WasFound<GlobalQuote>>> HasQuotes_UseFileCache(
			IEnumerable<string> tickers,
			Func<string, string> cacheJsonFilePathFromTickerProvider,
			ILogger logger)
        {
			var apiKey = await this.GetApiKey();
			var alphaVantageHttpClient = this.GetAlphaVantageQueryHttpClient();

			var output = await this.HasQuotes_UseFileCache(
				tickers,
				apiKey,
				alphaVantageHttpClient,
				cacheJsonFilePathFromTickerProvider,
				logger);

			return output;
        }
	}
}