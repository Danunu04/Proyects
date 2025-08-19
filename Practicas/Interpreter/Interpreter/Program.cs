using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Empleado> empleados = new List<Empleado>();
            string opcion = "";
            while (opcion != "Salir")
            {
                Console.WriteLine("Ingrese el nombre del empleado, escriba 'salir' para cancelar");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el Departamento del empleado, escriba 'salir' para cancelar " + nombre);
                string departamento = Console.ReadLine();
                Empleado empleado = new Empleado(nombre, departamento);
                empleados.Add(empleado);

                IExpression expr = new ANDExpression(
                new TerminarExpression("Nombre", nombre),
                new TerminarExpression("Departamento", departamento)
                );
                Console.WriteLine($"Nombre = {nombre} AND Departamento = {departamento}\n");

                foreach (var emp in empleados)
                {
                    if (expr.interpret(emp))
                    {
                        Console.WriteLine($"{emp.Nombre} - {emp.Departamento}");
                    }
                }
            }
        }
    }
}
