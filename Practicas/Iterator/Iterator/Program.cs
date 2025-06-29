using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Playlist playlist = new Playlist();
            playlist.Agregar(new Cancion("Bohemian Rhapsody"));
            playlist.Agregar(new Cancion("Stairway to Heaven"));
            playlist.Agregar(new Cancion("Imagine"));

            I_iterator iterador = playlist.CrearIterador();

            Console.WriteLine("Bienvenido al Reproductor de Playlist");
            Console.WriteLine("Presione ENTER para reproducir la siguiente canción o escriba 'salir' para terminar.");

            while (iterador.tienesiguiente())
            {
                Console.Write("\n> ");
                string entrada = Console.ReadLine()?.Trim().ToLower();

                if (entrada == "salir")
                {
                    Console.WriteLine("Reproducción detenida.");
                    break;
                }

                var cancion = iterador.Siguiente();
                Console.WriteLine($"Reproduciendo: {cancion.Titulo}");
            }

            if (!iterador.tienesiguiente())
                Console.WriteLine("\nFin de la playlist.");
                Console.ReadKey();
        }
    }
}
