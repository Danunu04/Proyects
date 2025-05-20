using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public interface ISensorTemperatura
    {
        //Subject interface

        void agregarEstacion(Iestacion estacion);
        void eliminarEstacion(Iestacion estacion);
        void notificar();
    }
}
