using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method
{
    public abstract class Disco
    {
        public double Capacidad { get; set; }
        public double Precio { get; set; }

        public abstract void mostrar();
    }
}
