using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Monitoramento
{
    public class ControleMonitoramento
    {
        private SqlConnection con;
        private ControleMonitoramento db;

        public ControleMonitoramento()
        {
            con = new SqlConnection
                (ConfigurationManager.ConnectionStrings["SQLSERVER"].
                ConnectionString);
         

        }


        public bool Insert(MonitoramentoModel mm)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Proc_Inserir_MM";
            cmd.Parameters.Add(new SqlParameter("@descricao", mm.Descricao));
            cmd.Parameters.Add(new SqlParameter("@qtd_cameras", mm.Qtd_camera));
            cmd.Parameters.Add(new SqlParameter("@nomeCli", mm.NomeCli));
            cmd.Parameters.Add(new SqlParameter("@valorPacote", mm.Valor_pacote));
            cmd.Parameters.Add(new SqlParameter("@fidelidade", mm.Fidelidade));
            cmd.Parameters.Add(new SqlParameter("@plano", mm.Plano));


            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            

            return true;
        } 
    }
}