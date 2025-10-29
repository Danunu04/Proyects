using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_BE;
using _686DP_MPP;

namespace _686DP_BLL
{
    public class _686DP_BLLSiniestro
    {
        _686DP_MPPSiniestro mpps = new _686DP_MPPSiniestro();

        public void AprobarSiniestro(int codSiniestro)
        {
            mpps.AprobarSiniestro(codSiniestro);
        }

        public void DenegarSiniestro(object codSiniestro)
        {
            mpps.DenegarSiniestro(codSiniestro);
        }

        public void Pagar(int codSiniestro)
        {
            DateTime dia = DateTime.Now;
            mpps.Pagar(codSiniestro, dia);
        }

        public void RegistrarSiniestro(int npoliza, double valorBien, double varorReparacion, DateTime fecha, string desc)
        {
            _686DP_Siniestro siniestro = new _686DP_Siniestro(fecha, varorReparacion, valorBien, false, desc);
            int codiSiniestro = mpps.registrarSiniestro(siniestro);
            mpps.RegistrarCorrelacion(npoliza, codiSiniestro);
        }

        public object TraerDatosVista()
        {
            return mpps.TraerDatosVista();
        }

        public List<_686DP_Siniestro> traerSiniestros()
        {
            return mpps.TraerSiniestros();
        }
    }
}
