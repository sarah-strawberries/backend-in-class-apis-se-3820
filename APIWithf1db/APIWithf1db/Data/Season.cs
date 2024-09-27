using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Season
{
    public long Year { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
