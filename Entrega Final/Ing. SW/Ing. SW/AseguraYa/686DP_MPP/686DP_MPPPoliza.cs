using _686DP_BE;
using _686DP_Dal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_MPP
{
    public class _686DP_MPPPoliza
    {

        _686DPDalGeneral dal = new _686DPDalGeneral();

        public void AsociarClientePoliza(int dNI, int numeroPoliza)
        {
            try
            {
                string consulta = "INSERT INTO [dbo].[686DPClientePoliza] (DP686_NPoliza, DP686_DNICliente) VALUES (@NPoliza, @DNICliente)";

                ArrayList parametros = new ArrayList
                {
                new SqlParameter("@NPoliza", numeroPoliza),
                new SqlParameter("@DNICliente", dNI)
                };

                _686DPDalGeneral acceso = new _686DPDalGeneral();
                acceso._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al asociar cliente con póliza: " + ex.Message);
            }
        }

        public bool BuscarPoliza(int numeroDePoliza)
        {
            bool existe = false;
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM [dbo].[686DP_Poliza] WHERE [DP686_NPoliza] = @Poliza";
            ArrayList parametros = new ArrayList
            {
                new SqlParameter("@Poliza", numeroDePoliza)
            };
            dt = dal._686DPConsultar(consulta, parametros);
            if(dt.Rows.Count > 0)
            {
                existe = true;
            }
            return existe;
        }

        public int CrearPoliza(bool estado, decimal valorfinal, DateTime fechaVencimiento, int endoso, int codSeguro, int codigoPlan)
        {
            try
            {
                string consulta = @"
                INSERT INTO [686DP_Cliente].[686DP_Poliza]
                (DP686_Estado, DP686_valorTotal, DP686_FechaVencimiento, DP686_Endoso, DP686_CodSeguro, DP686_CodPlan)
                VALUES (@Estado, @ValorTotal, @FechaVencimiento, @Endoso, @CodSeguro, @CodPlan);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                ArrayList parametros = new ArrayList
                {
                new SqlParameter("@Estado", estado),
                new SqlParameter("@ValorTotal", valorfinal),
                new SqlParameter("@FechaVencimiento", fechaVencimiento),
                new SqlParameter("@Endoso", endoso),
                new SqlParameter("@CodSeguro", codSeguro),
                new SqlParameter("@CodPlan", codigoPlan)
                };

                object resultado = dal._686DPEscalar(consulta, parametros);

                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la póliza: " + ex.Message);
            }
        }

        public void eliminarPoliza(string motivo, _686DP_Poliza poliza)
        {
            try
            {
                string actualizar = @"
                UPDATE [686DP_Cliente].[686DP_Poliza]
                SET DP686_Estado = 0
                WHERE DP686_NPoliza = @NPoliza";

                ArrayList parametrosUpdate = new ArrayList
                {
                    new SqlParameter("@NPoliza", poliza.DP686_NPoliza)
                };

                dal._686DPEscribir(actualizar, parametrosUpdate);

                string insertar = @"
                INSERT INTO [dbo].[686DPPolizaCancelacion] (DP686_NPoliza, DP686_MotivoCancelacion)
                VALUES (@NPoliza, @Motivo)";

                ArrayList parametrosInsert = new ArrayList
                {
                    new SqlParameter("@NPoliza", poliza.DP686_NPoliza),
                    new SqlParameter("@Motivo", motivo)
                };

                dal._686DPEscribir(insertar, parametrosInsert);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la póliza: " + ex.Message);
            }
        }

        public void ModificarPoliza(_686DP_Poliza poliza)
        {

            try
            {
                string consulta = @"
                UPDATE [686DP_Cliente].[686DP_Poliza]
                SET DP686_Estado = @Estado,
                DP686_valorTotal = @ValorTotal,
                DP686_FechaVencimiento = @FechaVencimiento,
                DP686_Endoso = @Endoso,
                DP686_CodSeguro = @CodSeguro,
                DP686_CodPlan = @CodPlan
                WHERE DP686_NPoliza = @NPoliza";

                ArrayList parametros = new ArrayList
                {
                new SqlParameter("@Estado", poliza.DP686_Estado),
                new SqlParameter("@ValorTotal", poliza.DP686_valorTotal),
                new SqlParameter("@FechaVencimiento", poliza.DP686_FechaVencimiento),
                new SqlParameter("@Endoso", poliza.DP686_Endoso),
                new SqlParameter("@CodSeguro", poliza.DP686_CodSeguro),
                new SqlParameter("@CodPlan", poliza.DP686_CodPlan),
                new SqlParameter("@NPoliza", poliza.DP686_NPoliza)
                };

                dal._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar la póliza: " + ex.Message);
            }
        }

        public _686DP_Poliza TraerDatosPoliza(int numeroDePoliza)
        {
            _686DP_Poliza poliza = null;
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM [dbo].[686DP_Poliza] WHERE [DP686_NPoliza] = @Poliza";
            ArrayList parametros = new ArrayList
                {
                new SqlParameter("@Poliza", numeroDePoliza)
                };
            dt = dal._686DPConsultar(consulta, parametros);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                    poliza = new _686DP_Poliza(
                    nPoliza: Convert.ToInt32(row["DP686_NPoliza"]),
                    estado: Convert.ToBoolean(row["DP686_Estado"]),
                    valorTotal: Convert.ToDecimal(row["DP686_valorTotal"]),
                    fechaVencimiento: Convert.ToDateTime(row["DP686_FechaVencimiento"]),
                    endoso: Convert.ToInt32(row["DP686_Endoso"]),
                    codSeguro: Convert.ToInt32(row["DP686_CodSeguro"]),
                    codPlan: Convert.ToInt32(row["DP686_CodPlan"])
                );
            }
            return poliza;
        }

    }
}
