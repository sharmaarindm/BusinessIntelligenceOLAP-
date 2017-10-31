using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AnalysisServices.AdomdClient;
using System.Configuration;

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
            //open connection and create a query, than run the query by running the reader.
            cmd.Connection = conn;
            cmd.CommandText = "SELECT NON EMPTY { [Measures].[Yo Yo Data Count] } ON COLUMNS, NON EMPTY { ([Line].[Line].[Line].ALLMEMBERS ) } DIMENSION PROPERTIES MEMBER_CAPTION, MEMBER_UNIQUE_NAME ON ROWS FROM [Yo Yo DB] CELL PROPERTIES VALUE, BACK_COLOR, FORE_COLOR, FORMATTED_VALUE, FORMAT_STRING, FONT_NAME, FONT_SIZE, FONT_FLAGS";

            conn.Open();
            rdr = cmd.ExecuteReader();

            rdr.Close();
            conn.Close();
        }
    }
}
