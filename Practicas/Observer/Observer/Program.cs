using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SensorTemperatura sensorTemp = new SensorTemperatura();
            Dictionary<string, EstacionMeteorologica> estaciones = new Dictionary<string, EstacionMeteorologica>();

            string opcion = "0";
            
            while (opcion != "4")
            {
                Console.WriteLine("\n--- MENÚ ---");
                Console.WriteLine("1. Agregar estación");
                Console.WriteLine("2. Quitar estación");
                Console.WriteLine("3. Cambiar temperatura");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        {
                            Console.Write("Nombre de la estación: ");
                            string nombreAgregar = Console.ReadLine();
                            if(!estaciones.ContainsKey(nombreAgregar))
                            {
                                var estacion = new EstacionMeteorologica(nombreAgregar);
                                estaciones[nombreAgregar] = estacion;
                                sensorTemp.agregarEstacion(estacion);
                                Console.WriteLine($"✔ Estación '{nombreAgregar}' suscripta.");
                            }
                            else
                            {
                                Console.WriteLine("⚠ Esa estación ya está suscripta.");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Nombre de la estación: ");
                            string nombreQuitar = Console.ReadLine();
                            if (estaciones.ContainsKey(nombreQuitar))
                            {
                                sensorTemp.eliminarEstacion(estaciones[nombreQuitar]);
                                estaciones.Remove(nombreQuitar);
                                Console.WriteLine($"❌ Estación '{nombreQuitar}' desuscripta.");
                            }
                            else
                            {
                                Console.WriteLine("⚠ Esa estación no está suscripta.");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Nueva temperatura: ");
                            if (float.TryParse(Console.ReadLine(), out float temp))
                            {
                                sensorTemp.setTemp(temp);
                            }
                            else
                                Console.WriteLine("❌ Temperatura inválida.");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Saliendo...");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("❌ Opción inválida.");
                            break;
                        }
                    }
                }
            }
        }
    }

