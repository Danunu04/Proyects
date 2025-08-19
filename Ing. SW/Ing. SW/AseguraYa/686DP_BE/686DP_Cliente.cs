using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_BE
{
    public class _686DP_Cliente
    {

        public int DP686_DNI { get; set; }
        public string DP686_Nombre { get; set; }
        public string DP686_Apellido { get; set; }
        public string DP686_Email { get; set; }
        public int? DP686_NTarjeta { get; set; }
        public string DP686_Domicilio { get; set; }
        public int? DP686DP_CodigoPostal { get; set; }
        public int? DP686_CuitCuil { get; set; }
        public string DP686_CondicionIVA { get; set; }
        public bool? DP686_Estado { get; set; }
        public string DP686_TitularTarjeta { get; set; }
        public string DP686_medioPago { get; set; }
        public DateTime DP686_FechaVencimiento { get; set; }

        public _686DP_Cliente(int dni, string nombre, string apellido)
        {
            DP686_DNI = dni;
            DP686_Nombre = nombre;
            DP686_Apellido = apellido;
        }
    }
}
