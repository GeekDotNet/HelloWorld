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
    public class CreateModel : PageModel
    {
        IConfiguration _configuration;

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [BindProperty]
        public EmployeeInfoModel Employee { get; set; }
        public void OnGet()
        {
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
                return Page();

            }
        }
    }
}
