using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Race
{
    public long Raceid { get; set; }

    public long Year { get; set; }

    public long Round { get; set; }

    public long Circuitid { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly Date { get; set; }

    public TimeOnly? Time { get; set; }

    public string? Url { get; set; }

    public virtual Circuit Circuit { get; set; } = null!;

    public virtual ICollection<Constructorresult> Constructorresults { get; set; } = new List<Constructorresult>();

    public virtual ICollection<Constructorstanding> Constructorstandings { get; set; } = new List<Constructorstanding>();

    public virtual ICollection<Driverstanding> Driverstandings { get; set; } = new List<Driverstanding>();

    public virtual ICollection<Laptime> Laptimes { get; set; } = new List<Laptime>();

    public virtual ICollection<Pitstop> Pitstops { get; set; } = new List<Pitstop>();

    public virtual ICollection<Qualifying> Qualifyings { get; set; } = new List<Qualifying>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();

    public virtual Season YearNavigation { get; set; } = null!;
}
