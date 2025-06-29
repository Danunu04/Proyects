using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Papa : Agregado
    {
        public Papa(Hamburguesa ham): base(ham) { }

        public override double Costo => _hamburguesa.Costo + 100;
        public override string Descripcion => $"{_hamburguesa.Descripcion}, Papas agregadas";

    }
}
