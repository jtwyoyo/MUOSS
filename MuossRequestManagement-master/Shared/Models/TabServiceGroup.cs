using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabServiceGroup
{
    public string ServiceGroup { get; set; } = null!;

    public string? ServiceThgroupName { get; set; }

    public string? ServiceEngroupName { get; set; }

    public virtual ICollection<MasService> MasServices { get; } = new List<MasService>();
}
