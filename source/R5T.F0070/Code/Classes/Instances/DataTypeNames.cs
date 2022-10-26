using System;


namespace R5T.F0070
{
	public class DataTypeNames : IDataTypeNames
	{
		#region Infrastructure

	    public static IDataTypeNames Instance { get; } = new DataTypeNames();

	    private DataTypeNames()
	    {
        }

	    #endregion
	}
}