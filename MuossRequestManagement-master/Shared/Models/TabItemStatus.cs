using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabItemStatus
{
    public string ItemSts { get; set; } = null!;

    public string? ItemThstatus { get; set; }

    public string? ItemEnstatus { get; set; }

    public virtual ICollection<TrRequestItem> TrRequestItems { get; } = new List<TrRequestItem>();
}
