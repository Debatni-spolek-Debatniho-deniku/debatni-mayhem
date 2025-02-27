
namespace DSDD.DebatniMayhem.Web.Pages.Shared;

public class MatchesTablePlayerModel
{
    public string Name { get; }

    public bool Bold { get; }

    public bool Placeholder { get; }

    public MatchesTablePlayerModel(string name, bool bold, bool placeholder)
    {
        Name = name;
        Bold = bold;
        Placeholder = placeholder;
    }
}

