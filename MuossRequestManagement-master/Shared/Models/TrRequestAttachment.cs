using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TrRequestAttachment
{
    public int AttachId { get; set; }

    public int? RequestId { get; set; }

    public byte? AttachType { get; set; }

    public string? AttachFile { get; set; }

    public virtual TabAttachmentType? AttachTypeNavigation { get; set; }

    public virtual TrRequest? Request { get; set; }
}
