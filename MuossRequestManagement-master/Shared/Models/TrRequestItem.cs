using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TrRequestItem
{
    public int ItemId { get; set; }

    public int RequestId { get; set; }

    public short? ServiceId { get; set; }

    public string? DocFormat { get; set; }

    public byte NoOfCopy { get; set; }

    public string? ItemSts { get; set; }

    public DateTime? DocExpired { get; set; }

    public byte[]? DocFile { get; set; }

    public byte? CardCode { get; set; }

    public string? CardCodeText { get; set; }

    public DateTime? GenerateDate { get; set; }

    public string? GenerateBy { get; set; }

    public virtual TabCardReason? CardCodeNavigation { get; set; }

    public virtual TabItemStatus? ItemStsNavigation { get; set; }

    public virtual TrRequest Request { get; set; } = null!;

    public virtual MasService? Service { get; set; }
}
