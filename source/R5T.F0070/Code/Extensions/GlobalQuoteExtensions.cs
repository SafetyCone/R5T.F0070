using System;

using GlobalQuote = R5T.F0070.GlobalQuote;
using RawGlobalQuote = R5T.F0070.Raw.GlobalQuote;
using SerializationGlobalQuote = R5T.F0070.Serialization.GlobalQuote;

using Instances = R5T.F0070.Instances;


public static class GlobalQuoteExtensions
{
    public static GlobalQuote ToGlobalQuote(this RawGlobalQuote rawGlobalQuote)
    {
        var globalQuote = Instances.GlobalQuoteOperator.FromRaw(rawGlobalQuote);
        return globalQuote;
    }

    public static GlobalQuote ToGlobalQuote(this SerializationGlobalQuote serializationGlobalQuote)
    {
        var globalQuote = Instances.GlobalQuoteOperator.FromSerialization(serializationGlobalQuote);
        return globalQuote;
    }

    public static SerializationGlobalQuote ToSerialization(this GlobalQuote globalQuote)
    {
        var serializationGlobalQuote = Instances.GlobalQuoteOperator.ToSerialization(globalQuote);
        return serializationGlobalQuote;
    }
}

