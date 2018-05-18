using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Monitoramento
{
    public class ConnectionSQLServer
    {
        SqlConnection con;

        public SqlConnection getConnectionSQlServer()
        {
            string _conexao =
            ConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;

            con = new SqlConnection();
            con.ConnectionString = _conexao;
            return con;
        }
    }
}