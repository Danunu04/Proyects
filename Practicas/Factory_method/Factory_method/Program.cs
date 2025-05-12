using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_method
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Disco disco;
            Disqueria disqueria;

            Console.WriteLine("Seleccione una opcion");
            Console.WriteLine("1. Crear DVD");
            Console.WriteLine("2. Crear Bluray");
            Console.WriteLine("Ingrese una opcion: ");
            string opcion = Console.ReadLine();


            while (opcion != "1" && opcion != "2")
            {
                Console.WriteLine("Error de seleccion");
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine("1. Crear DVD");
                Console.WriteLine("2. Crear Bluray");
                Console.WriteLine("Ingrese una opcion: ");
                opcion = Console.ReadLine();
            }
            if (opcion == "1")
            {
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine("1. Simple Banda");
                Console.WriteLine("2. Doble Banda");
                Console.WriteLine("Ingrese una opcion: ");
                string choice = Console.ReadLine();
                while (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Error de seleccion");
                    Console.WriteLine("Seleccione una opcion");
                    Console.WriteLine("1. Simple Banda");
                    Console.WriteLine("2. Doble Banda");
                    Console.WriteLine("Ingrese una opcion: ");
                    choice = Console.ReadLine();
                }
                if(choice == "1")
                {
                    string tipo = "Simple capa";
                    disqueria = new DVDFactory(tipo);
                    disco = disqueria.CrearDisco();  // ✅ Usás la fábrica
                    disco.mostrar();
                }
                else if(choice == "2")
                {
                    string tipo = "Simple capa";
                    disqueria = new DVDFactory(tipo);
                    disco = disqueria.CrearDisco();  // ✅ Usás la fábrica
                    disco.mostrar();
                }

            }
            else if (opcion == "2")
            {
                Console.WriteLine("Seleccione una opcion");
                Console.WriteLine("1. Simple Banda");
                Console.WriteLine("2. Doble Banda");
                Console.WriteLine("Ingrese una opcion: ");
                string choice = Console.ReadLine();
                while (choice != "1" && choice != "2")
                {
                    Console.WriteLine("Error de seleccion");
                    Console.WriteLine("Seleccione una opcion");
                    Console.WriteLine("1. Simple Banda");
                    Console.WriteLine("2. Doble Banda");
                    Console.WriteLine("Ingrese una opcion: ");
                    choice = Console.ReadLine();
                }
                if (choice == "1")
                {
                    string tipo = "Simple capa";
                    disqueria = new BluRayFactory(tipo);
                    disco = disqueria.CrearDisco();  // ✅ Usás la fábrica
                    disco.mostrar();
                }
                else if (choice == "2")
                {
                    string tipo = "Simple capa";
                    disqueria = new BluRayFactory(tipo);
                    disco = disqueria.CrearDisco();  // ✅ Usás la fábrica
                    disco.mostrar();
                }
            }
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
