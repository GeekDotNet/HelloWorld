using EmployeeManagement.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Server
{
    public class EmployeeDAO : IEmployeeDAO
    {
        public bool AddEmployee(EmployeeInfo employeeInfo)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetEmployees()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=tcp:azemployeemanagement.database.windows.net,1433;Initial Catalog=employeemanagement;Persist Security Info=False;User ID=kravisha;Password=Samsung1234$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetEmployees", connection))
                    {
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
            

            return dataTable;
        }

        public bool UpdateEmployee(EmployeeInfo employeeInfo)
        {
            throw new NotImplementedException();
        }
    }
}
