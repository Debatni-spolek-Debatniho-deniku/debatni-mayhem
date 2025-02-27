namespace DSDD.DebatniMayhem.Web.Pages.Shared;

public class MatchesTableModel
{
    public IReadOnlyList<Match> Matches { get; }

    public MatchesTableModel(IEnumerable<Match> matches)
    {
        Matches = matches.ToArray();
    }

    public class Match
    {
        public string Room { get; }

        public MatchesTablePlayerModel Og1 { get; }

        public MatchesTablePlayerModel Og2 { get; }

        public MatchesTablePlayerModel Oo1 { get; }

        public MatchesTablePlayerModel Oo2 { get; }

        public MatchesTablePlayerModel Cg1 { get; }

        public MatchesTablePlayerModel Cg2 { get; }

        public MatchesTablePlayerModel Co1 { get; }

        public MatchesTablePlayerModel Co2 { get; }

        public Match(string room, MatchesTablePlayerModel og1, MatchesTablePlayerModel og2, MatchesTablePlayerModel oo1, MatchesTablePlayerModel oo2, MatchesTablePlayerModel cg1, MatchesTablePlayerModel cg2, MatchesTablePlayerModel co1, MatchesTablePlayerModel co2)
        {
            Room = room;
            Og1 = og1;
            Og2 = og2;
            Oo1 = oo1;
            Oo2 = oo2;
            Cg1 = cg1;
            Cg2 = cg2;
            Co1 = co1;
            Co2 = co2;
        }
    }
}


