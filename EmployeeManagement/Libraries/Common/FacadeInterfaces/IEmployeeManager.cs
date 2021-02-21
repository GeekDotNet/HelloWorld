using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common
{
    public interface IEmployeeManager
    {
        public List<EmployeeInfo> GetEmployees();

        public EmployeeInfo GetEmployee(long id);


        public bool DeleteEmployee(long id);

        public bool AddOrUpdateEmployeeInfo(EmployeeInfo employeeInfo);
    }
}
