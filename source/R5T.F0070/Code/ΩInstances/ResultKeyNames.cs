using System;


namespace R5T.F0070
{
	public class ResultKeyNames : IResultKeyNames
	{
		#region Infrastructure

	    public static IResultKeyNames Instance { get; } = new ResultKeyNames();

	    private ResultKeyNames()
	    {
        }

	    #endregion
	}
}