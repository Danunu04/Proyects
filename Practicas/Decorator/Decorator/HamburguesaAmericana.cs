using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class HamburguesaAmericana: Hamburguesa
    {
        public override double Costo => 260;

        public override string Descripcion => "Hamburguesa americana";
    }
}
