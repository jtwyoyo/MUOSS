using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabTitle
{
    public string TitleCode { get; set; } = null!;

    public string? Thtitle { get; set; }

    public string? Entitle { get; set; }

    public virtual ICollection<TrChangeName> TrChangeNames { get; } = new List<TrChangeName>();
}
