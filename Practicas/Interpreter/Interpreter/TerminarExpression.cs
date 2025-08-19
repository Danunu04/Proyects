using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class TerminarExpression:IExpression
    {
        private string Campo;
        private string Valor;

        public TerminarExpression(string campo, string valor)
        {
            Campo = campo.ToLower();
            Valor = valor.ToLower();
        }

        public bool interpret(Empleado emp)
        {
            if (Campo == "nombre")
                return emp.Nombre.ToLower() == Valor;
            else if (Campo == "departamento")
                return emp.Departamento.ToLower() == Valor;
            else
                return false;        }
    }
}
