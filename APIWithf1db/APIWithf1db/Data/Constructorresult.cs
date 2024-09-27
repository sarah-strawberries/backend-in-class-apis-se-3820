using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Constructorresult
{
    public long Constructorresultsid { get; set; }

    public long Raceid { get; set; }

    public long Constructorid { get; set; }

    public double? Points { get; set; }

    public string? Status { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}
