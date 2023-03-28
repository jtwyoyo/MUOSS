using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TrRequestAddress
{
    public int RequestId { get; set; }

    public string? AddrType { get; set; }

    public string? AddrNo { get; set; }

    public string? ProvCode { get; set; }

    public string? AmphoeIdn { get; set; }

    public string? TambonIdn { get; set; }

    public string? Zipcode { get; set; }

    public virtual TrRequest Request { get; set; } = null!;
}
