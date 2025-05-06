using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_SERVICIOS.Singleton
{
    public class _686DP_Singleton
    {
        private static _686DP_SesionUsuario _instancia;
        private static readonly object _lock = new object();//Es una forma de evitar que dos hilos (threads) accedan al mismo tiempo a la creación de la instancia.

        public static _686DP_SesionUsuario Instancia
        {
            get
            {
                lock (_lock)// Bloqueo para asegurar seguridad en apps multihilo
                {
                    if (_instancia == null)
                    { _instancia = new _686DP_SesionUsuario(); }
                }
                return _instancia;
            }
        }
    }
}
