using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace danaosDocuments
{
    class dbData
    {
        //*****************************************************************************************
        //Run Queries on Oracle Danaos Database and insert data into DataTable then return
        //*****************************************************************************************
        OracleCommand orclCmd = new OracleCommand();

        public static DataTable retreiveDataDanaos(string orclCmd1)
        {

            DataTable dt = new DataTable("DanaosDataTable");

            try
            {
                dbConnection.orclConn.Close();
            }
            catch (InvalidOperationException ex)
            {

            }

            try
            {
                dbConnection.orclConn.Open();
            }
            catch (InvalidOperationException ex)
            {

            }

            OracleDataAdapter dr = new OracleDataAdapter(orclCmd1, dbConnection.orclConn);

            dt.Clear();
            dr.Fill(dt);

            try
            {
                dbConnection.orclConn.Close();
            }
            catch (InvalidOperationException ex)
            {

            }

            return dt;
        }
    }
}
