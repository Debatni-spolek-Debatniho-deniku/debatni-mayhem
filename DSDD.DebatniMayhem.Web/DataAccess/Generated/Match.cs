using System;
using System.Collections.Generic;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public partial class Match
{
    public int Id { get; set; }

    public int RoundId { get; set; }

    public int RoomId { get; set; }

    public int Og1 { get; set; }

    public int Og2 { get; set; }

    public int Oo1 { get; set; }

    public int Oo2 { get; set; }

    public int Cg1 { get; set; }

    public int Cg2 { get; set; }

    public int Co1 { get; set; }

    public int Co2 { get; set; }

    public int? OgPoints { get; set; }

    public int? OoPoints { get; set; }

    public int? CgPoints { get; set; }

    public int? CoPoints { get; set; }

    public int? Og1SpeakerPoints { get; set; }

    public int? Og2SpeakerPoints { get; set; }

    public int? Oo1SpeakerPoints { get; set; }

    public int? Oo2SpeakerPoints { get; set; }

    public int? Cg1SpeakerPoints { get; set; }

    public int? Cg2SpeakerPoints { get; set; }

    public int? Co1SpeakerPoints { get; set; }

    public int? Co2SpeakerPoints { get; set; }

    public virtual Player Cg1Navigation { get; set; } = null!;

    public virtual Player Cg2Navigation { get; set; } = null!;

    public virtual Player Co1Navigation { get; set; } = null!;

    public virtual Player Co2Navigation { get; set; } = null!;

    public virtual Player Og1Navigation { get; set; } = null!;

    public virtual Player Og2Navigation { get; set; } = null!;

    public virtual Player Oo1Navigation { get; set; } = null!;

    public virtual Player Oo2Navigation { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Round Round { get; set; } = null!;
}
