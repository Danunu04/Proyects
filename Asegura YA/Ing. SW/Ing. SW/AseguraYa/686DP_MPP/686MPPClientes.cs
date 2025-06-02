using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using _686DP_Dal;
using _686DP_MPP;
using _686DP_BE;

namespace _686DP_MPP
{
    public class _686MPPClientes
    {
        _686DPDalGeneral dal = new _686DPDalGeneral();
        public void CrearCliente(_686DP_Cliente cliente)
        {
            try
            {
                string consulta = "INSERT INTO [686DP_Cliente].[686DP_Clientes] (\r\n    DP686_DNI,\r\n    DP686_Nombre,\r\n    DP686_Apellido\r\n)\r\nVALUES (\r\n    @DNI,\r\n    @Nombre,\r\n    @Apellido\r\n)";
                ArrayList parametros = new ArrayList
                {
                     new SqlParameter("@DNI", cliente.DP686_DNI),
                     new SqlParameter("@Nombre", cliente.DP686_Nombre),
                     new SqlParameter("@Apellido", cliente.DP686_Apellido)
                };
                dal._686DPEscribir(consulta,parametros);
            }
            catch(Exception ex) 
            {
                throw new Exception("Error al insertar el cliente en la base de datos: " + ex.Message, ex);
            }
        }

        public void EliminadoLogico(int dNi)
        {

            try
            {
                string consulta = "UPDATE [686DP_Cliente].[686DP_Clientes] SET DP686_Estado = 0 WHERE DP686_DNI = @DNI";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@DNI", dNi)
                };

                _686DPDalGeneral acceso = new _686DPDalGeneral();
                acceso._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al realizar el eliminado lógico del cliente: " + ex.Message);
            }
        }

        public void GrabarCliente(_686DP_Cliente cliente)
        {
            try
            {
                string storedProcedure = "[686DP_Cliente].[spInsertarCliente_686DP]";
                ArrayList parametros = new ArrayList();

                parametros.Add(new SqlParameter("@DNI", cliente.DP686_DNI));
                parametros.Add(new SqlParameter("@Nombre", cliente.DP686_Nombre));
                parametros.Add(new SqlParameter("@Apellido", cliente.DP686_Apellido));
                parametros.Add(new SqlParameter("@Email", string.IsNullOrWhiteSpace(cliente.DP686_Email) ? DBNull.Value : (object)cliente.DP686_Email));
                parametros.Add(new SqlParameter("@NTarjeta", cliente.DP686_NTarjeta == 0 ? DBNull.Value : (object)cliente.DP686_NTarjeta));
                parametros.Add(new SqlParameter("@Domicilio", string.IsNullOrWhiteSpace(cliente.DP686_Domicilio) ? DBNull.Value : (object)cliente.DP686_Domicilio));
                parametros.Add(new SqlParameter("@CodigoPostal", cliente.DP686DP_CodigoPostal == 0 ? DBNull.Value : (object)cliente.DP686DP_CodigoPostal));
                parametros.Add(new SqlParameter("@CuitCuil", string.IsNullOrWhiteSpace(cliente.DP686_CuitCuil?.ToString()) ? DBNull.Value : (object)cliente.DP686_CuitCuil));
                parametros.Add(new SqlParameter("@CondicionIVA", string.IsNullOrWhiteSpace(cliente.DP686_CondicionIVA) ? DBNull.Value : (object)cliente.DP686_CondicionIVA));
                parametros.Add(new SqlParameter("@Estado", cliente.DP686_Estado == null ? DBNull.Value : (object)cliente.DP686_Estado));
                parametros.Add(new SqlParameter("@TitularTarjeta", string.IsNullOrWhiteSpace(cliente.DP686_TitularTarjeta) ? DBNull.Value : (object)cliente.DP686_TitularTarjeta));
                parametros.Add(new SqlParameter("@MedioPago", string.IsNullOrWhiteSpace(cliente.DP686_medioPago) ? DBNull.Value : (object)cliente.DP686_medioPago));
                parametros.Add(new SqlParameter("@FechaVencimiento", cliente.DP686_FechaVencimiento == DateTime.MinValue ? DBNull.Value : (object)cliente.DP686_FechaVencimiento));

                dal._686DPEjecutar(storedProcedure, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al grabar cliente: " + ex.Message);
            }
        }


        public _686DP_Cliente TraerCliente(int dNI)
        {
            try
            {
                string consulta = @"
                SELECT * FROM [686DP_Cliente].[686DP_Clientes]
                WHERE DP686_DNI = @DNI";

                ArrayList parametros = new ArrayList
                {
                    new SqlParameter("@DNI", dNI)
                };

                DataTable dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count == 0)
                    return null;

                DataRow row = dt.Rows[0];

                _686DP_Cliente cliente = new _686DP_Cliente(dNI, row["DP686_Nombre"].ToString(), row["DP686_Apellido"].ToString());

                if (row["DP686_Email"] != DBNull.Value)
                    cliente.DP686_Email = row["DP686_Email"].ToString();

                if (row["DP686_NTarjeta"] != DBNull.Value)
                    cliente.DP686_NTarjeta = Convert.ToInt32(row["DP686_NTarjeta"]);

                if (row["DP686_Domicilio"] != DBNull.Value)
                    cliente.DP686_Domicilio = row["DP686_Domicilio"].ToString();

                if (row["DP686DP_CodigoPostal"] != DBNull.Value)
                    cliente.DP686DP_CodigoPostal = Convert.ToInt32(row["DP686DP_CodigoPostal"]);

                if (row["DP686_CuitCuil"] != DBNull.Value)
                    cliente.DP686_CuitCuil = Convert.ToInt32(row["DP686_CuitCuil"]);

                if (row["DP686_CondicionIVA"] != DBNull.Value)
                    cliente.DP686_CondicionIVA = row["DP686_CondicionIVA"].ToString();

                if (row["DP686_Estado"] != DBNull.Value)
                    cliente.DP686_Estado = Convert.ToBoolean(row["DP686_Estado"]);

                if (row["DP686_TitularTarjeta"] != DBNull.Value)
                    cliente.DP686_TitularTarjeta = row["DP686_TitularTarjeta"].ToString();

                if (row["DP686_medioPago"] != DBNull.Value)
                    cliente.DP686_medioPago = row["DP686_medioPago"].ToString();

                if (row["DP686_FechaVencimineto"] != DBNull.Value)
                    cliente.DP686_FechaVencimiento = Convert.ToDateTime(row["DP686_FechaVencimineto"]);

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer cliente por DNI: " + ex.Message, ex);
            }
        }

