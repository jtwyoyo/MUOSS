using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabCardReason
{
    public byte CardCode { get; set; }

    public string? Threason { get; set; }

    public string? Enreason { get; set; }

    public virtual ICollection<TrRequestItem> TrRequestItems { get; } = new List<TrRequestItem>();
}
