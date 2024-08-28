using System;


namespace R5T.F0070
{
	public class NoteTexts : INoteTexts
	{
		#region Infrastructure

	    public static INoteTexts Instance { get; } = new NoteTexts();

	    private NoteTexts()
	    {
        }

	    #endregion
	}
}