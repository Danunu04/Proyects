using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var composite = new Subdivisión_Compuesto();
            composite.Agregar(new Cuadrante("Agua"));
            var sub = new Subdivisión_Compuesto();
            composite.Agregar(sub);
            string opcion= "";
            while (opcion != "9")
            {
                Console.WriteLine("Ingrese que quere agregar al cuadrante");
                Console.WriteLine(" 1. Agua");
                Console.WriteLine(" 2. Tierra");
                Console.WriteLine(" 3. Calcular Porcentaje");
                Console.WriteLine(" 9. Salir");
                Console.WriteLine(" Ingresa la opcion: ");
                opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    sub.Agregar(new Cuadrante("Agua"));
                    Console.WriteLine("Contenido actual del subcuadrante:");
                    int i = 1;
                    foreach (var hijo in sub.ObtenerHijos())
                    {
                        string tipo = hijo.EsAgua() ? "Agua" : "Tierra";
                        Console.WriteLine($"Parte {i}: {tipo}");
                        i++;
                    }
                }
                else if (opcion == "2")
                {
                    sub.Agregar(new Cuadrante("Tierra"));
                    Console.WriteLine("Contenido actual del subcuadrante:");
                    int i = 1;
                    foreach (var hijo in sub.ObtenerHijos())
                    {
                        string tipo = hijo.EsAgua() ? "Agua" : "Tierra";
                        Console.WriteLine($"Parte {i}: {tipo}");
                        i++;
                    }
                }
                else if (opcion == "3")
                {
                    double porcentaje = composite.CalcularAgua() * 100;
                    Console.WriteLine($"Porcentaje anegado {porcentaje}% ");
                }
                else if(opcion != "9")
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
}
