using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Departamento { get; set; }

        public Empleado(string nombre, string departamento)
        {
            Nombre = nombre;
            Departamento = departamento;
        }
    }
}
