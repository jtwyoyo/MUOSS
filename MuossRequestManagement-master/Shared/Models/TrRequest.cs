using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RequestManagement.Shared.Models
{
    public class TrRequest
    {
        [Key]
        public int RequestID { get; set; }

        [Required]
        [StringLength(2)]
        public string RequestStatus { get; set; } = "";

        public decimal? TotalPrice { get; set; }

        [Required]
        [StringLength(7)]
        public string RequesterID { get; set; } = "";

        [StringLength(10)]
        public string? Phone { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        public DateTime? RequestDate { get; set; }

        [StringLength(50)]
        public string? Ref1 { get; set; }

        [StringLength(50)]
        public string? Ref2 { get; set; }

        [StringLength(1)]
        public string? PaidStatus { get; set; }

        public DateTime? PaidDate { get; set; }

        public byte? ReceiveType { get; set; }

        public DateTime? SendDate { get; set; }

        [StringLength(30)]
        public string? TrackNo { get; set; }

        public DateTime? ReceiveDate { get; set; }

        [StringLength(10)]
        public string? ReceiptNum { get; set; }

        [StringLength(200)]
        public string? ReceiptLink { get; set; }

        public DateTime? CancelDate { get; set; }

        public virtual TrChangeName TrChangeName { get; set; }
        public virtual ICollection<TrRequestFee> TrRequestFees { get; set; }
        public virtual TrRequestAddress TrRequestAddress { get; set; }
        public virtual ICollection<TrRequestAttachment> TrRequestAttachments { get; set; }
        public virtual ICollection<TrRequestItem>? TrRequestItems { get; set; }
        public virtual TabReceiveType ReceiveTypeNavigation { get; set; }
        public virtual TabRequestStatus RequestStatusNavigation { get; set; }
    }
}
