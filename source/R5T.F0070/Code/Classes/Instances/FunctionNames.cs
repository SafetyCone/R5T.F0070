using System;


namespace R5T.F0070
{
	public class FunctionNames : IFunctionNames
	{
		#region Infrastructure

	    public static IFunctionNames Instance { get; } = new FunctionNames();

	    private FunctionNames()
	    {
        }

	    #endregion
	}
}