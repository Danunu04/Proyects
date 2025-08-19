using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public class ANDExpression:IExpression
    {
        private IExpression expr1;
        private IExpression expr2;

        public ANDExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool interpret(Empleado emp)
        {
            return expr1.interpret(emp) && expr2.interpret(emp);
        }
    }
}
