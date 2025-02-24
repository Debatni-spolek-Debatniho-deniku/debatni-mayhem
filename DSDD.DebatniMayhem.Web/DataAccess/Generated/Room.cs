using System;
using System.Collections.Generic;

namespace DSDD.DebatniMayhem.Web.DataAccess;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<Match> Matches { get; set; } = new List<Match>();
}
