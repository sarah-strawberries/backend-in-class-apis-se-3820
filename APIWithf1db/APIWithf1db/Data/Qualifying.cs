using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Qualifying
{
    public long Qualifyid { get; set; }

    public long Raceid { get; set; }

    public long Driverid { get; set; }

    public long Constructorid { get; set; }

    public long Number { get; set; }

    public long? Position { get; set; }

    public string? Q1 { get; set; }

    public string? Q2 { get; set; }

    public string? Q3 { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}
