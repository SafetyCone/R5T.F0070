using System;


namespace R5T.F0070
{
	public class RelativeUrls : IRelativeUrls
	{
		#region Infrastructure

	    public static IRelativeUrls Instance { get; } = new RelativeUrls();

	    private RelativeUrls()
	    {
        }

	    #endregion
	}
}