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

        public void getAllLines()
        {
            DataTable dt = new DataTable();
            //open connection and create a query, than run the query by running the reader.
            cmd.Connection = conn;
            cmd.CommandText = " SELECT NON EMPTY { [Measures].[Yo Yo Data Count] } ON COLUMNS, NON EMPTY { ([Line].[Line].[Line].ALLMEMBERS * [Reason].[Reason].[Reason].ALLMEMBERS * [Product Description].[Description].[Description].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM [Yo Yo DB] CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            conn.Open();
            rdr = cmd.ExecuteReader();

            
            DataColumn column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "line";
            column.ReadOnly = true;
            dt.Columns.Add(column);
            DataColumn column2 = new DataColumn();
            column2.DataType = System.Type.GetType("System.String");
            column2.ColumnName = "reason";
            dt.Columns.Add(column2);
            DataColumn column3 = new DataColumn();
            column3.DataType = System.Type.GetType("System.String");
            column3.ColumnName = "description";
            dt.Columns.Add(column3);
            DataColumn column4 = new DataColumn();
            column4.DataType = System.Type.GetType("System.String");
            column4.ColumnName = "dataCount";
            dt.Columns.Add(column4);

            while (rdr.Read())
            {
                string line = rdr.GetString(0);
                string reason = rdr.GetString(1);
                string description = rdr.GetString(2);
                string yoyoDataCount = rdr.GetString(3);

                DataRow dtR = dt.NewRow();

                dtR["line"] = line;
                dtR["reason"] = reason;
                dtR["description"] = description;
                dtR["dataCount"] = yoyoDataCount;

                dt.Rows.Add(dtR);
            }
            rdr.Close();
            conn.Close();
        }
    }
}
