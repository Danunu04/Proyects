using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite2
{
    public abstract class Comida
    {
        public virtual string Nombre => "";  // por defecto vacío
        public virtual void Agregar(Comida comida) { throw new Exception("No se implementa acá, solo se define "); }
        public virtual void Eliminar(Comida comida) { throw new Exception("No se implementa acá, solo se define "); }
        public virtual Comida Buscar(AlimentoSimple comida) { throw new Exception("No se implementa acá, solo se define "); }

        public virtual List<Comida> GetChild() { throw new Exception("No se implementa acá, solo se define"); }

        public abstract double ContarCalorias();
    }
}
