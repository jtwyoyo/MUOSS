using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabRequestStatus
{
    public string RequestStatus { get; set; } = null!;

    public string? RequestThstatus { get; set; }

    public string? RequestEnstatus { get; set; }

    public virtual ICollection<TrRequest> TrRequests { get; } = new List<TrRequest>();
}
