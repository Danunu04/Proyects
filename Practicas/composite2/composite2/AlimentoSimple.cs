using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite2
{
    public class AlimentoSimple: Comida
    {
        private double Caloria;
        public override string Nombre => this.nombre; // asumí que tenés el campo así

        private string nombre;

        public AlimentoSimple(double cal, string nombre)
        {
            this.Caloria = cal;
            this.nombre = nombre;
        }
        public override double ContarCalorias()
        {
            return Caloria;
        }
    }
}
