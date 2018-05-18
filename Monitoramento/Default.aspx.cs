using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Monitoramento
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregaGrid();

            if (!IsPostBack)
            {
                return;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            CalculaPacote();

            try
            {

                MonitoramentoModel mm = new MonitoramentoModel();
                mm.Descricao = txtdescricao.Text;
                mm.NomeCli = txtnome.Text;
                mm.Qtd_camera = Convert.ToInt32(txtqtd_camera.Text);
                mm.Valor_pacote = Convert.ToDecimal(txtvalor_pacote.Text);
                mm.Plano = txtplano.Text;
                mm.Fidelidade = chckfidelidade.Checked;

                new ControleMonitoramento().Insert(mm);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro Salvo Com Sucesso')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+ex.Message+"')", true);
            }

            Dispose();
            carregaGrid();
            
        }

        public void CalculaPacote() {


            if (String.IsNullOrWhiteSpace(txtvalor_pacote.Text))
                txtvalor_pacote.Text = "0";

            if (Convert.ToInt32(txtqtd_camera.Text) <= 0 && Convert.ToDecimal(txtvalor_pacote.Text) <= 0)
            {
                txtplano.Text = "";
                txtvalor_total.Text = "";
                return;
            }

            if (Convert.ToInt32(txtqtd_camera.Text) <= 2 && !chckfidelidade.Checked)
            {
                txtplano.Text = "Cliente Padrao";

                if (Convert.ToDecimal(txtvalor_pacote.Text) > 0) {
                    decimal valorpacote = Convert.ToDecimal(txtvalor_pacote.Text);
                    txtvalor_total.Text = (valorpacote - ((valorpacote * 5) / 100)).ToString();
                }
            }

            if (Convert.ToInt32(txtqtd_camera.Text) >= 3 && Convert.ToInt32(txtqtd_camera.Text) <= 4 && !chckfidelidade.Checked)
            {
                txtplano.Text = "Cliente Intermediario";
                if (Convert.ToDecimal(txtvalor_pacote.Text) > 0)
                {
                    decimal valorpacote = Convert.ToDecimal(txtvalor_pacote.Text);
                    txtvalor_total.Text = (valorpacote - ((valorpacote * 10) / 100)).ToString();
                }
            }

            if (Convert.ToInt32(txtqtd_camera.Text) >= 5  && !chckfidelidade.Checked)
            {
                txtplano.Text = "Cliente Avancado";
                if (Convert.ToDecimal(txtvalor_pacote.Text) > 0)
                {
                    decimal valorpacote = Convert.ToDecimal(txtvalor_pacote.Text);
                    txtvalor_total.Text = (valorpacote - ((valorpacote * 15) / 100)).ToString();
                }
            }

            if (Convert.ToInt32(txtqtd_camera.Text) <= 2 && chckfidelidade.Checked)
            {
                txtplano.Text = "Cliente Padrao";
                if (Convert.ToDecimal(txtvalor_pacote.Text) > 0)
                {
                    decimal valorpacote = Convert.ToDecimal(txtvalor_pacote.Text);
                    txtvalor_total.Text = (valorpacote - ((valorpacote * 10) / 100)).ToString();
                }
            }

            if (Convert.ToInt32(txtqtd_camera.Text) >= 3 && Convert.ToInt32(txtqtd_camera.Text) <= 4 && chckfidelidade.Checked)
            {
                txtplano.Text = "Cliente Intermediario";
                if (Convert.ToDecimal(txtvalor_pacote.Text) > 0)
                {
                    decimal valorpacote = Convert.ToDecimal(txtvalor_pacote.Text);
                    txtvalor_total.Text = (valorpacote - ((valorpacote * 20) / 100)).ToString();
                }
            }

            if (Convert.ToInt32(txtqtd_camera.Text) >= 5  && chckfidelidade.Checked)
            {
                txtplano.Text = "Cliente Avancado";
                if (Convert.ToDecimal(txtvalor_pacote.Text) > 0)
                {
                    decimal valorpacote = Convert.ToDecimal(txtvalor_pacote.Text);
                    txtvalor_total.Text = (valorpacote - ((valorpacote * 30) / 100)).ToString();
                }
            }

        }

        protected void txtqtd_camera_TextChanged(object sender, EventArgs e)
        {
            CalculaPacote();
        }

        protected void txtvalor_pacote_TextChanged(object sender, EventArgs e)
        {
            CalculaPacote();
        }

        protected void chckfidelidade_CheckedChanged(object sender, EventArgs e)
        {
            CalculaPacote();
        }

        public void carregaGrid() {

            
             GridMonitoramento.DataSource = ResgataUsuarios();
             GridMonitoramento.DataBind(); 
        }

        public List<RetornoGrid> ResgataUsuarios()
        {
            List<RetornoGrid> mon = new List<RetornoGrid>();
            string connString =  WebConfigurationManager.ConnectionStrings["SQLSERVER"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand("SELECT nomeCli, plano, fidelidade FROM tb_monitora", con);
            SqlDataReader retorno = null;
            try
            {
                con.Open();
                retorno = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (retorno.Read())
                {
                    RetornoGrid mm = new RetornoGrid();
                    mm.Nome_Cliente = retorno["nomeCli"].ToString();
                    mm.Plano = retorno["plano"].ToString();
                    mm.Fidelidade = Convert.ToBoolean(retorno["fidelidade"].ToString());
                    mon.Add(mm);
                }
            }
            finally
            {
                if (retorno != null)
                    retorno.Close();
            }
            return mon;
        }
    }
}