using System;


namespace R5T.F0070
{
    public static class Instances
    {
        public static IAlphaVantageOperator AlphaVantageOperator => F0070.AlphaVantageOperator.Instance;
        public static L0066.ICharacters Characters => L0066.Characters.Instance;
        public static IConversionOperator ConversionOperator => F0070.ConversionOperator.Instance;
        public static IDataTypeNames DataTypeNames => F0070.DataTypeNames.Instance;
        public static L0072.IDateOperator DateOperator => L0072.DateOperator.Instance;
        public static IDescriptionOperator DescriptionOperator => F0070.DescriptionOperator.Instance;
        public static L0066.IEnumerableOperator EnumerableOperator => L0066.EnumerableOperator.Instance;
        public static L0066.IFileOperator FileOperator => L0066.FileOperator.Instance;
        public static IFilePaths FilePaths => F0070.FilePaths.Instance;
        public static L0066.IFileSystemOperator FileSystemOperator => L0066.FileSystemOperator.Instance;
        public static L0066.IFormatStrings FormatStrings => L0066.FormatStrings.Instance;
        public static IFunctionNames FunctionNames => F0070.FunctionNames.Instance;
        public static IGlobalQuoteOperator GlobalQuoteOperator => F0070.GlobalQuoteOperator.Instance;
        public static IJsonOperator JsonOperator => F0070.JsonOperator.Instance;
        public static Z0016.IJustifications Justifications => Z0016.Justifications.Instance;
        public static INoteTexts NoteTexts => F0070.NoteTexts.Instance;
        public static IOperations Operations => F0070.Operations.Instance;
        public static L0066.IPathOperator PathOperator => L0066.PathOperator.Instance;
        public static IRawPropertyNames RawPropertyNames => F0070.RawPropertyNames.Instance;
        public static IRelativeUrls RelativeUrls => F0070.RelativeUrls.Instance;
        public static IResultKeyNames ResultKeyNames => F0070.ResultKeyNames.Instance;
        public static L0066.IStringOperator StringOperator => L0066.StringOperator.Instance;
        public static L0066.IStrings Strings => L0066.Strings.Instance;
        public static ITickers Tickers => F0070.Tickers.Instance;
        public static ITickersOperator TickersOperator => F0070.TickersOperator.Instance;
        public static IUrlOperator UrlOperator => F0070.UrlOperator.Instance;
        public static IUrls Urls => F0070.Urls.Instance;
    }
}