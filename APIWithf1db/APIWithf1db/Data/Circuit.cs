using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace APIWithf1db.Data;

public partial class Circuit
{
    public long Circuitid { get; set; }

    public string Circuitref { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Location { get; set; }

    public string? Country { get; set; }

    public double? Lat { get; set; }

    public double? Lng { get; set; }

    public long? Alt { get; set; }

    public string Url { get; set; } = null!;

    public NpgsqlPoint? Position { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
