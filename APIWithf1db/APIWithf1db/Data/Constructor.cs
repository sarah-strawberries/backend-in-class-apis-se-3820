using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Constructor
{
    public long Constructorid { get; set; }

    public string Constructorref { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Nationality { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<Constructorresult> Constructorresults { get; set; } = new List<Constructorresult>();

    public virtual ICollection<Constructorstanding> Constructorstandings { get; set; } = new List<Constructorstanding>();

    public virtual ICollection<Qualifying> Qualifyings { get; set; } = new List<Qualifying>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
