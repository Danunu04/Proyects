using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method
{
    public class DVDFactory: Disqueria
    {
        private string tipo;
        public DVDFactory(string tipo)
        {
            this.tipo = tipo;
        }
        public override Disco CrearDisco()
        {
            return new DiscoDVD(tipo);
        }
    }
}
