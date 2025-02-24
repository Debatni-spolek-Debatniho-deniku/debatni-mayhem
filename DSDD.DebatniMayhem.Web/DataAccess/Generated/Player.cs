using System;
using System.Collections.Generic;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public partial class Player
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public Guid PublicId { get; set; }

    public int Score { get; set; }

    public int Points { get; set; }

    public int SpeakerPoints { get; set; }

    public bool Active { get; set; }

    public bool Placeholder { get; set; }

    public virtual ICollection<Match> MatchCg1Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchCg2Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchCo1Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchCo2Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchOg1Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchOg2Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchOo1Navigations { get; set; } = new List<Match>();

    public virtual ICollection<Match> MatchOo2Navigations { get; set; } = new List<Match>();
}
