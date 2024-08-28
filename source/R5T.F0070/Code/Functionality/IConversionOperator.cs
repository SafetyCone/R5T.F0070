using System;

using R5T.T0132;


namespace R5T.F0070
{
	[FunctionalityMarker]
	public partial interface IConversionOperator : IFunctionalityMarker,
		L0072.IConversionOperator
	{
		public double ToDouble_FromChangePercent(string changePercentString)
        {
			var doubleString = changePercentString.TrimEnd(
				Instances.Characters.Percent);

			var @double = this.To_Double(doubleString);
			return @double;
        }
	}
}