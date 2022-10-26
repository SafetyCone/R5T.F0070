using System;


namespace R5T.F0070
{
	public class RawPropertyNames : IRawPropertyNames
	{
		#region Infrastructure

	    public static IRawPropertyNames Instance { get; } = new RawPropertyNames();

	    private RawPropertyNames()
	    {
        }

		#endregion
	}
}