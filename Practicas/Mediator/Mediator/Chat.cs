using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Chat: Mediator
    {
        private List<Usuario> usuarios = new List<Usuario>();
        public void registrar(Usuario usr)
        {
            if(!usuarios.Contains(usr))
            {
                usuarios.Add(usr);
                usr.chat = this;
            }
        }

        public void enviar (string mensaje, Usuario usr)
        {
            foreach(var usuario in usuarios)
            {
                if(usuario != usr)
                {
                    usuario.recibir(mensaje, usr.Nombre);
                }
            }
        }
        public Usuario ObtenerUsuario(string nombre)
        {
            return usuarios.Find(u => u.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public void MostrarUsuarios()
        {
            Console.WriteLine("Usuarios registrados:");
            foreach (var u in usuarios)
            {
                Console.WriteLine("- " + u.Nombre);
            }
        }
    }
}
