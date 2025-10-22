using _686DP_BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_Dal;
using _686DP_SERVICIOS;
using System.Data.SqlClient;
using System.Collections;

namespace _686DP_MPP
{
    public class _686DP_MPPDigitoVerificador
    {
        _686DPCriptoManager cm = new _686DPCriptoManager();
        _686DPDalGeneral dal = new _686DPDalGeneral();
        public static List<string> erroresFila = new List<string>();

        private string ObtenerPrimaryKey(string nombreTabla)
        {
            string query = @"
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE TABLE_NAME = @NombreTabla";

            ArrayList parametros = new ArrayList
    {
        new SqlParameter("@NombreTabla", nombreTabla)
    };

            DataTable dt = dal._686DPConsultar(query, parametros);

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["COLUMN_NAME"].ToString();
            else
                return null;
        }

        public _686DP_DigitoVerificador Calcular(string consulta, string nombreTabla)
        {
            DataTable dt = dal._686DPConsultar(consulta, null);

            if (dt == null || dt.Rows.Count == 0)
                throw new Exception($"La tabla {nombreTabla} no contiene registros.");

            string contenidoFilas = "";
            string contenidoColumnas = "";

            foreach (DataRow fila in dt.Rows)
            {
                foreach (var celda in fila.ItemArray)
                {
                    contenidoFilas += celda?.ToString() ?? "";

                }
            }

            for (int c = 0; c < dt.Columns.Count; c++)
            {
                foreach (DataRow fila in dt.Rows)
                {
                    contenidoColumnas += fila[c]?.ToString() ?? "";
                }
            }

            string dvh = cm._686DPGetSHA256(contenidoFilas);
            string dvv = cm._686DPGetSHA256(contenidoColumnas);
            _686DP_DigitoVerificador resultado = new _686DP_DigitoVerificador(nombreTabla, dvh, dvv);
            return resultado;
        }
        
        public _686DP_DigitoVerificador CalcularDVPolizas()
        {
            string consulta = @"
                SELECT [DP686_NPoliza],
                       [DP686_Estado],
                       [DP686_valorTotal],
                       [DP686_FechaVencimiento],
                       [DP686_Endoso],
                       [DP686_CodSeguro],
                       [DP686_CodPlan]
                FROM [AseguraYA].[dbo].[686DP_Poliza]";
            return Calcular(consulta, "686DP_Poliza");
        }

        public _686DP_DigitoVerificador CalcularDVCliente()
        {
            string consulta = @"
                SELECT [DP686_DNI],
                       [DP686_Nombre],
                       [DP686_Apellido],
                       [DP686_Email],
                       [DP686_Domicilio],
                       [DP686DP_CodigoPostal],
                       [DP686_Estado]
                FROM [AseguraYA].[686DP_Cliente].[686DP_Clientes]";
            return Calcular(consulta, "686DP_Clientes");
        }

        public _686DP_DigitoVerificador CalcularDVCobertura()
        {
            string consulta = @"
                SELECT [DP686_Descripcion],
                       [DP686_SumaAsegurada],
                       [CodigoCobertura]
                FROM [AseguraYA].[dbo].[686DP_Cobertura]";
            return Calcular(consulta, "686DP_Cobertura");
        }

        public _686DP_DigitoVerificador CalcularDVPlan()
        {
            string consulta = @"
                SELECT [DP686_CodigoPlan],
                       [DP686_Franquicia],
                       [DP686_Prima]
                FROM [AseguraYA].[dbo].[686DP_Plan]";
            return Calcular(consulta, "686DP_Plan");
        }

        public _686DP_DigitoVerificador CalcularDVSeguro()
        {
            string consulta = @"
                SELECT [DP686_CodSeguro],
                       [DP686_ProductoNombre]
                FROM [AseguraYA].[dbo].[686DP_Seguro]";
            return Calcular(consulta, "686DP_Seguro");
        }

        public _686DP_DigitoVerificador CalcularDVSiniestro()
        {
            string consulta = @"
                SELECT [CodSiniestro],
                       [Fecha],
                       [Valor],
                       [ValorDeReparacion],
                       [ValorDelBien],
                       [Estado],
                       [Descripcion]
                FROM [AseguraYA].[dbo].[686DP_Siniestro]";
            return Calcular(consulta, "686DP_Siniestro");
        }

