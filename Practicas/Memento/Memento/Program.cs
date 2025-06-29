using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EditorDeTexto editor = new EditorDeTexto();
            CareTaker historial = new CareTaker();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Escribir texto");
                Console.WriteLine("2. Mostrar contenido");
                Console.WriteLine("3. Deshacer");
                Console.WriteLine("4. Salir");
                Console.Write("Elegí una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Escribí algo: ");
                        string texto = Console.ReadLine();
                        historial.add(editor.GuardarEstado()); // Guarda antes de modificar
                        editor.escribir(texto);
                        Console.WriteLine("Texto agregado.");
                        break;

                    case "2":
                        editor.MostrarContenido();
                        break;

                    case "3":
                        editor.restaurar(historial.undo());
                        Console.WriteLine("Se deshizo la última acción.");
                        break;

                    case "4":
                        salir = true;
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
    }
}
