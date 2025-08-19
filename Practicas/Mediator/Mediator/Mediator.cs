using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public interface Mediator
    {
        void enviar(string mensaje, Usuario emisor);
        void registrar(Usuario usuario);
    }
}
