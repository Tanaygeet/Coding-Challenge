/* Tanaygeet Shrivastava */

using System.Data.SqlClient;

namespace OrderManagemenySystem_DatabaseConnection
{
    public class DBConnUtil
    {
        public static SqlConnection GetDBConn(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}

