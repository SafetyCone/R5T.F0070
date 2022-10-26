using System;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0070.Construction
{
	[FunctionalityMarker]
	public partial interface IOperations : IFunctionalityMarker,
        F0070.IOperations
	{
        public async Task GetQuotes()
        {
            var exampleTickers =
                Instances.TickersOperator.Get_ExampleTickersList()
                //EnumerableOperator.Instance.From(
                //    Instances.Tickers.APC);
                ;

            using var serviceProvider = F0036.Instances.ServiceProvider.ConfigureServices(
                servicesBuilder =>
                {
                    F0035.Instances.ServicesOperator.AddLogging(servicesBuilder.Services);
                })
                .Build();

            var logger = serviceProvider.GetLogger(nameof(GetQuotes));

            var quotesByTicker = await this.GetQuotes(
                exampleTickers,
                logger);

            foreach (var quote in quotesByTicker.Values)
            {
                Console.WriteLine(quote);
            }

            Instances.JsonOperator.SerializeGlobalQuotes_Synchronous(
                Instances.FilePaths.OutputJsonFilePath,
                quotesByTicker.Values);
        }

        public void DeserializeQuote_FromOutputJsonFile()
        {
            var globalQuote = Instances.JsonOperator.DeserializeGlobalQuote_Synchronous(
                Instances.FilePaths.OutputJsonFilePath);

            Console.WriteLine($"Global quote:\n  {globalQuote}");
        }

        public async Task GetQuote_AndSerializeToOutputJsonFile()
        {
            var globalQuote = await this.GetQuote(
                Instances.Tickers.AAPL);

            Instances.JsonOperator.SerializeGlobalQuote_Synchronous(
                Instances.FilePaths.OutputJsonFilePath,
                globalQuote);
        }

        public void ParseQuote_FromOutputJsonFile()
        {
            var rawGlobalQuote = Instances.JsonOperator.LoadFromFile_Synchronous<Raw.GlobalQuote>(
                Instances.FilePaths.OutputJsonFilePath,
                Instances.ResultKeyNames.GlobalQuote);

            Console.WriteLine($"Raw global quote:\n  {rawGlobalQuote}");

            var globalQuote = rawGlobalQuote.ToGlobalQuote();

            Console.WriteLine();
            Console.WriteLine($"Global quote:\n  {globalQuote}");
        }

        public async Task GetRawQuoteJsonText_AndSaveToOutputJsonFile()
        {
            var ticker = Instances.Tickers.AAPL;

            var quote = await this.GetQuote_AsRawJsonText(ticker);

            Instances.FileOperator.WriteText(
                Instances.FilePaths.OutputJsonFilePath,
                quote);
        }
    }
}