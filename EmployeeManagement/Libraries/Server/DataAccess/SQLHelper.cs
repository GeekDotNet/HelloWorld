using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Server
{
    public class SQLHelper
    {

    //    public DataSet FillDataSet(string sqlConnection, CommandType commandType, string commandText, List<SqlParameter> parameters)
    //    {
    //        using (SqlConnection connection = new SqlConnection(sqlConnection))
    //        {

    //        }
    //    }
    //    private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, 
    //        string commandText, List<SqlParameter> sqlParameters, out bool mustCloseConnection)
    //    {
    //        if (command == null)
    //            throw new ArgumentException("command");
    //        if (string.IsNullOrWhiteSpace(commandText))
    //            throw new ArgumentException("commandText");

    //        if (connection.State != ConnectionState.Open)
    //        {
    //            mustCloseConnection = true;
    //            connection.Open();
    //        }
    //        else
    //            mustCloseConnection = false;


    //        command.Connection = connection;
    //        command.CommandText = commandText;

    //        if(transaction!=null)
    //        {
    //            if(transaction.Connection==null)
    //                throw new ArgumentNullException("InvalidTransaction","transaction")
    //        }
    //    }
   }
}
