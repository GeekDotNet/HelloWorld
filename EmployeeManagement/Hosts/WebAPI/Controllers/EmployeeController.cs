using EmployeeManagement.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;
        private readonly IBlobService _blobService;

        public EmployeeController(IEmployeeManager employeeManager, IBlobService blobService)
        {
            _employeeManager = employeeManager;
            _blobService = blobService;
        }

        //[Route("/")]
        [HttpGet("GetEmployees")]
        public List<EmployeeInfo> GetEmployees()
        {
            return _employeeManager.GetEmployees();
            // return new List<EmployeeInfo> { new EmployeeInfo { Id = 1, Department = "FR", Designation = "Lead Developer", Name = "Ravi K", PhotoPath = @"straoge\container\blob" } };
        }
        [HttpGet("GetEmployee")]
        public EmployeeInfo GetEmployee(long id)
        {
            return _employeeManager.GetEmployee(id);

        }

        [HttpPost("AddOrUpdateEmployeeInfo")]
        public bool AddOrUpdateEmployeeInfo([FromBody] EmployeeInfo employeeInfo)
        {
            return _employeeManager.AddOrUpdateEmployeeInfo(employeeInfo);
        }

        [HttpPost("UploadEmployeeImage")]
        public Task<Uri> UploadEmployeeImage([FromBody] EmployeeInfo employeeInfo)
        {
            return _blobService.UploadEmployeeImageAsync("", null, "", employeeInfo.PhotoPath);
        }

    }
}
