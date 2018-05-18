using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monitoramento
{
    public class MonitoramentoModel
    {
        public String Descricao { get; set; }
        public int Qtd_camera { get; set; }
        public String NomeCli { get; set; }
        public decimal Valor_pacote { get; set; }
        public Boolean Fidelidade { get; set; }
        public String Plano { get; set; }
    }
}