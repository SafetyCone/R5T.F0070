using System;


namespace R5T.F0070
{
	public class TickersOperator : ITickersOperator
	{
		#region Infrastructure

	    public static ITickersOperator Instance { get; } = new TickersOperator();

	    private TickersOperator()
	    {
        }

	    #endregion
	}
}