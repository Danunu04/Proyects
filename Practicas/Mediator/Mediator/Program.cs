using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chat sala = new Chat();

            Console.WriteLine("=== Bienvenido al Chat Grupal ===");

            while (true)
            {
                Console.Write("Ingrese nombre de usuario para registrar (o escriba 'listo' para continuar): ");
                string nombre = Console.ReadLine();
                if (nombre.ToLower() == "listo")
                    break;

                Usuario nuevo = new Usuario(nombre);
                sala.registrar(nuevo);
                Console.WriteLine($"Usuario '{nombre}' registrado.");
            }

            Console.Clear();
            Console.WriteLine("=== Chat iniciado ===");

            while (true)
            {
                Console.WriteLine("\nUsuarios conectados:");
                sala.MostrarUsuarios();

                Console.Write("¿Quién envía el mensaje? (o 'salir' para terminar): ");
                string emisorNombre = Console.ReadLine();
                if (emisorNombre.ToLower() == "salir") break;

                Usuario emisor = sala.ObtenerUsuario(emisorNombre);
                if (emisor == null)
                {
                    Console.WriteLine(" Usuario no encontrado.");
                    continue;
                }

                Console.Write("Escriba el mensaje: ");
                string mensaje = Console.ReadLine();

                emisor.enviar(mensaje);
            }

            Console.WriteLine("Chat finalizado. ¡Hasta luego!");
        }
    }
}

