using _686DP_BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_MPP;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace _686DP_BLL
{
    public class _686DP_BLLDigitoVerificador
    {
        private static List<_686DP_DigitoVerificador> DVS = new List<_686DP_DigitoVerificador>();
        private static List<_686DP_DigitoVerificador> DVSBD = new List<_686DP_DigitoVerificador>();
        _686DP_MPPDigitoVerificador mpp = new _686DP_MPPDigitoVerificador();
        public void CalcularDigitoVerificador(string NombreTabla)
        {
            _686DP_DigitoVerificador dv = null;
            if(NombreTabla == "Polizas")
            {
                dv = mpp.CalcularDVPolizas();
            }
            else if(NombreTabla == "Plan")
            {
                dv = mpp.CalcularDVPlan();
            }
            else if( NombreTabla =="Cobertura")
            {
                dv = mpp.CalcularDVCobertura();
            }
            else if (NombreTabla == "Seguro")
            {
                dv = mpp.CalcularDVSeguro();
            }
            else if (NombreTabla == "Cliente")
            {
                dv = mpp.CalcularDVCliente();
            }
            else if(NombreTabla == "Siniestro")
            {
                dv = mpp.CalcularDVSiniestro();
            }
            else if(NombreTabla == "Factura")
            {
                dv = mpp.CalcularDVFactura();
            }
            else
            {
                throw new Exception("Tabla no encontrada");
            }

            DVS.Add(mpp.CalcularPlanesCoberturas());
            DVS.Add(mpp.CalcularSeguroPlan());
            DVS.Add(mpp.CalcularClientePoliza());
            DVS.Add(mpp.CalcularPolizaSiniestro());
            DVS.Add(mpp.CalcularPolizaCancelacion());


            //Carga
            var existente = DVS.FirstOrDefault(x => x.DP686NombreTabla == dv.DP686NombreTabla);

            if (existente != null)
            {
                DVS.Remove(existente);
            }
            DVS.Add(dv);
            grabarTodosDV();
        }
        public void grabarTodosDV()
        {
            if(DVS.Count > 0)
            {
                foreach (_686DP_DigitoVerificador dv in  DVS)
                {
                    mpp.Grabar(dv);
                }
                DVS.Clear();
            }
        }

        public bool CalcularTodos()
        {
            DVS.Clear();
            DVS.Add(mpp.CalcularDVPolizas());
            DVS.Add(mpp.CalcularDVPlan());
            DVS.Add(mpp.CalcularDVCobertura());
            DVS.Add(mpp.CalcularDVSeguro());
            DVS.Add(mpp.CalcularDVCliente());
            DVS.Add(mpp.CalcularDVSiniestro());
            DVS.Add(mpp.CalcularDVFactura());
            DVS.Add(mpp.CalcularPlanesCoberturas());
            DVS.Add(mpp.CalcularSeguroPlan());
            DVS.Add(mpp.CalcularClientePoliza());
            DVS.Add(mpp.CalcularPolizaSiniestro());
            DVS.Add(mpp.CalcularPolizaCancelacion());

            return Comparar();
        }

        private bool Comparar()
        {
            try
            {
                DVSBD = mpp.TraerDVs();

                if (DVS == null || DVS.Count == 0)
                    throw new Exception("No hay dígitos verificadores calculados en memoria.");

                if (DVSBD == null || DVSBD.Count == 0)
                    throw new Exception("No hay dígitos verificadores almacenados en la base de datos.");

                foreach (var dvLocal in DVS)
                {
                    var dvBD = DVSBD.FirstOrDefault(x => x.DP686NombreTabla == dvLocal.DP686NombreTabla);

                    if (dvBD == null)
                        throw new Exception($"❌ No se encontró en la base el registro de la tabla '{dvLocal.DP686NombreTabla}'.");

                    bool coincideDVH = dvLocal.DP686DVH == dvBD.DP686DVH;
                    bool coincideDVV = dvLocal.DP686DVV == dvBD.DP686DVV;

                    if (!coincideDVH || !coincideDVV)
                    {
                        throw new Exception(
                            $"⚠️ Inconsistencia detectada en '{dvLocal.DP686NombreTabla}'.\n" +
                            $"DVH esperado: {dvLocal.DP686DVH}\nDVH BD: {dvBD.DP686DVH}\n" +
                            $"DVV esperado: {dvLocal.DP686DVV}\nDVV BD: {dvBD.DP686DVV}");
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;  
            }
        }
    }
}
