using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class Memento
    {
        private readonly string _estado;

        public Memento(string estado)
        {
            _estado = estado;
        }

        public string GetEstado()
        {
            return _estado;
        }
    }
}
