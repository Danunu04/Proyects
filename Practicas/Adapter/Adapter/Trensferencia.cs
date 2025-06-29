using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Trensferencia
    {
        public void transferir(int monto)
        {
            Console.WriteLine($"Usted está pagando por modo transferencia el monto: {monto}");
        }
    }
}
