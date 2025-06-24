using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_BE;
using _686DP_Dal;

namespace _686DP_MPP
{
    public class _686DP_MPPPlan
    {
        _686DPDalGeneral dal = new _686DPDalGeneral();
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


    }
}
