using System;

using R5T.F0000;
using R5T.F0002;
using R5T.F0059;
using R5T.Z0000;
using R5T.Z0016;


namespace R5T.F0070
{
    public static class Instances
    {
        public static IAlphaVantageOperator AlphaVantageOperator { get; } = F0070.AlphaVantageOperator.Instance;
        public static IConversionOperator ConversionOperator { get; } = F0070.ConversionOperator.Instance;
        public static IDataTypeNames DataTypeNames { get; } = F0070.DataTypeNames.Instance;
        public static F0000.F001.IDateOperator DateOperator { get; } = F0000.F001.DateOperator.Instance;
        public static IDescriptionOperator DescriptionOperator { get; } = F0070.DescriptionOperator.Instance;
        public static IFileOperator FileOperator { get; } = F0000.FileOperator.Instance;
        public static IFilePaths FilePaths { get; } = F0070.FilePaths.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator { get; } = F0000.FileSystemOperator.Instance;
        public static IFunctionNames FunctionNames { get; } = F0070.FunctionNames.Instance;
        public static IGlobalQuoteOperator GlobalQuoteOperator { get; } = F0070.GlobalQuoteOperator.Instance;
        public static IJsonOperator JsonOperator { get; } = F0070.JsonOperator.Instance;
        public static IJustifications Justifications { get; } = Z0016.Justifications.Instance;
        public static ILoggingOperator LoggingOperator { get; } = F0059.LoggingOperator.Instance;
        public static INoteTexts NoteTexts { get; } = F0070.NoteTexts.Instance;
        public static IOperations Operations { get; } = F0070.Operations.Instance;
        public static F0002.IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static IRawPropertyNames RawPropertyNames { get; } = F0070.RawPropertyNames.Instance;
        public static IRelativeUrls RelativeUrls { get; } = F0070.RelativeUrls.Instance;
        public static IResultKeyNames ResultKeyNames { get; } = F0070.ResultKeyNames.Instance;
        public static IStrings Strings { get; } = Z0000.Strings.Instance;
        public static ITickers Tickers { get; } = F0070.Tickers.Instance;
        public static ITickersOperator TickersOperator { get; } = F0070.TickersOperator.Instance;
        public static IUrlOperator UrlOperator { get; } = F0070.UrlOperator.Instance;
        public static IUrls Urls { get; } = F0070.Urls.Instance;
    }
}