using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_MPP;
using _686DP_BE;

namespace _686DP_BLL
{
    public class _686DPBLLSeguro
    {
        List<string> productos = new List<string>();
        _686DPMPPSeguro mpp = new _686DPMPPSeguro();


        public void AsociarCoberturaAPlan(int codigoPlan, int codigoCobertura)
        {
            mpp.AsociarCobertura(codigoPlan, codigoCobertura);
        }

        public void AsociarPlanASeguro(int codigoPlan, int codSeguro)
        {
            mpp.AsociarPlanASeguro(codigoPlan, codSeguro);
        }

        public string buscarProducto(string producto)
        {
            int codproducto = mpp.ObtenerCodSeguroPorProducto(producto);
            _686DP_Seguro seguro = mpp.TraerDatosSeguro(codproducto);

            if (seguro == null)
                return "Producto no encontrado";

            return seguro.DP686_TipoProducto;
        }

        public int CrearCobertura(string descripcion, decimal suma)
        {
            int codCobertura = mpp.CrearCobertura(descripcion, suma);
            return codCobertura;
        }

        public void CrearPlan(string producto, decimal franquicia, decimal prima)
        {
            int codigoPlan = mpp.CrearPlan(franquicia, prima);
            int codSeguro = mpp.ObtenerCodSeguroPorProducto(producto);
            mpp.AsociarPlanASeguro(codigoPlan, codSeguro);
        }

        public void CrearProucto(string nProducto)
        {
            try
            {
                mpp.CrearProducto(nProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el producto: " + ex.Message, ex);
            }
            _686DP_Seguro producto = new _686DP_Seguro(nProducto);
            productos.Add(nProducto);
        }

        public bool ExisteCoberturaEnPlan(int codPlan, string descripcion, decimal suma)
        {
            return mpp.ExisteCoberturaEnPlan(codPlan, descripcion, suma);
        }

        public int ObtenerCodSeguroPorProducto(string producto)
        {
            return mpp.ObtenerCodSeguroPorProducto(producto);
        }

        public List<_686DP_Cobertura> traerCoberturas()
        {
            List<_686DP_Cobertura> coberturas = mpp.TraerCoberturas();
            return coberturas;
        }

        public List<_686DP_Cobertura> TraerCoberturasFiltrado(int codigoPlan)
        {
            List<_686DP_Cobertura> coberturas = mpp.TraerCoberturasFiltrado(codigoPlan);
            return coberturas;
        }

        public List<_686DP_Plan> TraerPlanes()
        {
            List<_686DP_Plan> planes = mpp.TraerPlanes();
            return planes;
        }

        public List<_686DP_Plan> TraerPlanesFiltrado(string producto)
        {
            int codProducto = ObtenerCodSeguroPorProducto(producto);
            List<_686DP_Plan> planes = mpp.TraerPlanesFiltrados(codProducto);
            return planes;
        }

        public List<string> TraerProductos()
        {
            productos = mpp.TraerProductos();
            return productos;
        }

        public bool VaidarProducto(string nProducto)
        {
            bool existe = false;
            try
            {
                existe = mpp.ValidarProducto(nProducto);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el producto: " + ex.Message, ex);
            }
            return existe;
        }

        public bool YaExisteRelacionCoberturaPlan(int codigoPlanSeleccionado, int codigoCobertura)
        {
            return mpp.YaExisteRelacionCoberturaPlan(codigoPlanSeleccionado, codigoCobertura);
        }

        public bool YaExisteRelacionSeguroPlan(int codSeguro, int codigoPlan)
        {
            return mpp.YaExisteRelacionSeguroPlan(codSeguro, codigoPlan);
        }
    }
}
