using EmployeeManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Server
{
    public class EmployeeInfoValidations
    {
        public static List<string> IsValid(EmployeeInfo employeeInfo)
        {
            List<string> validations = new List<string>();

            //Name
            if (string.IsNullOrWhiteSpace(employeeInfo.Name) || employeeInfo.Name?.Length > 50)
                validations.Add("Invalid Name");

            //Department
            if (string.IsNullOrWhiteSpace(employeeInfo.Department) || employeeInfo.Department?.Length > 20)
                validations.Add("Invalid Department");

            //Designation
            if (string.IsNullOrWhiteSpace(employeeInfo.Designation) || employeeInfo.Designation?.Length > 20)
                validations.Add("Invalid Designation");

            //PhotoPath
            if (string.IsNullOrWhiteSpace(employeeInfo.PhotoPath) || employeeInfo.PhotoPath?.Length > 255)
                validations.Add("Invalid PhotoPath");

            //JoinDate
            if(employeeInfo.JoinDate==DateTime.MinValue)
                validations.Add("Invalid JoinDate");
            return validations;
        }
    }
}
