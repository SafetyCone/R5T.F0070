using System;


namespace R5T.F0070.Construction
{
	public class FilePaths : IFilePaths
	{
		#region Infrastructure

	    public static IFilePaths Instance { get; } = new FilePaths();

	    private FilePaths()
	    {
        }

	    #endregion
	}
}