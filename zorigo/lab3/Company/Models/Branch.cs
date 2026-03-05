using System;
using System.Collections.Generic;

namespace Company.Models;

public partial class Branch
{
    public int Branchid { get; set; }

    public string Branchname { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
