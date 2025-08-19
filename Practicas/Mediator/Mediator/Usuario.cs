using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public Mediator chat { get; set; }

        public Usuario(string nombre)
        {
            Nombre = nombre;
        }

        public void enviar (string mensaje)
        {
            Console.WriteLine($"{Nombre} dice {mensaje}");
            chat.enviar(mensaje, this);
        }

        public void recibir(string mensaje, string emisor)
        {
            Console.WriteLine($"[{Nombre} recibe mensaje de {emisor}]");
        }
    }
}
