using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method
{
    internal class BluRayFactory: Disqueria
    {
        private string tipo;
        public BluRayFactory(string Tipo)
        {
            this.tipo = Tipo;
        }
        public override Disco CrearDisco()
        {
            return new DiscoBluRay(tipo);
        }
    }
}
