using System;
using System.Threading.Tasks;


namespace R5T.F0070.Construction
{
    class Program
    {
        static async Task Main()
        {
            //await Instances.Operations.GetQuote();
            //Instances.Operations.ParseQuote_FromOutputJsonFile();
            //await Instances.Operations.GetQuote_AndSerializeToOutputJsonFile();
            //Instances.Operations.DeserializeQuote_FromOutputJsonFile();
            await Instances.Operations.GetQuotes();
        }
    }
}