using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class TransferenciaAdapter: MetodoPago
    {
        private Trensferencia transferencia;
        public TransferenciaAdapter(Trensferencia transferir)
        {
            transferencia = transferir;
        }
        public override void Pagar(int monto)
        {
            transferencia.transferir(monto);
        }
    }
}
