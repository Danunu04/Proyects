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
        public static List<string> MppErrores = new List<string>();
        public static List<string> errores = new List<string>();
        private readonly List<string> tablas = new List<string>
        {
            "686DP_Cliente",
            "686DP_Poliza",
            "686DP_Siniestro",
            "686DP_Cobertura",
            "686DP_Factura",
            "686DP_Plan",
            "686DP_Seguro",
            "686DP_SeguroPlan",
            "686DP_PlanesCoberturas",
            "686DPClientePoliza",
            "686DP_PolizaSiniestro",
            "686DPPolizaCancelacion"
        };
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
            try
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
            catch (Exception ex)
            {
                throw new Exception("Error al calcular/verificar los dígitos verificadores:\n" + ex.Message, ex);
            }
        }

        private bool Comparar()
        {
            bool valor = true;

            if (DVS == null || DVS.Count == 0)
                throw new Exception("No hay dígitos verificadores calculados en memoria.");

            if (DVSBD == null || DVSBD.Count == 0)
                throw new Exception("No hay dígitos verificadores almacenados en la base de datos.");

            foreach (var dvLocal in DVS)
            {
                var dvBD = DVSBD.FirstOrDefault(x => x.DP686NombreTabla == dvLocal.DP686NombreTabla);

                if (dvBD == null)
                {
                    throw new Exception($"❌ No se encontró en la base el registro de la tabla '{dvLocal.DP686NombreTabla}'.");
                }

                bool coincideDVH = dvLocal.DP686DVH == dvBD.DP686DVH;
                bool coincideDVV = dvLocal.DP686DVV == dvBD.DP686DVV;

                if (!coincideDVH || !coincideDVV)
                {
                    errores.Add($"Inconsistencia detectada en '{dvLocal.DP686NombreTabla}'.\n");
                    valor = false;
                }
            }
            return valor;
        }


    }
}