        public List<_686DP_Cliente> TraerClientes()
        {
            List<_686DP_Cliente> lista = new List<_686DP_Cliente>();
            string consulta = "SELECT * FROM [686DP_Cliente].[686DP_Clientes]";

            try
            {
                ArrayList parametros = new ArrayList();
                _686DPDalGeneral acceso = new _686DPDalGeneral();
                DataTable tabla = acceso._686DPConsultar(consulta, parametros);

                foreach (DataRow row in tabla.Rows)
                {
                    _686DP_Cliente c = new _686DP_Cliente(
                        Convert.ToInt32(row["DP686_DNI"]),
                        row["DP686_Nombre"]?.ToString(),
                        row["DP686_Apellido"]?.ToString()
                    )
                    {
                        DP686_Email = row["DP686_Email"] == DBNull.Value ? null : row["DP686_Email"].ToString(),
                        DP686_NTarjeta = row["DP686_NTarjeta"] == DBNull.Value ? 0 : Convert.ToInt32(row["DP686_NTarjeta"]),
                        DP686_Domicilio = row["DP686_Domicilio"] == DBNull.Value ? null : row["DP686_Domicilio"].ToString(),
                        DP686DP_CodigoPostal = row["DP686DP_CodigoPostal"] == DBNull.Value ? 0 : Convert.ToInt32(row["DP686DP_CodigoPostal"]),
                        DP686_CuitCuil = row["DP686_CuitCuil"] == DBNull.Value ? 0 : Convert.ToInt32(row["DP686_CuitCuil"]),
                        DP686_CondicionIVA = row["DP686_CondicionIVA"] == DBNull.Value ? null : row["DP686_CondicionIVA"].ToString(),
                        DP686_Estado = row["DP686_Estado"] != DBNull.Value && Convert.ToBoolean(row["DP686_Estado"]),
                        DP686_TitularTarjeta = row["DP686_TitularTarjeta"] == DBNull.Value ? null : row["DP686_TitularTarjeta"].ToString(),
                        DP686_medioPago = row["DP686_medioPago"] == DBNull.Value ? null : row["DP686_medioPago"].ToString(),
                        DP686_FechaVencimiento = row["DP686_FechaVencimineto"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(row["DP686_FechaVencimineto"])
                    };
                    lista.Add(c);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al traer clientes: " + ex.Message);
            }
        }

        public bool ValidarNuevo(int dni)
        {
            bool existe = false;
            try
            {
                DataTable dt;
                string consulta = "SElECT [DP686_DNI] from [686DP_Cliente].[686DP_Clientes] where [DP686_DNI] = @DNI";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", dni) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return existe = true;
                }

                return existe;
            }
            catch (Exception)
            {
                throw new Exception($"Error al buscar el nombre de usuario '{dni}'.");
            }
        }

    }
}
