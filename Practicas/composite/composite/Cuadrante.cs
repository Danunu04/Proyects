using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite
{
    public class Cuadrante : Superficie_Composite
    {
        private string tipo;
        public Cuadrante(string tipo)
        {
            this.tipo = tipo;
        }
        public override bool EsAgua() => tipo == "Agua";
        public override bool EsTierra() => tipo == "Tierra";
        public override double CalcularAgua() => EsAgua() ? 1.0 : 0.0;
    }
}
