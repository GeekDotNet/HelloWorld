using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Controllers
{
    public class EmployeeController : Controller
    {
        IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<EmployeeInfoModel>> GetEmployeeInfo()
        {
            List<EmployeeInfoModel> employeeList = new List<EmployeeInfoModel>();
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration.GetSection("APIBaseUrl").Value + "GetEmployees";

                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        employeeList = JsonConvert.DeserializeObject<List<EmployeeInfoModel>>(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
                        //TODO: No Data or Expection

                    }
                }

            }
            return employeeList;
        }
    }
}

