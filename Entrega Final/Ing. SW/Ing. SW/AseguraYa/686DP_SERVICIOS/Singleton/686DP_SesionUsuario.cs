
namespace _686DP_SERVICIOS.Singleton
{
    // Clase que maneja la sesión de usuario en el sistema
    public class _686DP_SesionUsuario
    {
        // Propiedad privada donde se guarda el usuario logueado
        public _686DP_Usuario _usuario { get; set; }

        // Propiedad pública de solo lectura para acceder al usuario actual
        public _686DP_Usuario Usuario
        {
            get
            {
                return _usuario;
            }
        }

        // Método para iniciar sesión: guarda el usuario recibido
        public void _686DPLogIN(_686DP_Usuario usuario)
        {
            _usuario = usuario;
        }

        // Método para cerrar sesión: borra el usuario actual
        public void _686DPLogOut()
        {
            _usuario = null;
        }

        // Método para verificar si hay un usuario logueado
        public bool _686DPIsLogged()
        {
            return _usuario != null;
        }
    }
}
