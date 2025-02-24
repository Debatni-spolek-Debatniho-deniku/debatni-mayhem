using System;
using System.Collections.Generic;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public partial class Round
{
    public int Id { get; set; }

    public string? InfoSlide { get; set; }

    public string Topic { get; set; } = null!;

    public bool Ongoing { get; set; }

    public bool ShowTopic { get; set; }

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
}
