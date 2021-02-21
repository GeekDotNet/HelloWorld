using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public class EmployeeInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string PhotoPath { get; set; }
        public DateTime JoinDate { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
