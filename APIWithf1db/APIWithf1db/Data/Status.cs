using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Status
{
    public long Statusid { get; set; }

    public string Status1 { get; set; } = null!;

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
