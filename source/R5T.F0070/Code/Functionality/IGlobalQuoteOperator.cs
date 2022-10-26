using System;

using R5T.T0132;


namespace R5T.F0070
{
	[DraftFunctionalityMarker]
	public partial interface IGlobalQuoteOperator : IDraftFunctionalityMarker
	{
		public GlobalQuote FromRawJsonText(string rawJsonText)
        {
			var rawGlobalQuote = Instances.JsonOperator.ParseFromJsonText<Raw.GlobalQuote>(
				rawJsonText,
				Instances.ResultKeyNames.GlobalQuote);

			var globalQuote = rawGlobalQuote.ToGlobalQuote();
			return globalQuote;
		}

		public GlobalQuote FromRaw(Raw.GlobalQuote rawGlobalQuote)
        {
			var globalQuote = new GlobalQuote
			{
				Symbol = rawGlobalQuote.Symbol,
				Open = Instances.ConversionOperator.ToDouble(rawGlobalQuote.Open),
				High = Instances.ConversionOperator.ToDouble(rawGlobalQuote.High),
				Low = Instances.ConversionOperator.ToDouble(rawGlobalQuote.Low),
				Price = Instances.ConversionOperator.ToDouble(rawGlobalQuote.Price),
				Volume = Instances.ConversionOperator.ToLong(rawGlobalQuote.Volume),
				LatestTradingDay = Instances.ConversionOperator.ToDate(rawGlobalQuote.LatestTradingDay),
				PreviousClose = Instances.ConversionOperator.ToDouble(rawGlobalQuote.PreviousClose),
				Change = Instances.ConversionOperator.ToDouble(rawGlobalQuote.Change),
				ChangePercent = Instances.ConversionOperator.ToDouble_FromChangePercent(rawGlobalQuote.ChangePercent),
			};

			return globalQuote;
        }

		public GlobalQuote FromSerialization(Serialization.GlobalQuote serializationGlobalQuote)
		{
			var globalQuote = new GlobalQuote
			{
				Symbol = serializationGlobalQuote.Symbol,
				Open = serializationGlobalQuote.Open,
				High = serializationGlobalQuote.High,
				Low = serializationGlobalQuote.Low,
				Price = serializationGlobalQuote.Price,
				Volume = serializationGlobalQuote.Volume,
				LatestTradingDay = Instances.ConversionOperator.ToDate(serializationGlobalQuote.LatestTradingDay),
				PreviousClose = serializationGlobalQuote.PreviousClose,
				Change = serializationGlobalQuote.Change,
				ChangePercent = serializationGlobalQuote.ChangePercent,
			};

			return globalQuote;
		}

		public Serialization.GlobalQuote ToSerialization(GlobalQuote globalQuote)
        {
			var serializationGlobalQuote = new Serialization.GlobalQuote
			{
				Symbol = globalQuote.Symbol,
				Open = globalQuote.Open,
				High = globalQuote.High,
				Low = globalQuote.Low,
				Price = globalQuote.Price,
				Volume = globalQuote.Volume,
				LatestTradingDay = Instances.DateOperator.ToString_YYYY_MM_DD_Dash(globalQuote.LatestTradingDay),
				PreviousClose = globalQuote.PreviousClose,
				Change = globalQuote.Change,
				ChangePercent = globalQuote.ChangePercent,
			};

			return serializationGlobalQuote;
        }
	}
}