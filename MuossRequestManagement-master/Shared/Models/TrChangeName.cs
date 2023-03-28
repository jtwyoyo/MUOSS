using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TrChangeName
{
    public int RequestId { get; set; }

    public string? TitleCode { get; set; }

    public string? Tfname { get; set; }

    public string? Tlname { get; set; }

    public string? Efname { get; set; }

    public string? Elname { get; set; }

    public virtual TrRequest Request { get; set; } = null!;

    public virtual TabTitle? TitleCodeNavigation { get; set; }
}
