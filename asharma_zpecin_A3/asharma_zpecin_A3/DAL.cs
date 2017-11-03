using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AnalysisServices.AdomdClient;
using System.Configuration;
using System.Data;

namespace asharma_zpecin_A3
{
    
    class DAL
    {
        AdomdCommand cmd = new AdomdCommand();
        AdomdDataReader rdr;
        AdomdConnection conn = new AdomdConnection();

        public DAL()
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["DALConnectString"].ConnectionString;
        }

        public DataTable getAllLines(string line, string description)
        {
            DataTable dt = new DataTable();
            //open connection and create a query, than run the query by running the reader.
            cmd.Connection = conn;
            cmd.CommandText = "SELECT NON EMPTY { [Measures].[Yo Yo Data Count] } ON COLUMNS, NON EMPTY { ( [Reason].[Reason].[Reason] ) } ON ROWS FROM [Yo Yo DB] WHERE {[Line].[Line].["+line+"]} * {[Product Description].[Description].["+description+"]}";

            conn.Open();
            rdr = cmd.ExecuteReader();

            
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "reason";
            column.ReadOnly = true;
            dt.Columns.Add(column);
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "dataCount";
            dt.Columns.Add(column);

            int i = 0;
            while (rdr.Read())
            {
                if (i == 0)
                {
                    i++;
                }
                else
                {
                    string reason = rdr.GetString(0);
                    string yoyoDataCount = rdr.GetString(1);

                    DataRow dtR = dt.NewRow();


                    dtR["reason"] = reason;
                    dtR["dataCount"] = yoyoDataCount;

                    dt.Rows.Add(dtR);
                }
            }
            rdr.Close();
            conn.Close();
            return dt;
        }
    }
}
