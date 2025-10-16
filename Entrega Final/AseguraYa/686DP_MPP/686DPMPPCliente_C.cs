using _686DP_BE;
using _686DP_Dal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _686DP_MPP
{
    public class _686DPMPPCliente_C
    {
        _686DPDalGeneral dal = new _686DPDalGeneral();

        public void ActualizarClienteC(_686DPCliente_C duplicadoActivo)
        {
            try
            {
                string consulta = @"
                    UPDATE [686DP_Cliente].[686DP_Clienctes_C]
                    SET 
                        DP686_Activo = @Activo
                    WHERE ID = @ID";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@Activo", duplicadoActivo.DP686_Activo),
                    new SqlParameter("@ID", duplicadoActivo.ID)
                };

                dal._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el cliente en 686DP_Cliente_C: " + ex.Message);
            }
        }

        public List<_686DPCliente_C> TraerCambios()
        {
            string consulta = @"
                 SELECT 
                    ID,
                    DP686_Estado,
                    DP686_DNI,
                    DP686_Nombre,
                    DP686_Apellido,
                    DP686_Email,
                    DP686_Domicilio,
                    DP686DP_CodigoPostal,
                    DP686_Fecha,
                    DP686_Activo
                FROM [686DP_Cliente].[686DP_Clienctes_C]
                ORDER BY DP686_Fecha DESC";

            ArrayList parametros = new ArrayList();
            DataTable dt = dal._686DPConsultar(consulta, parametros);

            List<_686DPCliente_C> listaClientes = new List<_686DPCliente_C>();

            foreach (DataRow fila in dt.Rows)
            {
                _686DPCliente_C cliente = new _686DPCliente_C(
                    Convert.ToInt32(fila["ID"]),
                    Convert.ToBoolean(fila["DP686_Estado"]),
                    Convert.ToInt32(fila["DP686_DNI"]),
                    fila["DP686_Nombre"].ToString(),
                    fila["DP686_Apellido"].ToString(),
                    fila["DP686_Email"].ToString(),
                    fila["DP686_Domicilio"].ToString(),
                    Convert.ToInt32(fila["DP686DP_CodigoPostal"]),
                    Convert.ToDateTime(fila["DP686_Fecha"]),
                    Convert.ToBoolean(fila["DP686_Activo"])
                );

                listaClientes.Add(cliente);
            }

            return listaClientes;
        }
    }
}
