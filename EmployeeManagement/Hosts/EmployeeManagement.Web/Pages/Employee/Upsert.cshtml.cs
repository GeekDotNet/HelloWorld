using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManagement.Web.Pages.Employee
{
    public class UpsertModel : PageModel
    {
        [BindProperty]
        public EmployeeInfoModel Employee { get; set; }

        public void OnGet()
        {
        }
    }
}
