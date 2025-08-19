using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Tarjeta_de_credito:MetodoPago
    {
        public override void Pagar(int monto)
        {
            Console.WriteLine($"Usted esta pagando con tarjeta de credito el monto: {monto}");
        }
    }
}
