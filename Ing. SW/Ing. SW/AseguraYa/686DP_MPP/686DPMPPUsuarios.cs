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
using _686DP_SERVICIOS;
using System.Net;

namespace _686DP_MPP
{
    public class _686DPMPPUsuarios
    {
        _686DPDalGeneral dal = new _686DPDalGeneral();
        _686DPCriptoManager criptoManager = new _686DPCriptoManager();
        public void _686DPAgregarALita(string contraseñaActual, int dni)
        {
            string consultaInsert = @"INSERT INTO [686DP EmpleadoContraseñas] (DP686_DNI, DP686_Contraseña)
                                  VALUES (@DNI, @Contraseña)";
            ArrayList parametrosInsert = new ArrayList
            {
            new SqlParameter("@DNI", dni),
            new SqlParameter("@Contraseña", contraseñaActual)
            };
            _686DPDalGeneral dal = new _686DPDalGeneral();
            dal._686DPEscribir(consultaInsert, parametrosInsert);

        }

        public void _686DPGrabarContraseñaNueva(string text, int dni)
        {

            string consulta = @"UPDATE [686DP_Empleado]
                            SET DP686_Contraseña = @Contraseña
                            WHERE DP686_DNI = @DNI";

            ArrayList parametros = new ArrayList
        {
            new SqlParameter("@Contraseña", text),
            new SqlParameter("@DNI", dni)
        };

            _686DPDalGeneral dal = new _686DPDalGeneral();
            dal._686DPEscribir(consulta, parametros);
        }

        public List<string> _686DPVerificarContraseñas(int dni)
        {
            try
            {
                List<string> contraseñas = new List<string>();
                _686DPDalGeneral dal = new _686DPDalGeneral();

                string consulta = @"
        SELECT ec.DP686_Contraseña
        FROM [686DP EmpleadoContraseñas] ec
        INNER JOIN [686DP_Empleado] e ON ec.DP686_DNI = e.DP686_DNI
        WHERE e.DP686_DNI = @dni";

                ArrayList parametros = new ArrayList
        {
            new SqlParameter("@dni", dni)
        };

                DataTable dt = dal._686DPConsultar(consulta, parametros);

                foreach (DataRow row in dt.Rows)
                {
                    contraseñas.Add(row["DP686_Contraseña"].ToString());
                }

                return contraseñas;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al verificar contraseñas anteriores: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al verificar contraseñas anteriores: " + ex.Message, ex);
            }
        }

        public void _686DPActualizarEmpleadoExistente(_686DP_Empleados emp)
        {
            try
            {
                string consulta = @"IF EXISTS (SELECT 1 FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI)
BEGIN
    UPDATE [dbo].[686DP_Empleado]
    SET 
        DP686_Nombre = @Nombre,
        DP686_Apellido = @Apellido,
        DP686_Email = @Email,
        DP686_Rol = @Rol,
        DP686_Usuario = @Usuario,
        DP686_Contraseña = @Contraseña,
        DP686_Activo = @Activo,
        DP686_Bloqueado = @Bloqueado,
        DP686_CambiarContraseña = @Contra
    WHERE DP686_DNI = @DNI;
END
ELSE
BEGIN
    INSERT INTO [dbo].[686DP_Empleado] (
        DP686_DNI, DP686_Nombre, DP686_Apellido, DP686_Email,
        DP686_Rol, DP686_Usuario, DP686_Contraseña,
        DP686_Activo, DP686_Bloqueado, DP686_CambiarContraseña
    )
    VALUES (
        @DNI, @Nombre, @Apellido, @Email,
        @Rol, @Usuario, @Contraseña,
        @Activo, @Bloqueado, @Contra
    );
END";

                ArrayList parametros = new ArrayList
        {
            new SqlParameter("@Nombre", emp.DP686_Nombre),
            new SqlParameter("@Apellido", emp.DP686_Apellido),
            new SqlParameter("@Email", emp.DP686_Email),
            new SqlParameter("@Rol", emp.DP686_Rol),
            new SqlParameter("@Usuario", emp.DP686_Usuario),
            new SqlParameter("@Contraseña", emp.DP686_Contraseña),
            new SqlParameter("@Activo", emp.DP686_Activo),
            new SqlParameter("@Bloqueado", emp.DP686_Bloqueado),
            new SqlParameter("@DNI", emp.DP686_DNI),
            new SqlParameter("@Contra", emp.DP686_CambiarContraseña)
        };

                _686DPDalGeneral dal = new _686DPDalGeneral();
                dal._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el empleado con DNI {emp.DP686_DNI}: {ex.Message}", ex);
            }
        }

