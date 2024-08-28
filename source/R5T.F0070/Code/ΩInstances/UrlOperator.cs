using System;


namespace R5T.F0070
{
	public class UrlOperator : IUrlOperator
	{
		#region Infrastructure

	    public static IUrlOperator Instance { get; } = new UrlOperator();

	    private UrlOperator()
	    {
        }

	    #endregion
	}
}