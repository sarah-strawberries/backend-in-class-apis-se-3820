using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Result
{
    public long Resultid { get; set; }

    public long Raceid { get; set; }

    public long Driverid { get; set; }

    public long Constructorid { get; set; }

    public long? Number { get; set; }

    public long Grid { get; set; }

    public long? Position { get; set; }

    public string Positiontext { get; set; } = null!;

    public long Positionorder { get; set; }

    public double Points { get; set; }

    public long Laps { get; set; }

    public string? Time { get; set; }

    public long? Milliseconds { get; set; }

    public long? Fastestlap { get; set; }

    public long? Rank { get; set; }

    public string? Fastestlaptime { get; set; }

    public string? Fastestlapspeed { get; set; }

    public long Statusid { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;
}
