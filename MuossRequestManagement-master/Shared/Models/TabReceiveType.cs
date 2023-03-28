using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabReceiveType
{
    public byte ReceiveType { get; set; }

    public string? ReceiveThdescription { get; set; }

    public string? ReceiveEndescription { get; set; }

    public virtual ICollection<TrRequest> TrRequests { get; } = new List<TrRequest>();
}
