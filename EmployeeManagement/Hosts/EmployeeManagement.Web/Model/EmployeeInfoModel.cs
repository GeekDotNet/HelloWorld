using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web
{
    public class EmployeeInfoModel
    {

        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Designation { get; set; }

        [Required]
        [Display(Name ="Photo")]
        public string PhotoPath { get; set; } = "https://azemployeemanagement.blob.core.windows.net/employeephotos/1.jpg";

        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        //[DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
