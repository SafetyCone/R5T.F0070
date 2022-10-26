using System;


namespace R5T.F0070
{
	public class DescriptionOperator : IDescriptionOperator
	{
		#region Infrastructure

	    public static IDescriptionOperator Instance { get; } = new DescriptionOperator();

	    private DescriptionOperator()
	    {
        }

	    #endregion
	}
}