using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_MPP;
using _686DP_BE;

namespace _686DP_BLL
{
    public class _686DP_BLLCLlientes
    {
        public List<_686DP_Cliente> clientes = new List<_686DP_Cliente>();
        _686MPPClientes mpp = new _686MPPClientes();

        public void crear(_686DP_Cliente cliente)
        {
            try
            {
                clientes.Add(cliente);
                mpp.CrearCliente(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al crear el DNI: " + ex.Message);
            }
        }

        public void eliminadologico(int dNi)
        {
            mpp.EliminadoLogico(dNi);
        }

        public void GrabarCliente(_686DP_Cliente cliente)
        {
            mpp.GrabarCliente(cliente);
        }

        public _686DP_Cliente TraerCliente(int dNI)
        {
            _686DP_Cliente cliente = mpp.TraerCliente(dNI);
            clientes.Add(cliente);
            return cliente;
        }

        public List<_686DP_Cliente> TraerClientes()
        {
            List<_686DP_Cliente> clien = mpp.TraerClientes();
            foreach (_686DP_Cliente cliente in clien)
            {
                clientes.Add(cliente);
            }
            return clien;
        }

        public bool ValidarNuevo(int dni)
        {
            bool existe  = false;
            try
            {
                existe = mpp.ValidarNuevo(dni);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al validar el DNI: " + ex.Message);
            }
            return existe;
        }
    }
}
