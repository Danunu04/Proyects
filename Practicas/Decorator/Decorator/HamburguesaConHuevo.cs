using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class HamburguesaConHuevo: Hamburguesa
    {
        public override double Costo => 250;

        public override string Descripcion => "Hamburguesa con huevo";
    }
}
