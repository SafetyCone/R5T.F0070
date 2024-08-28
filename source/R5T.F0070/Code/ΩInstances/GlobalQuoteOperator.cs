using System;


namespace R5T.F0070
{
	public class GlobalQuoteOperator : IGlobalQuoteOperator
	{
		#region Infrastructure

	    public static IGlobalQuoteOperator Instance { get; } = new GlobalQuoteOperator();

	    private GlobalQuoteOperator()
	    {
        }

	    #endregion
	}
}