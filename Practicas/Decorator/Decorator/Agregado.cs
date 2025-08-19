using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Agregado : Hamburguesa
    {
        public Hamburguesa _hamburguesa;

        public Agregado(Hamburguesa ham)
        {
            _hamburguesa = ham;
        }
    }
}
