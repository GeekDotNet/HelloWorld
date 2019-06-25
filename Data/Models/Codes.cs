using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Codes
    {
        public Codes()
        {
            FileErrors = new HashSet<FileErrors>();
        }

        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FileErrors> FileErrors { get; set; }
    }
}
