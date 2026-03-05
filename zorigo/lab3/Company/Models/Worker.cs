using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Worker
{
    public int Workerid { get; set; }

    public string Fullname { get; set; } = null!;

    public string? Position { get; set; }

    public int? Branchid { get; set; }

    public virtual Branch? Branch { get; set; }
}
