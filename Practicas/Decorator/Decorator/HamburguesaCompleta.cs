using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class HamburguesaCompleta: Hamburguesa
    {
        public override double Costo => 200;

        public override string Descripcion => "Hamburguesa completa";

    }
}
