using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EmployeeManagement.Web.Pages.Employee
{
    public class EditModel : PageModel
    {
        IConfiguration _configuration;

        public EditModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public EmployeeInfoModel Employee { get; set; }

        public async Task OnGet(int id)
        {
            using (HttpClient client = new HttpClient())
            {
               // var emp = Employee;
                //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endpoint = _configuration.GetSection("APIBaseUrl").Value + "GetEmployee?Id=" + id;

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        Employee = JsonConvert.DeserializeObject<EmployeeInfoModel>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                    }
                }
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                   
                    StringContent content = new StringContent(JsonConvert.SerializeObject(Employee), Encoding.UTF8, "application/json");
                    string endpoint = _configuration.GetSection("APIBaseUrl").Value + "AddOrUpdateEmployeeInfo";

                    using (var response = await client.PostAsync(endpoint, content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            bool result = JsonConvert.DeserializeObject<bool>(response.Content.ReadAsStringAsync().Result);
                        }
                        else
                        {
                        }
                    }
                }
                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
