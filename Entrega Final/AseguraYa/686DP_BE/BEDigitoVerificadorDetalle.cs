using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_BE
{
    public class BEDigitoVerificadorDetalle
    {
        public string DP686NombreTabla { get; set; }
        public string PK_Valor { get; set; }
        public string DVH_Anterior { get; set; }

        public BEDigitoVerificadorDetalle() { }

        public BEDigitoVerificadorDetalle(string tabla, string pk, string dvh)
        {
            DP686NombreTabla = tabla;
            PK_Valor = pk;
            DVH_Anterior = dvh;
        }
    }
}
