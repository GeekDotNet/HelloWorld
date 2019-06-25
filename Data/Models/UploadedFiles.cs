using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class UploadedFiles
    {
        public long FileId { get; set; }
        public string FileName { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedDate { get; set; }
        public DateTime ActionTimestamp { get; set; }
        public string FileStatus { get; set; }

        public virtual FileErrors FileErrors { get; set; }
    }
}
