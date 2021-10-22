
using System;

public struct StampleData
{
    public DateTime punchIn;
    public DateTime punchOut;
    public string project;
    public string description;
    public int id;
    public StampleData(DateTime punchIn, DateTime punchOut, string project, string description, int id)
    {
        this.punchIn = punchIn;
        this.punchOut = punchOut;
        this.project = project;
        this.description = description;
        this.id = id;
    }
}