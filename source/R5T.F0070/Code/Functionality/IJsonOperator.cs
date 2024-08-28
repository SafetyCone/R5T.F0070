using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.F0070
{
	[FunctionalityMarker]
	public partial interface IJsonOperator : IFunctionalityMarker,
		L0072.IJsonOperator
	{
		public void SerializeGlobalQuote_Synchronous(
			string jsonFilePath,
			GlobalQuote globalQuote)
		{
			this.SerializeGlobalQuotes_Synchronous(
				jsonFilePath,
				Instances.EnumerableOperator.From(globalQuote));
		}

		public Task SerializeGlobalQuote(
			string jsonFilePath,
			GlobalQuote globalQuote)
		{
			return this.SerializeGlobalQuotes(
				jsonFilePath,
				Instances.EnumerableOperator.From(globalQuote));
		}

		public GlobalQuote DeserializeGlobalQuote_Synchronous(
			string jsonFilePath)
		{
			var globalQuotes = this.DeserializeGlobalQuotes_Synchronous(
				jsonFilePath);

			var globalQuote = globalQuotes.Single();
			return globalQuote;
		}

		public async Task<GlobalQuote> DeserializeGlobalQuote(
			string jsonFilePath)
		{
			var globalQuotes = await this.DeserializeGlobalQuotes(
				jsonFilePath);

			var globalQuote = globalQuotes.Single();
			return globalQuote;
		}

		public void SerializeGlobalQuotes_Synchronous(
			string jsonFilePath,
			IEnumerable<GlobalQuote> globalQuotes)
        {
			var serializationGlobalQuotes = globalQuotes
				.Select(x => x.ToSerialization());

			Instances.JsonOperator.Save_ToFile_Synchronous(
				jsonFilePath,
				serializationGlobalQuotes);
		}

		public Task SerializeGlobalQuotes(
			string jsonFilePath,
			IEnumerable<GlobalQuote> globalQuotes)
		{
			var serializationGlobalQuotes = globalQuotes
				.Select(x => x.ToSerialization())
				// Need to evaluate now since enumerables will not be enumerated by the serializer.
				.Now();

			return Instances.JsonOperator.Save_ToFile(
				jsonFilePath,
				serializationGlobalQuotes);
		}

		public async Task<GlobalQuote[]> DeserializeGlobalQuotes(
			string jsonFilePath)
		{
			var serializationGlobalQuotes = await Instances.JsonOperator.Load_FromFile<Serialization.GlobalQuote[]>(
				jsonFilePath);

			var globalQuote = serializationGlobalQuotes
				.Select(x => x.ToGlobalQuote())
				.Now();

			return globalQuote;
		}

		public GlobalQuote[] DeserializeGlobalQuotes_Synchronous(
			string jsonFilePath)
		{
			var serializationGlobalQuotes = Instances.JsonOperator.Load_FromFile_Synchronous<Serialization.GlobalQuote[]>(
				jsonFilePath);

			var globalQuote = serializationGlobalQuotes
				.Select(x => x.ToGlobalQuote())
				.Now();

			return globalQuote;
		}
	}
}