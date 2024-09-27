using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Laptime
{
    public long Raceid { get; set; }

    public long Driverid { get; set; }

    public long Lap { get; set; }

    public long? Position { get; set; }

    public string? Time { get; set; }

    public long? Milliseconds { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}
