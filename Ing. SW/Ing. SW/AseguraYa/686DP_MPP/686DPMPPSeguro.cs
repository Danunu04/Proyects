using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _686DP_BE;
using _686DP_Dal;

namespace _686DP_MPP
{
    public class _686DPMPPSeguro
    {
        _686DPDalGeneral dal = new _686DPDalGeneral();


        public void AsociarCobertura(int codigoPlan, int codigoCobertura)
        {
            string consulta = @"
            INSERT INTO [dbo].[686DP_PlanesCoberturas] (DP686_CodigoPlan, CodigoCobertura)
            VALUES (@CodigoPlan, @CodigoCobertura);";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@CodigoPlan", codigoPlan),
                new SqlParameter("@CodigoCobertura", codigoCobertura)
            };

            dal._686DPEscribir(consulta, parametros);
        }

        public void AsociarPlanASeguro(int codigoPlan, int codSeguro)
        {
            string consulta = @"
            INSERT INTO [dbo].[686DP_SeguroPlan] (DP686_CodSeguro, DP686_CodigoPlan)
            VALUES (@CodSeguro, @CodigoPlan)";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@CodSeguro", codSeguro),
                new SqlParameter("@CodigoPlan", codigoPlan)
            };

            dal._686DPEscribir(consulta, parametros);
        }

       

        public int CrearCobertura(string descripcion, decimal suma)
        {
            string buscar = @"
            SELECT CodigoCobertura
            FROM [dbo].[686DP_Cobertura]
            WHERE DP686_Descripcion = @Descripcion AND DP686_SumaAsegurada = @Suma;";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Suma", suma)
            };

            object resultado = dal._686DPEscalar(buscar, parametros);

            if (resultado != null && resultado != DBNull.Value)
                return Convert.ToInt32(resultado); 

            
            string insertar = @"
            INSERT INTO [dbo].[686DP_Cobertura] (DP686_Descripcion, DP686_SumaAsegurada)
            VALUES (@Descripcion, @Suma);
            SELECT SCOPE_IDENTITY();";

            return Convert.ToInt32(dal._686DPEscalar(insertar, parametros));
        }

        public int CrearPlan(decimal franquicia, decimal prima)
        {
            string consulta = @"
            INSERT INTO [dbo].[686DP_Plan] (DP686_Franquicia, DP686_Prima)
            VALUES (@Franquicia, @Prima);
            SELECT SCOPE_IDENTITY();";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@Franquicia", franquicia),
                new SqlParameter("@Prima", prima)
            };

            return Convert.ToInt32(dal._686DPEscalar(consulta, parametros));
        }

        public void CrearProducto(string nProducto)
        {
            string consulta = "INSERT INTO [dbo].[686DP_Productos] (DP686_ProductoNombre)   VALUES (@ProductoNombre);";
            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@ProductoNombre", nProducto)
            };

            dal._686DPEscribir(consulta, parametros);
        }

        public bool ExisteCoberturaEnPlan(int codPlan, string descripcion, decimal suma)
        {
            string consulta = @"
            SELECT COUNT(*) 
            FROM [dbo].[686DP_Cobertura] C
            INNER JOIN [dbo].[686DP_PlanesCoberturas] PC ON C.CodigoCobertura = PC.CodigoCobertura
            WHERE PC.DP686_CodigoPlan = @CodigoPlan
            AND C.DP686_Descripcion = @Descripcion
            AND C.DP686_SumaAsegurada = @Suma;";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@CodigoPlan", codPlan),
                new SqlParameter("@Descripcion", descripcion),
                new SqlParameter("@Suma", suma)
            };

            object resultado = dal._686DPEscalar(consulta, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        public int ObtenerCodSeguroPorProducto(string producto)
        {

            string consulta = @"
            SELECT DP686_CodSeguro
            FROM [dbo].[686DP_Seguro]
            WHERE DP686_ProductoNombre = @ProductoNombre";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@ProductoNombre", producto)
            };

            object resultado = dal._686DPEscalar(consulta, parametros);
            return Convert.ToInt32(resultado);
        }

        public List<_686DP_Cobertura> TraerCoberturas()
        {
            List<_686DP_Cobertura> coberturas = new List<_686DP_Cobertura>();
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM [dbo].[686DP_Cobertura]";

                dt = dal._686DPConsultar(consulta, null);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string Descripcion = item[0].ToString();
                        decimal Suma_asegurada = Convert.ToDecimal(item[1].ToString());
                        int codCObertura = Convert.ToInt32(item[2].ToString());
                        _686DP_Cobertura cobertura = new _686DP_Cobertura(codCObertura, Descripcion, Suma_asegurada);
                        coberturas.Add(cobertura);
                    }
                }
                return coberturas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar las coberturas." + ex.Message);
            }
        }

        public List<_686DP_Cobertura> TraerCoberturasFiltrado(int codigoPlan)
        {

            List<_686DP_Cobertura> coberturas = new List<_686DP_Cobertura>();
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT C.*\r\nFROM [dbo].[686DP_Cobertura] C\r\nINNER JOIN [dbo].[686DP_PlanesCoberturas] PC ON C.CodigoCobertura = PC.CodigoCobertura\r\nWHERE PC.DP686_CodigoPlan = @CodigoPlan;\r\n";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@CodigoPlan", codigoPlan)
                };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        string Descripcion = item[0].ToString();
                        decimal Suma_asegurada = Convert.ToDecimal(item[1].ToString());
                        int codCObertura = Convert.ToInt32(item[2].ToString());
                        _686DP_Cobertura cobertura = new _686DP_Cobertura(codCObertura, Descripcion, Suma_asegurada);
                        coberturas.Add(cobertura);
                    }
                }
                return coberturas;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar las coberturas." + ex.Message);
            }
        }

        public _686DP_Seguro TraerDatosSeguro(int dP686_CodSeguro)
        {

            string consulta = "SELECT * FROM [dbo].[686DP_Seguro] WHERE DP686_CodSeguro = @CodSeguro";
            ArrayList parametros = new ArrayList { new SqlParameter("@CodSeguro", dP686_CodSeguro) };

            DataTable dt = dal._686DPConsultar(consulta, parametros);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            string productoNombre = row["DP686_ProductoNombre"].ToString();
            return new _686DP_Seguro(productoNombre);
        }

        public _686DP_Plan TraerPlan(int dP686_CodPlan)
        {
            string consulta = "SELECT * FROM [dbo].[686DP_Plan] WHERE DP686_CodigoPlan = @CodPlan";
            ArrayList parametros = new ArrayList { new SqlParameter("@CodPlan", dP686_CodPlan) };

            DataTable dt = dal._686DPConsultar(consulta, parametros);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];
            decimal franquicia = Convert.ToDecimal(row["DP686_Franquicia"]);
            decimal prima = Convert.ToDecimal(row["DP686_Prima"]);
            return new _686DP_Plan(dP686_CodPlan, franquicia, prima);
        }

        public List<_686DP_Plan> TraerPlanes()
        {
            List<_686DP_Plan> Planes = new List<_686DP_Plan>();
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM [dbo].[686DP_Plan]";

                dt = dal._686DPConsultar(consulta, null);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        int codPlan = Convert.ToInt32(item[0]);
                        decimal Franquicia = Convert.ToDecimal(item[1]);
                        decimal Prima = Convert.ToDecimal(item[2]);
                        _686DP_Plan plan = new _686DP_Plan(codPlan, Franquicia, Prima);
                        Planes.Add(plan);
                    }
                }

                return Planes;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar las coberturas." + ex.Message);
            }
        }

        public List<_686DP_Plan> TraerPlanesFiltrados(int codProducto)
        {

            List<_686DP_Plan> Planes = new List<_686DP_Plan>();
            try
            {
                string consulta = @"
                SELECT P.DP686_CodigoPlan, P.DP686_Franquicia, P.DP686_Prima
                FROM [dbo].[686DP_Plan] P
                INNER JOIN [dbo].[686DP_SeguroPlan] SP ON P.DP686_CodigoPlan = SP.DP686_CodigoPlan
                WHERE SP.DP686_CodSeguro = @CodSeguro";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@CodSeguro", codProducto)
                };

                DataTable dt = dal._686DPConsultar(consulta, parametros);

                foreach (DataRow item in dt.Rows)
                {
                    int codPlan = Convert.ToInt32(item[0]);
                    decimal franquicia = Convert.ToDecimal(item[1]);
                    decimal prima = Convert.ToDecimal(item[2]);

                    _686DP_Plan plan = new _686DP_Plan(codPlan, franquicia, prima);
                    Planes.Add(plan);
                }

                return Planes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer planes filtrados: " + ex.Message, ex);
            }
        }

        public List<string> TraerProductos()
        {
            List<string> productos = new List<string>();
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT * FROM [dbo].[686DP_Productos]";
                
                dt = dal._686DPConsultar(consulta, null);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        productos.Add(item[1].ToString());
                    }
                }

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el Producto.");
            }
        }

        public bool ValidarProducto(string nProducto)
        {
            try
            {
                DataTable dt = new DataTable();
                bool existe = false;
                string consulta = "SELECT * FROM [dbo].[686DP_Productos]  WHERE DP686_ProductoNombre = @TipoProducto;";
                ArrayList parametros = new ArrayList { new SqlParameter("@TipoProducto", nProducto) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return existe = true;
                }

                return existe;
            }catch (Exception ex)
            {
                throw new Exception($"Error al buscar el Producto '{nProducto}'.");
            }
        }

        public bool YaExisteRelacionCoberturaPlan(object codigoPlan, int codigoCobertura)
        {
            string consulta = @"
            SELECT COUNT(*) 
            FROM [dbo].[686DP_PlanesCoberturas]
            WHERE DP686_CodigoPlan = @CodigoPlan
            AND CodigoCobertura = @CodigoCobertura;";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@CodigoPlan", codigoPlan),
                new SqlParameter("@CodigoCobertura", codigoCobertura)
            };

            object resultado = dal._686DPEscalar(consulta, parametros);
            return Convert.ToInt32(resultado) > 0;
        }

        public bool YaExisteRelacionSeguroPlan(int codSeguro, int codigoPlan)
        {
            string consulta = @"
            SELECT COUNT(*) 
            FROM [dbo].[686DP_SeguroPlan]
            WHERE DP686_CodSeguro = @CodSeguro AND DP686_CodigoPlan = @CodigoPlan";

            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@CodSeguro", codSeguro),
                new SqlParameter("@CodigoPlan", codigoPlan)
            };

            object resultado = dal._686DPEscalar(consulta, parametros);
            return Convert.ToInt32(resultado) > 0;
        }
    }
}
