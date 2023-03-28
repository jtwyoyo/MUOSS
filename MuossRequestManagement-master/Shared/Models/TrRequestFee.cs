using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class TrRequestFee
{
    public int TranFeeId { get; set; }

    public int RequestId { get; set; }

    public short FeeType { get; set; }

    public byte? NoOfCopy { get; set; }

    public decimal? FeeRate { get; set; }

    public decimal? FeeAmount { get; set; }

    public virtual MasService FeeTypeNavigation { get; set; } = null!;

    public virtual TrRequest Request { get; set; } = null!;
}