        public void _686DPBloquearUsuario(int DNI)
        {
            try
            {
                string consulta = "UPDATE [dbo].[686DP_Empleado] SET DP686_Bloqueado = 1 WHERE DP686_DNI = @DNI";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", DNI) };

                _686DPDalGeneral dal = new _686DPDalGeneral();
                dal._686DPEscribir(consulta, parametros);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error de SQL al intentar bloquear al usuario '{DNI}': {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado al bloquear al usuario '{DNI}': {ex.Message}", ex);
            }
        }

        public string _686DPBuscarContraseña(int DNI)
        {
            try
            {
                DataTable dt;
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT [DP686_Contraseña] FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI;";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", DNI) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToString(dt.Rows[0][0]);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw new Exception($"Error al buscar la contraseña del usuario '{DNI}'.");
            }
        }

        public string _686DPBuscarUsuario(int DNI)
        {
            try
            {
                DataTable dt;
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT [DP686_Usuario] FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", DNI) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToString(dt.Rows[0][0]);
                }

                return string.Empty;
            }
            catch (Exception)
            {
                throw new Exception($"Error al buscar el nombre de usuario '{DNI}'.");
            }
        }

        public object _686DPFiltrarEmpleados(string rol, bool? activo, bool? bloqueado)
        {
            try
            {
                List<string> condiciones = new List<string>();
                ArrayList parametros = new ArrayList();

                if (!string.IsNullOrEmpty(rol))
                {
                    condiciones.Add("DP686_Rol = @Rol");
                    parametros.Add(new SqlParameter("@Rol", rol));
                }

                if (activo.HasValue)
                {
                    condiciones.Add("DP686_Activo = @Activo");
                    parametros.Add(new SqlParameter("@Activo", activo.Value));
                }

                if (bloqueado.HasValue)
                {
                    condiciones.Add("DP686_Bloqueado = @Bloqueado");
                    parametros.Add(new SqlParameter("@Bloqueado", bloqueado.Value));
                }

                string whereClause = condiciones.Count > 0 ? "WHERE " + string.Join(" AND ", condiciones) : "";

                string consulta = $"SELECT * FROM [dbo].[686DP_Empleado] {whereClause}";

                _686DPDalGeneral dal = new _686DPDalGeneral();
                return dal._686DPConsultar(consulta, parametros);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al filtrar empleados: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al filtrar empleados: " + ex.Message, ex);
            }
        }

