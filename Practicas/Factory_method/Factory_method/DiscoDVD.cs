using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method
{
    public class DiscoDVD: Disco
    {
        public string Tipo { get; set; }
        public DiscoDVD(string tipo) 
        {
            Tipo = tipo;    
            if (tipo == "Simple capa")
            {
                Capacidad = 4.7;
                Precio = 5;
            }
            if (tipo == "Doble capa")
            {
                Capacidad = 8.5;
                Precio = 8;
            }
        }
        public override void mostrar()
        {
            Console.WriteLine($"DVD {Tipo} Capa - {Capacidad} GB - u$s {Precio}");
        }
    }
}
