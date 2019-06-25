using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class ClaimNotes
    {
        public long ClaimId { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ClaimsInfo Claim { get; set; }
    }
}
