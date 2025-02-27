using DSDD.DebatniMayhem.Web.DataAccess;
using DSDD.DebatniMayhem.Web.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DSDD.DebatniMayhem.Web.Pages;

public class PlayerModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid? PublicId { get; set; }

    public PlayerDetail? Player { get; private set; }

    public PlayerModel(MayhemDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task OnGetAsync()
    {
        if (PublicId == null)
            throw new ArgumentException($"Parameter {PublicId} cannot be null!");

        Player? player = await _dbContext.Players.SingleOrDefaultAsync(p => p.PublicId == PublicId);

        if (player is null)
            throw new InvalidOperationException($"Player with public id {PublicId} not found!");

        if (player.Placeholder)
            throw new InvalidOperationException($"Player with public id {PublicId} is a placeholder!");
        
        var playerMathces = _dbContext.Matches
            .OrderByDescending(m => m.Id)
            .Where(m => m.Og1 == player.Id 
                        || m.Og2 == player.Id 
                        || m.Oo1 == player.Id
                        || m.Oo2 == player.Id
                        || m.Cg1 == player.Id
                        || m.Cg2 == player.Id
                        || m.Co1 == player.Id
                        || m.Co2 == player.Id)
            .Select(m => new
            {
                m.Round.Topic,
                m.Round.InfoSlide,
                m.Round.Ongoing,
                m.Round.ShowTopic,

                RoomName = m.Room.Name,

                m.OgPoints,
                m.OoPoints,
                m.CgPoints,
                m.CoPoints,

                IsOg1 = m.Og1 == player.Id,
                Og1Name = m.Og1Navigation.Name,
                Og1Placeholder = m.Og1Navigation.Placeholder,
                m.Og1SpeakerPoints,

                IsOg2 = m.Og2 == player.Id,
                Og2Name = m.Og2Navigation.Name,
                Og2Placeholder = m.Og2Navigation.Placeholder,
                m.Og2SpeakerPoints,

                IsOo1 = m.Oo1 == player.Id,
                Oo1Name = m.Oo1Navigation.Name,
                Oo1Placeholder = m.Oo1Navigation.Placeholder,
                m.Oo1SpeakerPoints,

                IsOo2 = m.Oo2 == player.Id,
                Oo2Name = m.Oo2Navigation.Name,
                Oo2Placeholder = m.Oo2Navigation.Placeholder,
                m.Oo2SpeakerPoints,

                IsCg1 = m.Cg1 == player.Id,
                Cg1Name = m.Cg1Navigation.Name,
                Cg1Placeholder = m.Cg1Navigation.Placeholder,
                m.Cg1SpeakerPoints,

                IsCg2 = m.Cg2 == player.Id,
                Cg2Name = m.Cg2Navigation.Name,
                Cg2Placeholder = m.Cg2Navigation.Placeholder,
                m.Cg2SpeakerPoints,

                IsCo1 = m.Co1 == player.Id,
                Co1Name = m.Co1Navigation.Name,
                Co1Placeholder = m.Co1Navigation.Placeholder,
                m.Co1SpeakerPoints,

                IsCo2 = m.Co2 == player.Id,
                Co2Name = m.Co2Navigation.Name,
                Co2Placeholder = m.Co2Navigation.Placeholder,
                m.Co2SpeakerPoints,
            })
            .ToArray();
        
        Player = new(
            player.Name,
            player.Score,
            player.Points,
            player.SpeakerPoints,
            playerMathces.SingleOrDefault(m => m.Ongoing) is not { } ongoingMatch
                ? null
                : new(
                    new(ongoingMatch.Topic, ongoingMatch.InfoSlide, ongoingMatch.ShowTopic),
                    new(ongoingMatch.RoomName,
                        new(ongoingMatch.Og1Name, ongoingMatch.IsOg1, ongoingMatch.Og1Placeholder),
                        new(ongoingMatch.Og2Name, ongoingMatch.IsOg2, ongoingMatch.Og2Placeholder),
                        new(ongoingMatch.Oo1Name, ongoingMatch.IsOo1, ongoingMatch.Oo1Placeholder),
                        new(ongoingMatch.Oo2Name, ongoingMatch.IsOo2, ongoingMatch.Oo2Placeholder),
                        new(ongoingMatch.Cg1Name, ongoingMatch.IsCg1, ongoingMatch.Cg1Placeholder),
                        new(ongoingMatch.Cg2Name, ongoingMatch.IsCg2, ongoingMatch.Cg2Placeholder),
                        new(ongoingMatch.Co1Name, ongoingMatch.IsCo1, ongoingMatch.Co1Placeholder),
                        new(ongoingMatch.Co2Name, ongoingMatch.IsCo2, ongoingMatch.Co2Placeholder))),
            playerMathces.Where(m => !m.Ongoing).Select(m =>
            {
                (string position, string? teammate, int? points, int? speakerPoints) = m switch
                {
                    { IsOg1: true } _m => ("OG", getTeammateIfNotPlaceholder(_m.Og2Name, _m.Og2Placeholder), _m.OgPoints, _m.Og1SpeakerPoints),
                    { IsOg2: true } _m => ("OG", getTeammateIfNotPlaceholder(_m.Og1Name, _m.Og1Placeholder), _m.OgPoints, _m.Og1SpeakerPoints),
                    { IsOo1: true } _m => ("OO", getTeammateIfNotPlaceholder(_m.Oo2Name, _m.Oo2Placeholder),  _m.OoPoints, _m.Oo1SpeakerPoints),
                    { IsOo2: true } _m => ("OO", getTeammateIfNotPlaceholder(_m.Oo1Name, _m.Oo1Placeholder), _m.OoPoints, _m.Oo1SpeakerPoints),

                    { IsCg1: true } _m => ("CG", getTeammateIfNotPlaceholder(_m.Cg2Name, _m.Cg2Placeholder), _m.CgPoints, _m.Cg1SpeakerPoints),
                    { IsCg2: true } _m => ("CG", getTeammateIfNotPlaceholder(_m.Cg1Name, _m.Cg1Placeholder), _m.CgPoints, _m.Cg1SpeakerPoints),
                    { IsCo1: true } _m => ("CO", getTeammateIfNotPlaceholder(_m.Co2Name, _m.Co2Placeholder), _m.CoPoints, _m.Co1SpeakerPoints),
                    { IsCo2: true } _m => ("CO", getTeammateIfNotPlaceholder(_m.Co1Name, _m.Co1Placeholder), _m.CoPoints, _m.Co1SpeakerPoints),

                    _ => throw new InvalidOperationException("Invalid match position")
                };

                return new PlayerHistoryMatchDetail(
                    m.Topic,
                    m.InfoSlide,
                    teammate,
                    position,
                    points,
                    speakerPoints);
            })
        );

        string? getTeammateIfNotPlaceholder(string name, bool isPlaceholder) => isPlaceholder ? null : name;
    }

    private readonly MayhemDbContext _dbContext;

    public class PlayerDetail
    {
        public string Name { get; set; } = null!;

        public int Score { get; set; }

        public int Points { get; set; }

        public int SpeakerPoints { get; set; }

        public OngoingRound? OngoingRound { get; }

        public IReadOnlyList<PlayerHistoryMatchDetail> MatchHistory { get; }

        public PlayerDetail(string name, int score, int points, int speakerPoints, OngoingRound? ongoingMatch, IEnumerable<PlayerHistoryMatchDetail> matchHistory)
        {
            Name = name;
            Score = score;
            Points = points;
            SpeakerPoints = speakerPoints;
            OngoingRound = ongoingMatch;
            MatchHistory = matchHistory.ToArray();
        }
    }

    public class OngoingRound
    {
        public ActiveTopicModel Topic { get; }

        public MatchesTableModel.Match Match { get; }

        public OngoingRound(ActiveTopicModel topic, MatchesTableModel.Match match)
        {
            Topic = topic;
            Match = match;
        }
    }

    public class PlayerHistoryMatchDetail
    {
        public string Topic { get; }

        public string? InfoSlide { get; }

        public string? Teammate { get; }

        public string Position { get; }

        public int? Points { get; }

        public int? SpeakerPoints { get; }

        public PlayerHistoryMatchDetail(string topic, string? infoSlide, string? teammate, string position, int? points, int? speakerPoints)
        {
            Topic = topic;
            InfoSlide = infoSlide;
            Teammate = teammate;
            Position = position;
            Points = points;
            SpeakerPoints = speakerPoints;
        }
    }
}

