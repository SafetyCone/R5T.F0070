using System;


namespace R5T.F0070
{
	public class AlphaVantageOperator : IAlphaVantageOperator
	{
		#region Infrastructure

	    public static IAlphaVantageOperator Instance { get; } = new AlphaVantageOperator();

	    private AlphaVantageOperator()
	    {
        }

	    #endregion
	}
}