        public _686DP_DigitoVerificador CalcularDVFactura()
        {
            string consulta = @"
                SELECT [CodFactura],
                       [CodSiniestro],
                       [Fecha]
                FROM [AseguraYA].[dbo].[686DP_Factura]";
            return Calcular(consulta, "686DP_Factura");
        }

        public void Grabar(_686DP_DigitoVerificador dv)
        {
            try
            {
                string query = @"
                    IF EXISTS (SELECT 1 FROM [AseguraYA].[dbo].[686DP_DigitoVerificador] WHERE DP686NombreTabla = @NombreTabla)
                        UPDATE [AseguraYA].[dbo].[686DP_DigitoVerificador]
                        SET DP686DVH = @DVH,
                            DP686DVV = @DVV
                        WHERE DP686NombreTabla = @NombreTabla;
                    ELSE
                        INSERT INTO [AseguraYA].[dbo].[686DP_DigitoVerificador]
                            (DP686NombreTabla, DP686DVH, DP686DVV)
                        VALUES (@NombreTabla, @DVH, @DVV);";

                ArrayList Parameters = new ArrayList
                {
                    new SqlParameter("@NombreTabla", dv.DP686NombreTabla),
                    new SqlParameter("@DVH", dv.DP686DVH),
                    new SqlParameter("@DVV", dv.DP686DVV)
                };

                dal._686DPEscribir(query, Parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el dígito verificador: " + ex.Message);
            }
        }

        public List<_686DP_DigitoVerificador> TraerDVs()
        {
            try
            {
                List<_686DP_DigitoVerificador> listaDVs = new List<_686DP_DigitoVerificador>();

                string consulta = @"
                SELECT [DP686NombreTabla],
                       [DP686DVH],
                       [DP686DVV]
                FROM [AseguraYA].[dbo].[686DP_DigitoVerificador]";

                DataTable dt = dal._686DPConsultar(consulta, null);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow fila in dt.Rows)
                    {
                        string nombreTabla = fila["DP686NombreTabla"].ToString();
                        string dvh = fila["DP686DVH"].ToString();
                        string dvv = fila["DP686DVV"].ToString();

                        _686DP_DigitoVerificador dv = new _686DP_DigitoVerificador(nombreTabla, dvh, dvv);
                        listaDVs.Add(dv);
                    }
                }

                return listaDVs;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer los dígitos verificadores: " + ex.Message);
            }
        }

        public _686DP_DigitoVerificador CalcularPlanesCoberturas()
        {
            string consulta = @"
               SELECT [DP686_CodigoPlan]
                    ,[CodigoCobertura]
              FROM [AseguraYA].[dbo].[686DP_PlanesCoberturas]
";
            return Calcular(consulta, "686DP_PlanesCoberturas");
        }

        public _686DP_DigitoVerificador CalcularSeguroPlan()
        {
            string consulta = @"
            SELECT [DP686_CodSeguro]
                  ,[DP686_CodigoPlan]
              FROM [AseguraYA].[dbo].[686DP_SeguroPlan]";
                    return Calcular(consulta, "686DP_SeguroPlan");
        }

        public _686DP_DigitoVerificador CalcularClientePoliza()
        {
            string consulta = @"
            SELECT [DP686_NPoliza]
                  ,[DP686_DNICliente]
              FROM [AseguraYA].[dbo].[686DPClientePoliza]";
            return Calcular(consulta, "686DPClientePoliza");
        }

        public _686DP_DigitoVerificador CalcularPolizaSiniestro()
        {
            string consulta = @"
            SELECT [CodSiniestro]
                  ,[DP686_NPoliza]
              FROM [AseguraYA].[dbo].[686DP_PolizaSiniestro]";
            return Calcular(consulta, "686DP_PolizaSiniestro");
        }

        public _686DP_DigitoVerificador CalcularPolizaCancelacion()
        {
            string consulta = @"
            SELECT [DP686_NPoliza]
                  ,[Motivo]
              FROM [AseguraYA].[dbo].[686DPPolizaCancelacion]";
            return Calcular(consulta, "686DPPolizaCancelacion");
        }
    }
}
