using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class FileErrors
    {
        public long FileId { get; set; }
        public int ErrorId { get; set; }
        public string ErrorCode { get; set; }

        public virtual Codes ErrorCodeNavigation { get; set; }
        public virtual UploadedFiles File { get; set; }
    }
}
