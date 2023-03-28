using System;
using System.Collections.Generic;

namespace RequestManagement.Shared.Models;

public partial class MasService
{
    public short ServiceId { get; set; }

    public string? ServiceThname { get; set; }

    public string? ServiceEnname { get; set; }

    public string? DocLang { get; set; }

    public string? DocType { get; set; }

    public decimal? FeeRate { get; set; }

    public string? ServiceGroup { get; set; }

    public string? ActiveStatus { get; set; }

    public string? ForStatus { get; set; }

    public DateTime? LastUpdate { get; set; }

    public string? UpdateBy { get; set; }

    public virtual TabDocumentType? DocTypeNavigation { get; set; }

    public virtual TabServiceGroup? ServiceGroupNavigation { get; set; }

    public virtual ICollection<TrRequestFee> TrRequestFees { get; } = new List<TrRequestFee>();

    public virtual ICollection<TrRequestItem> TrRequestItems { get; } = new List<TrRequestItem>();
}
