using System;


namespace R5T.F0070
{
	public class JsonOperator : IJsonOperator
	{
		#region Infrastructure

	    public static IJsonOperator Instance { get; } = new JsonOperator();

	    private JsonOperator()
	    {
        }

	    #endregion
	}
}