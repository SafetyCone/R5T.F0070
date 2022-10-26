using System;


namespace R5T.F0070
{
	public class Tickers : ITickers
	{
		#region Infrastructure

	    public static ITickers Instance { get; } = new Tickers();

	    private Tickers()
	    {
        }

	    #endregion
	}
}