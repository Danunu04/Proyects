using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Comida raiz = new AlimentoCompuesto("Menu Principal");
                string opcion = "0";
                while (opcion != "9")
                {
                    Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
                    Console.WriteLine("1. Agregar alimento simple al menú principal");
                    Console.WriteLine("2. Mostrar y eliminar alimento del menú principal");
                    Console.WriteLine("3. Ver calorías totales");
                    Console.WriteLine("4. Agregar alimento compuesto (ej: Ensalada, Tarta) con subalimentos");
                    Console.WriteLine("9. Salir");
                    Console.Write("Opción: ");
                    opcion = Console.ReadLine();

                    if (opcion == "1")
                    {
                        Console.WriteLine("Ingrese el nombre del alimento");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese sus calorias");
                        if (double.TryParse(Console.ReadLine(), out double cal))
                        {
                            raiz.Agregar(new AlimentoSimple(cal, nombre));
                            Console.WriteLine($"{nombre} Agregado al menú");
                        }
                        else
                        {
                            Console.WriteLine("❌ Calorías inválidas.");
                        }
                    }
                    else if (opcion == "2")
                    {
                        var hijos = raiz.GetChild();
                        if (hijos.Count == 0)
                        {
                            Console.WriteLine("No hay hijos");
                            continue;
                        }
                        Console.WriteLine("Alimentos cargados");
                        for (int i = 0; i < hijos.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {hijos[i].Nombre}");
                            Console.WriteLine("¿Cual desea eliminar? (número): ");
                            int index = int.Parse(Console.ReadLine());
                            if (index >= 1 && index <= hijos.Count)
                            {
                                raiz.Eliminar(hijos[index - 1]);
                                Console.WriteLine("Eliminado");
                            }
                            else
                            {
                                Console.WriteLine("Error");
                            }
                        }
                    }
                    else if (opcion == "3")
                    {
                        Console.WriteLine($"Calorias totales del menú: {raiz.ContarCalorias()}");
                    }
                    else if (opcion == "4") 
                    {
                        Console.Write("Nombre del alimento compuesto: ");
                        string nombreCompuesto = Console.ReadLine();
                        var nuevoCompuesto = new AlimentoCompuesto(nombreCompuesto);
                        raiz.Agregar(nuevoCompuesto);
                        Console.WriteLine($"{nombreCompuesto} agregado");

                        string seguir = "s";
                        while (seguir.ToLower() == "s")
                        {
                            Console.WriteLine("Nombre del alimento a agregar?");
                            string nombresimple = Console.ReadLine();
                            Console.WriteLine("Calorias: ");
                            double calsimple = Convert.ToDouble(Console.ReadLine());
                            if (calsimple > 0)
                            {
                                nuevoCompuesto.Agregar(new AlimentoSimple(calsimple, nombresimple));
                                Console.WriteLine("Agregar otro compuesto? (s/n)");
                                seguir = Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Error");
                                seguir = "n";
                            }
                        }
                    }
                }
                Console.WriteLine("👋 Fin del programa.");
            }
            catch
            {
                throw new Exception("Hubo errores en la carga de datos, respeta las entradas");
            }
        }
    }
}
