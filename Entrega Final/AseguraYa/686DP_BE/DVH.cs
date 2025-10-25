using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_BE
{
    public class DVH
    {
        public string DP686NombreTabla { get; set; }
        public string PK_Valor { get; set; }
        public string DVH_Anterior { get; set; }

        public DVH() { }

        public DVH(string nombreTabla, string pkValor, string dvhAnterior)
        {
            DP686NombreTabla = nombreTabla;
            PK_Valor = pkValor;
            DVH_Anterior = dvhAnterior;
        }
    }
}
