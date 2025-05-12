using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite
{
    public class Subdivisión_Compuesto: Superficie_Composite
    {
        private List<Superficie_Composite> partes = new List<Superficie_Composite>();
        public override void Agregar(Superficie_Composite superficie)
        {
            if (partes.Count < 4)
            {
                partes.Add(superficie);
            }
            else
            {
                Console.WriteLine("No se puede agregar mas de 4 partes.");
            }
        }
        public override void eliminar(Superficie_Composite s)
        {
            partes.Remove(s);
        }
        public override List<Superficie_Composite> ObtenerHijos() => partes;

        public override bool EsAgua()
        {
            foreach (var p in partes)
            {
                if(!p.EsAgua())return false;
            }
            return true;
        }
        public override bool EsTierra()
        {
            foreach (var p in partes)
            {
                if (!p.EsTierra()) return false;
            }
            return true;
        }
        public override double CalcularAgua()
        {
            double suma = 0;
            foreach (var p in partes)
            {
                suma += p.CalcularAgua();
            }
            return suma/partes.Count;
        }
    }
}
