using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ClaimsInfo
    {
        public long ClaimId { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime? Processedon { get; set; }
        public DateTime ActionTimeStamp { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }

        public virtual ClaimAttachments ClaimAttachments { get; set; }
        public virtual ClaimNotes ClaimNotes { get; set; }
    }
}
