using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabDocumentType
{
    public string DocType { get; set; } = null!;

    public string? DocThtype { get; set; }

    public string? DocEntype { get; set; }

    public virtual ICollection<MasService> MasServices { get; } = new List<MasService>();
}
