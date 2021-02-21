using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeManagement.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EmployeeManagement.Web.Pages.Employee
{
    public class IndexModel : PageModel
    {
        IConfiguration _configuration;

        public IndexModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<EmployeeInfoModel> Employees { get; set; }


        
        public async Task OnGet()
        {
            //using (HttpClient client = new HttpClient())
            //{
            //    string endpoint = _configuration.GetSection("APIBaseUrl").Value + "GetEmployees";

            //    using (var response = await client.GetAsync(endpoint))
            //    {
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            Employees = JsonConvert.DeserializeObject<List<EmployeeInfoModel>>(response.Content.ReadAsStringAsync().Result);
            //        }
            //        else
            //        {
            //        }
            //    }
            //}
            EmployeeController employeeController = new EmployeeController(_configuration);
            Employees = employeeController.GetEmployeeInfo().Result;
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            //var findBook = await applicationDbContext.Book.FindAsync(id);

            //if (findBook != null)
            //{

            //    return RedirectToPage("Index");

            //}
            //else
            //    return NotFound();
            return RedirectToPage("Index");
        }
    }
}
