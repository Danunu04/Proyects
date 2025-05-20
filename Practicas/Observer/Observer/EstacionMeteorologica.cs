using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class EstacionMeteorologica: Iestacion
    {
        private string nombre;
        public EstacionMeteorologica(string nom)
        {
            this.nombre = nom;
        }
        public void actualizar (float Temperatura)
        {
            Console.WriteLine($"[{nombre}] Temperatura registrada: {Temperatura}°C");
        }
    }
}
