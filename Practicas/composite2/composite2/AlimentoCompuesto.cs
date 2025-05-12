using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite2
{
    public class AlimentoCompuesto: Comida
    {
        private List<Comida> ComidaList = new List<Comida>();

        private string nombre;
        public AlimentoCompuesto(string nombre)
        {
            this.nombre = nombre;
        }
        public override string Nombre => nombre;
        public override void Agregar(Comida comida)
        {
            if(!ComidaList.Contains(comida))
            {
                ComidaList.Add(comida);
            }
            else
            {
                Console.WriteLine("Ya tienes esa comida en el plato");
            }
        }

        public override void Eliminar(Comida comida)
        {
            if(ComidaList.Contains(comida))
            {
                ComidaList.Remove(comida);
            }
            else
            {
                Console.WriteLine("No tienes esa comida en el plato, no se puede eliminar");
            }
        }
        public override Comida Buscar(AlimentoSimple comida)
        {
            if (ComidaList.Contains(comida))
            {
                return comida;
            }
            else
            {
                Console.WriteLine("No tienes esa comida en el plato, no se puede eliminar");
                return null;
            }
        }

        public override List<Comida> GetChild()
        {
            return ComidaList;
        }

        public override double ContarCalorias()
        {
            double suma= 0;
            foreach(Comida comida in ComidaList)
            {
                suma += comida.ContarCalorias();
            }
            return suma;
        }
    }
}
