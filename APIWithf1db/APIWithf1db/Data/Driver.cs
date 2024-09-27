using System;
using System.Collections.Generic;

namespace APIWithf1db.Data;

public partial class Driver
{
    public long Driverid { get; set; }

    public string Driverref { get; set; } = null!;

    public long? Number { get; set; }

    public string? Code { get; set; }

    public string Forename { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateOnly? Dob { get; set; }

    public string? Nationality { get; set; }

    public string Url { get; set; } = null!;

    public virtual ICollection<Driverstanding> Driverstandings { get; set; } = new List<Driverstanding>();

    public virtual ICollection<Laptime> Laptimes { get; set; } = new List<Laptime>();

    public virtual ICollection<Pitstop> Pitstops { get; set; } = new List<Pitstop>();

    public virtual ICollection<Qualifying> Qualifyings { get; set; } = new List<Qualifying>();

    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
