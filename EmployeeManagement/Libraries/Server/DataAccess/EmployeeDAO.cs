using EmployeeManagement.Common;
using Microsoft.Extensions.Configuration;
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
        IConfiguration _configuration;
        public EmployeeDAO(IConfiguration configuration )
        {
            _configuration = configuration;
        }
        public bool DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetEmployee(long id)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AzSQLServerConnection")))
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("GetEmployee", connection))
                    {
                        sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sqlDataAdapter.SelectCommand.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                        sqlDataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }


            return dataTable;
        }

        public DataTable GetEmployees()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AzSQLServerConnection")))
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

        public bool AddOrUpdateEmployeeInfo(EmployeeInfo employeeInfo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("AzSQLServerConnection")))
                {
                    using (SqlCommand command = new SqlCommand("UpsertEmployeeInfo", connection))
                    {
                        connection.Open();
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.BigInt).Value = employeeInfo.Id;
                        command.Parameters.Add("@Name", SqlDbType.NVarChar,50).Value = employeeInfo.Name;
                        command.Parameters.Add("@Department", SqlDbType.NVarChar, 20).Value = employeeInfo.Department;
                        command.Parameters.Add("@Designation", SqlDbType.NVarChar, 20).Value = employeeInfo.Designation;
                        command.Parameters.Add("@PhotoPath", SqlDbType.NVarChar, 255).Value = employeeInfo.PhotoPath;
                        command.Parameters.Add("@JoinDate", SqlDbType.DateTime).Value = employeeInfo.JoinDate.Date;
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                //throw;
                return false;
            }
        }
    }
}
