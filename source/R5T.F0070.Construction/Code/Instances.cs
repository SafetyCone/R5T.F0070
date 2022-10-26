using System;

using R5T.F0000;
using R5T.Z0015;


namespace R5T.F0070.Construction
{
    public static class Instances
    {
        public static IFilePaths FilePaths { get; } = Construction.FilePaths.Instance;
        public static IFileOperator FileOperator { get; } = F0000.FileOperator.Instance;
        public static IJsonOperator JsonOperator { get; } = F0070.JsonOperator.Instance;
        public static IOperations Operations { get; } = Construction.Operations.Instance;
        public static IResultKeyNames ResultKeyNames { get; } = F0070.ResultKeyNames.Instance;
        public static ITickers Tickers { get; } = F0070.Tickers.Instance;
        public static ITickersOperator TickersOperator { get; } = F0070.TickersOperator.Instance;
    }
}