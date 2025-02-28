using DSDD.DebatniMayhem.Web.DataAccess;
using DSDD.DebatniMayhem.Web.Pages.Shared;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DSDD.DebatniMayhem.Web.Pages;

public class IndexModel : PageModel
{
    public OngoingRound? Round { get; private set; }

    public IndexModel(MayhemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task OnGetAsync()
    {
        Round = await _dbContext
            .Rounds
            .Where(r => r.Ongoing)
            .Select(r => new OngoingRound(
                new (r.Topic, r.InfoSlide, r.ShowTopic, r.ShowInfoSlide),
                new(r.Matches.Select(m => new MatchesTableModel.Match(
                    m.Room.Name,
                    new(m.Og1Navigation.Name, false, m.Og1Navigation.Placeholder),
                    new(m.Og2Navigation.Name, false, m.Og2Navigation.Placeholder),
                    new(m.Oo1Navigation.Name, false, m.Oo1Navigation.Placeholder),
                    new(m.Oo2Navigation.Name, false, m.Oo2Navigation.Placeholder),
                    new(m.Cg1Navigation.Name, false, m.Cg1Navigation.Placeholder),
                    new(m.Cg2Navigation.Name, false, m.Cg2Navigation.Placeholder),
                    new(m.Co1Navigation.Name, false, m.Co1Navigation.Placeholder),
                    new(m.Co2Navigation.Name, false, m.Co2Navigation.Placeholder)))))
            )
            .SingleOrDefaultAsync();
    }

    private readonly MayhemDbContext _dbContext;

    public class OngoingRound
    {
        public ActiveTopicModel Topic { get; }
        
        public MatchesTableModel Matches { get; }

        public OngoingRound(ActiveTopicModel topic, MatchesTableModel matches)
        {
            Topic = topic;
            Matches = matches;
        }
    }
}

