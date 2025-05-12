using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method
{
    public class DiscoBluRay: Disco
    {
        public string Tipo { get; set; }
        public DiscoBluRay(string tipo)
        {
            Tipo = tipo;
            if (tipo == "Simple capa")
            {
                Capacidad = 25;
                Precio = 20;
            }
            if (tipo == "Doble capa")
            {
                Capacidad = 50;
                Precio = 40;
            }
        }
        public override void mostrar()
        {
            Console.WriteLine($"Bluray {Tipo} Capa - {Capacidad} GB - u$s {Precio}");
        }
    }
}
