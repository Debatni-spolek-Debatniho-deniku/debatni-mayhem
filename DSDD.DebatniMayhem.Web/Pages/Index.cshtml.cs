using DSDD.DebatniMayhem.Web.DataAccess;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DSDD.DebatniMayhem.Web.Pages;

public class IndexModel : PageModel
{
    public OngoingRound? Round { get; private set; }

    public IndexModel(MayhemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void OnGet()
    {
        Round = _dbContext
            .Rounds
            .Where(r => r.Ongoing)
            .Select(r => new OngoingRound(
                r.Topic,
                r.InfoSlide,
                r.ShowTopic,
                r.Matches.Select(m => new OngoingMatch(
                    m.Room.Name,
                    m.Og1Navigation.Name,
                    m.Og2Navigation.Name,
                    m.Oo1Navigation.Name,
                    m.Oo2Navigation.Name,
                    m.Cg1Navigation.Name,
                    m.Cg2Navigation.Name,
                    m.Co1Navigation.Name,
                    m.Co2Navigation.Name))))
            .SingleOrDefault();

    }

    private readonly MayhemDbContext _dbContext;

    public class OngoingRound
    {
        public string Topic { get; }

        public string? InfoSlide { get; }

        public bool ShowTopic { get; }

        public IReadOnlyList<OngoingMatch> Matches { get; }

        public OngoingRound(string topic, string? infoSlide,bool showTopic, IEnumerable<OngoingMatch> matches)
        {
            Topic = topic;
            InfoSlide = infoSlide;
            ShowTopic = showTopic;
            Matches = matches.ToArray();
        }
    }

    public class OngoingMatch
    {
        public string Room { get; }

        public string Og1 { get; }

        public string Og2 { get; }

        public string Oo1 { get; }

        public string Oo2 { get; }

        public string Cg1 { get; }

        public string Cg2 { get; }

        public string Co1 { get; }

        public string Co2 { get; }

        public OngoingMatch(string room, string og1, string og2, string oo1, string oo2, string cg1, string cg2, string co1, string co2)
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

