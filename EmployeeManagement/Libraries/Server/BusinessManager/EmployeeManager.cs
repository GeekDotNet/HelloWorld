using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeManagement.Common;

namespace EmployeeManagement.Server
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDAO _employeeDAO;
        public EmployeeManager(IEmployeeDAO employeeDAO)
        {
            _employeeDAO = employeeDAO;
        }
        

        public bool DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public EmployeeInfo GetEmployee(long id)
        {
            EmployeeInfo employee= new EmployeeInfo();
            //return new List<EmployeeInfo> { new EmployeeInfo { Id=1, Department="FR", Designation="Lead Developer", Name="Ravi K", PhotoPath=@"straoge\container\blob"  } };
            using (DataTableReader dtr = _employeeDAO.GetEmployee(id).CreateDataReader())
            {
                while (dtr.Read())
                {

                    employee = new EmployeeInfo
                    {
                        Id = Convert.ToInt64(dtr["Id"]),
                        Name = Convert.ToString(dtr["Name"]),
                        Department = Convert.ToString(dtr["Department"]),
                        Designation = Convert.ToString(dtr["Designation"]),
                        JoinDate = Convert.ToDateTime(dtr["JoinDate"]),
                        LastUpdated = Convert.ToDateTime(dtr["LastUpdated"]),
                        PhotoPath = Convert.ToString(dtr["PhotoPath"])
                    };

                }
            }
            return employee;
        }

        public List<EmployeeInfo> GetEmployees()
        {
            List<EmployeeInfo> employees = new List<EmployeeInfo>();
            //return new List<EmployeeInfo> { new EmployeeInfo { Id=1, Department="FR", Designation="Lead Developer", Name="Ravi K", PhotoPath=@"straoge\container\blob"  } };
            using (DataTableReader dtr = _employeeDAO.GetEmployees().CreateDataReader())
            {
                while (dtr.Read())
                {

                    employees.Add(new EmployeeInfo
                    {
                        Id= Convert.ToInt64(dtr["Id"]),
                        Name=Convert.ToString(dtr["Name"]),
                        Department=Convert.ToString(dtr["Department"]),
                        Designation=Convert.ToString(dtr["Designation"]),
                        JoinDate=Convert.ToDateTime(dtr["JoinDate"]),
                        LastUpdated = Convert.ToDateTime(dtr["LastUpdated"]),
                        PhotoPath=Convert.ToString(dtr["PhotoPath"])
                    });

                }
            }
            return employees;
        }

        public bool AddOrUpdateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            return _employeeDAO.AddOrUpdateEmployeeInfo(employeeInfo);
        }
    }
}
