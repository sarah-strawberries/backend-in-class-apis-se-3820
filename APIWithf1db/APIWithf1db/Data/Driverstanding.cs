using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Driverstanding
{
    public long Driverstandingsid { get; set; }

    public long Raceid { get; set; }

    public long Driverid { get; set; }

    public double Points { get; set; }

    public long? Position { get; set; }

    public string? Positiontext { get; set; }

    public long Wins { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}
