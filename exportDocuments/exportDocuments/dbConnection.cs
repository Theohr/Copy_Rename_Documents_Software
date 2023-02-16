using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace danaosDocuments
{
    class dbConnection
    {
        // Danaos Oracle Connection String with global Connection
        static string oradb = "Data Source=db_host;Persist Security Info=True;User ID=db_username;Password=db_password;";
        public static OracleConnection orclConn = new OracleConnection(oradb);
    }
}
