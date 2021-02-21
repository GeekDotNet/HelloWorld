using EmployeeManagement.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Server
{
    public interface IEmployeeDAO
    {
        public DataTable GetEmployees();

        public DataTable GetEmployee(long id);

        public bool AddEmployee(EmployeeInfo employeeInfo);

        public bool DeleteEmployee(long id);

        public bool UpdateEmployee(EmployeeInfo employeeInfo);
    }
}