        public bool _686DPTraerEstado(int DNI)
        {
            try
            {
                DataTable dt;
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT DP686_Activo FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", DNI) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0][0]);
                }

                throw new Exception("No se encontró el estado del usuario.");
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener el estado de actividad del usuario '{DNI}'.");
            }
        }
        public void _686DPAgregarIntento(int dNI)
        {
            try
            {
                string consulta = $"IF EXISTS (SELECT 1 FROM [dbo].[686DP_EmpleadoIntentos] WHERE DP686_DNI = @DNI)\r\nBEGIN\r\n    UPDATE [dbo].[686DP_EmpleadoIntentos]\r\n    SET DP686_intentos = ISNULL(DP686_intentos, 0) + 1\r\n    WHERE DP686_DNI = @DNI;\r\nEND\r\nELSE\r\nBEGIN\r\n    INSERT INTO [dbo].[686DP_EmpleadoIntentos] (DP686_DNI, DP686_intentos)\r\n    VALUES (@DNI, 1);\r\nEND\r\n";
                                 

                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", dNI) };
                _686DPDalGeneral dal = new _686DPDalGeneral();
                dal._686DPEscribir(consulta, parametros);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar los intentos del empleado en la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al intentar agregar intento.", ex);
            }
        }


        public List<string> _686DPTraerRoles()
        {
            try
            {
                DataTable dt;
                List<string> roles = new List<string>();
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT DP686_Rol FROM [dbo].[686DP_Empleado]";
                ArrayList parametros = new ArrayList();

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            string rol = Convert.ToString(item[0]);
                            roles.Add(rol);
                        }
                        catch (Exception exFila)
                        {
                            throw new Exception("Error al procesar una fila del resultado de roles. Verificá los datos.", exFila);
                        }
                    }
                }

                return roles;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de SQL al intentar obtener la lista de roles: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener la lista de roles: " + ex.Message, ex);
            }

        }

        public List<_686DP_Empleados> _686DPTraerTodos()
        {
            try
            {
                DataTable dt;
                _686DPCriptoManager _686DPCriptoManager = new _686DPCriptoManager();
                List<_686DP_Empleados> empleados = new List<_686DP_Empleados>();
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT * FROM [dbo].[686DP_Empleado]";
                ArrayList parametros = new ArrayList();

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            int DNI = Convert.ToInt32(item[0]);
                            string Nombre = Convert.ToString(item[1]);
                            string Apellido = Convert.ToString(item[2]);
                            string Email = Convert.ToString(item[3]);
                            string Rol = Convert.ToString(item[4]);
                            string usuario = Convert.ToString(item[5]);
                            string contraseña = Convert.ToString(item[6]);
                            bool Activo = Convert.ToBoolean(item[7]);
                            bool Bloqueado = Convert.ToBoolean(item[8]);
                            bool cambiarContra = Convert.ToBoolean(item[9]);

                            _686DP_Empleados empleado = new _686DP_Empleados(DNI, Nombre, Apellido, Email, Rol, usuario, contraseña, Activo, Bloqueado, cambiarContra);
                            empleados.Add(empleado);
                        }
                        catch (Exception exFila)
                        {
                            throw new Exception("Error al procesar una fila de empleados. Verificá los datos. " + exFila.Message, exFila);
                        }
                    }
                }

                return empleados;
            }
            catch (SqlException exSql)
            {
                throw new Exception("Error de SQL al intentar obtener la lista de empleados: " + exSql.Message, exSql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener la lista de empleados: " + ex.Message, ex);
            }
        }

        public string _686DPTraerRol(int DNI)
        {
            try
            {
                string consulta = "SELECT DP686_Rol FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI";
                ArrayList parametros = new ArrayList
        {
            new SqlParameter("@DNI", DNI)
        };

                _686DPDalGeneral dal = new _686DPDalGeneral();
                DataTable dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToString(dt.Rows[0]["DP686_Rol"]);
                }
                else
                {
                    throw new Exception("No se encontró el usuario solicitado.");
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al obtener el rol del usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener el rol del usuario: " + ex.Message, ex);
            }
        }

        public int _686DPTraerIntentos(int dNI)
        {
            try
            {
                DataTable dt = new DataTable();
                string consulta = "SELECT DP686_intentos " +
                  "FROM [dbo].[686DP_EmpleadoIntentos] " +
                  "WHERE DP686_DNI = @DNI;";

                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", dNI) };
                _686DPDalGeneral dal = new _686DPDalGeneral();
                dt = dal._686DPConsultar(consulta, parametros);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["DP686_intentos"]);
                }
                else
                {
                    return 0;
                }

            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los intentos del empleado.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al intentar obtener intentos.", ex);
            }
        }

        public bool _686DPCambiarcontraseña(int dNI)
        {
            try
            {
                DataTable dt;
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT DP686_CambiarContraseña FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", dNI) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0]["DP686_CambiarContraseña"]);
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void _686DPReestablecerIntentos(int dNI)
        {
            try
            {
                string consulta = $"UPDATE [dbo].[686DP_EmpleadoIntentos]\r\n    SET DP686_intentos = 0\r\n    WHERE DP686_DNI = @DNI;";

                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", dNI) };
                _686DPDalGeneral dal = new _686DPDalGeneral();
                dal._686DPEscribir(consulta, parametros);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al reiniciar los intentos del empleado.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al reiniciar intentos.", ex);
            }
        }

        public bool _686DPCuentaBloqueada(int dNI)
        {
            try
            {
                DataTable dt;
                _686DPDalGeneral dal = new _686DPDalGeneral();
                string consulta = "SELECT DP686_Bloqueado FROM [dbo].[686DP_Empleado] WHERE DP686_DNI = @DNI";
                ArrayList parametros = new ArrayList { new SqlParameter("@DNI", dNI) };

                dt = dal._686DPConsultar(consulta, parametros);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0][0]);
                }

                throw new Exception("No se encontró el estado del usuario.");
            }
            catch (Exception)
            {
                throw new Exception($"Error al obtener el estado de actividad del usuario '{dNI}'.");
            }
        }

        public void _686DPCambiarcontraseñaObligatori(int dni)
        {
            try
            {
                string consulta = @"UPDATE [dbo].[686DP_Empleado]
                            SET DP686_CambiarContraseña = 1
                            WHERE DP686_DNI = @DNI";

                ArrayList parametros = new ArrayList
        {
            new SqlParameter("@DNI", dni)
        };

                _686DPDalGeneral dal = new _686DPDalGeneral();
                dal._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al establecer el cambio de contraseña obligatorio para el usuario '{dni}': {ex.Message}", ex);
            }
        }

        public void _ReestablecerObligatoriedadeContraseña(int dNI)
        {
            try
            {
                string consulta = @"UPDATE [dbo].[686DP_Empleado]
                            SET DP686_CambiarContraseña = 0
                            WHERE DP686_DNI = @DNI";

                ArrayList parametros = new ArrayList
        {
            new SqlParameter("@DNI", dNI)
        };

                _686DPDalGeneral dal = new _686DPDalGeneral();
                dal._686DPEscribir(consulta, parametros);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al establecer el cambio de contraseña obligatorio para el usuario '{dNI}': {ex.Message}", ex);
            }
        }
    }
}
