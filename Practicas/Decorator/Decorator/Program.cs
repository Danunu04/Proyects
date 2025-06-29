using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hamburguesa hamburguesaseleccionada = null;

            int opcion = 0;
            while(opcion != 9)
            {
                Console.WriteLine("Seleccione la hamburguesa deseada: ");
                Console.WriteLine("1. Hamburguesa completa");
                Console.WriteLine("2. Haburguesa Americana");
                Console.WriteLine("3. Hamburguesa con huevo");
                Console.WriteLine("9. Salir");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("La opcion seleccionada debe ser un numero");
                    continue;
                }
                switch (opcion)
                {
                    case 1:
                        hamburguesaseleccionada = new HamburguesaCompleta();
                        aditivo(hamburguesaseleccionada);
                        Console.WriteLine($"El producto seleccionado es: {hamburguesaseleccionada.Descripcion.ToString()} y tiene el costo de {hamburguesaseleccionada.Costo}");
                        break;
                    case 2:
                        hamburguesaseleccionada = new HamburguesaAmericana();
                        aditivo(hamburguesaseleccionada);
                        Console.WriteLine($"El producto seleccionado es: {hamburguesaseleccionada.Descripcion.ToString()} y tiene el costo de {hamburguesaseleccionada.Costo}");
                        break;
                    case 3:
                        hamburguesaseleccionada = new HamburguesaConHuevo();
                        aditivo(hamburguesaseleccionada);
                        Console.WriteLine($"El producto seleccionado es: {hamburguesaseleccionada.Descripcion.ToString()} y tiene el costo de {hamburguesaseleccionada.Costo}");
                        break;
                    case 9:
                        Console.WriteLine("ignorando...");
                        break;
                    default:
                        Console.WriteLine("error");
                        break;
                }
                
            }

        }

        private static void aditivo(Hamburguesa hamburguesaseleccionada)
        {
            int opcion = 0;
            Console.WriteLine("Desea algun aditivo? ");
            Console.WriteLine("1. Papas");
            Console.WriteLine("2. Queso");
            Console.WriteLine("3. Bacon");
            Console.WriteLine("9. Salir");
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("La opcion seleccionada debe ser un numero");
                aditivo(hamburguesaseleccionada);
            }
            switch (opcion)
            {
                case 1:
                    hamburguesaseleccionada = new Papa(hamburguesaseleccionada);
                    break;
                case 2:
                    hamburguesaseleccionada = new Queso(hamburguesaseleccionada);
                    break;
                case 3:
                    hamburguesaseleccionada = new Bacon(hamburguesaseleccionada);
                    break;
                case 9:
                    Console.WriteLine("ignorando...");
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
