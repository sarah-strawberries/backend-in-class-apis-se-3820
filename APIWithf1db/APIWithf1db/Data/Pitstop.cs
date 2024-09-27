using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Pitstop
{
    public long Raceid { get; set; }

    public long Driverid { get; set; }

    public long Stop { get; set; }

    public long Lap { get; set; }

    public TimeOnly Time { get; set; }

    public string? Duration { get; set; }

    public long? Milliseconds { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}
