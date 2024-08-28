using System;
using System.Text.Json.Serialization;

using R5T.T0142;


namespace R5T.F0070.Raw
{
    /// <summary>
    /// For deserializing raw global quotes.
    /// This class mainly deals with the crazy key names.
    /// </summary>
    [DataTypeMarker]
    public class GlobalQuote
    {
        [JsonPropertyName(name: IRawPropertyNames.IForGlobalQuote.Symbol)]
        public string Symbol { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.Open)]
        public string Open { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.High)]
        public string High { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.Low)]
        public string Low { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.Price)]
        public string Price { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.Volume)]
        public string Volume { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.LatestTradingDay)]
        public string LatestTradingDay { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.PreviousClose)]
        public string PreviousClose { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.Change)]
        public string Change { get; set; }
        [JsonPropertyName(name:IRawPropertyNames.IForGlobalQuote.ChangePercent)]
        public string ChangePercent { get; set; }


        public override string ToString()
        {
            var representation = Instances.DescriptionOperator.DescribeQuote(
                this.Symbol,
                this.Price,
                this.LatestTradingDay);

            return representation;
        }
    }
}


namespace R5T.F0070.Serialization
{
    /// <summary>
    /// For deserializing raw global quotes.
    /// This class mainly deals with the crazy key names.
    /// </summary>
    [DataTypeMarker]
    public class GlobalQuote
    {
        public string Symbol { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Price { get; set; }
        public long Volume { get; set; }
        public string LatestTradingDay { get; set; }
        public double PreviousClose { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }


        public override string ToString()
        {
            var priceString = Instances.ConversionOperator.To_String(this.Price);

            var representation = Instances.DescriptionOperator.DescribeQuote(
                this.Symbol,
                priceString,
                this.LatestTradingDay);

            return representation;
        }
    }
}


namespace R5T.F0070
{
    /// <summary>
    /// For deserializing raw global quotes.
    /// This class mainly deals with the crazy key names.
    /// </summary>
    [DataTypeMarker]
    public class GlobalQuote
    {
        public string Symbol { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Price { get; set; }
        public long Volume { get; set; }
        public DateOnly LatestTradingDay { get; set; }
        public double PreviousClose { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }


        public override string ToString()
        {
            var representation = Instances.DescriptionOperator.DescribeQuote(
                this.Symbol,
                this.Price,
                this.LatestTradingDay);

            return representation;
        }
    }
}

