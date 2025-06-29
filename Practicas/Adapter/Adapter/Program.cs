using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MetodoPago metodopago;
            int opcion = 0;
            int monto = 0;
            Console.WriteLine("Ingrese el monto a pagar: ");
            if (!int.TryParse(Console.ReadLine(), out monto))
            {
                Console.WriteLine("Deben ser caracteres numericos");
                monto = 0;
            }
            try
            {
                while  (opcion != 9)
                {
                    Console.WriteLine("Ingrese el metodo de pago con el que va a abonar:");
                    Console.WriteLine("1. Tarjeta de credito");
                    Console.WriteLine("2. Transferencia");
                    Console.WriteLine("9. Salir");
                    if(!int.TryParse(Console.ReadLine(), out opcion))
                    {
                        Console.WriteLine("Deben ser caracteres numericos");
                        continue;
                    }
                    try
                    {
                        switch (opcion)
                        {
                            case 1:
                                metodopago = new Tarjeta_de_credito();
                                metodopago.Pagar(monto);
                                Console.ReadKey();
                                break;
                            case 2:
                                var transferencia = new Trensferencia();
                                metodopago = new TransferenciaAdapter(transferencia);
                                metodopago.Pagar(monto);
                                Console.ReadKey();
                                break;
                            case 9:
                                Console.WriteLine("Hasta luego...");
                                break;
                            default:
                                Console.WriteLine("Hubo un error");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Hubo un error en la seleccion de opciones " + ex.Message);
                        Console.ReadKey();

                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Hubo un error en la carga del monto a pagar "+ ex.Message);
                Console.ReadKey();

            }

        }
    }
}
