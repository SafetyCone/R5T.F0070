using System;

using R5T.T0132;


namespace R5T.F0070
{
	[FunctionalityMarker]
	public partial interface IConversionOperator : IFunctionalityMarker,
		F0000.F001.IConversionOperator
	{
		public double ToDouble_FromChangePercent(string changePercentString)
        {
			var doubleString = changePercentString.TrimEnd(
				Z0000.Characters.Instance.Percent);

			var @double = this.ToDouble(doubleString);
			return @double;
        }
	}
}