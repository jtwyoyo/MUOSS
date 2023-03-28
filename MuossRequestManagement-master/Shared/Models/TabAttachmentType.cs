using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TabAttachmentType
{
    public byte AttachType { get; set; }

    public string? AttachTypeThname { get; set; }

    public string? AttachTypeEnname { get; set; }

    public virtual ICollection<TrRequestAttachment> TrRequestAttachments { get; } = new List<TrRequestAttachment>();
}
