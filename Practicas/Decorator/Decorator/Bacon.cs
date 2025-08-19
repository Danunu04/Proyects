using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Bacon:Agregado
    {
        public Bacon(Hamburguesa ham) : base(ham) { }

        public override double Costo => _hamburguesa.Costo + 150;
        public override string Descripcion => $"{_hamburguesa.Descripcion}, bacon extra";
    }
}
