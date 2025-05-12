using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite
{
    public abstract class Superficie_Composite
    {
        public virtual void Agregar(Superficie_Composite s) { throw new NotImplementedException(); }
        public virtual void eliminar(Superficie_Composite s) { throw new NotImplementedException(); }
        public virtual List<Superficie_Composite> ObtenerHijos() { throw new NotImplementedException(); }
        public abstract bool EsAgua();
        public abstract bool EsTierra();
        public abstract double CalcularAgua();
    }
}
