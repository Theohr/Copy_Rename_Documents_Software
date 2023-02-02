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
        static string oradb = "Data Source="";Persist Security Info=True;User ID="";Password="";";
        public static OracleConnection orclConn = new OracleConnection(oradb);
    }
}
