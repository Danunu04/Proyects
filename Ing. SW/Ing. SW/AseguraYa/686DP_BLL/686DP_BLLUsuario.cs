using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _686DP_BE;
using _686DP_MPP;
using _686DP_SERVICIOS;
using static System.Net.Mime.MediaTypeNames;

namespace _686DP_BLL
{
    public class _686DP_BLLUsuario
    {
        _686DPMPPUsuarios dal = new _686DPMPPUsuarios();
        public List<_686DP_Empleados> ListaDeEmpleados { get; private set; }
        public List<string> lista { get; private set; }
        public _686DP_BLLUsuario()
        {
            ListaDeEmpleados = new List<_686DP_Empleados>();
            lista = new List<string>();
        }

        public void _686DPBloquearUsuario(int dni)
        {
            try
            {
               
                dal._686DPBloquearUsuario(dni);
            }
            catch 
            {
                throw new Exception("Error al modificar el estado del usuario.");
            }
        }

        public object _686DPFiltrarGridFlexible(string rol, bool? activo, bool? bloqueado)
        {
            try
            {
                
                return dal._686DPFiltrarEmpleados(rol, activo, bloqueado);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar los empleados en la BLL: " + ex.Message, ex);
            }
        }

        public _686DP_Usuario _686DPGenerarUsuarioSingleton(string nombreUsuario, string contraseña, int Dni)
        {
            try
            {
                return new _686DP_Usuario
                {
                    _686DPNombreUsuario = nombreUsuario,
                    _686DPPassword = contraseña,
                    _686DPDNI = Dni
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el usuario singleton.", ex);
            }
        }

        public string _686DPTraerContraseña(int dni)
        {
            try
            {
                return dal._686DPBuscarContraseña(dni);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al traer la contraseña para el usuario con el DNI: '{dni}'.", ex);
            }
        }

        public bool _686DPTraerEstado(int dni)
        {
            try
            {
              
                return dal._686DPTraerEstado(dni);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el estado del usuario con el dni: '{dni}'.", ex);
            }
        }

        public List<string> _686DPtraerRoles()
        {
            
            List<string> roles = dal._686DPTraerRoles();
            return roles;
        }

        public object _686DPTraerTodos()
        {
            try
            {
                ListaDeEmpleados = dal._686DPTraerTodos(); // ya es List<_686DP_Empleados>;
                return ListaDeEmpleados;
            } 
            catch (Exception ex)
            {
                throw new Exception("Error al traer los usuarios de la base de datos",ex);
            }
        }

        public string _686DPTraerUsuario(int dni)
        {
            try
            {
                return dal._686DPBuscarUsuario(dni);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el usuario con el dni:  '{dni}'.", ex);
            }
        }

        public void _686DPActualizarEmpleadoExistente(_686DP_Empleados emp)
        {
            try
            {
                dal._686DPActualizarEmpleadoExistente(emp);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al actualizar el empleado: " + ex.Message, ex);
            }
        }

        public void _686DPVerificarContraseñas(int Dni)
        {
            try
            {
                lista = dal._686DPVerificarContraseñas(Dni);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la BLL al actualizar el empleado: " + ex.Message, ex);
            }
        }

        public bool _686DPCompararContraseñas(string nuevaContraseña, string contraseñaActual,int dni)
        {
            try
            {
                bool esValida = true;

                foreach (string anterior in lista)
                {
                    if (nuevaContraseña == anterior)
                    {
                        esValida = false;
                        throw new Exception("La nueva contraseña no puede ser igual a una ya utilizada anteriormente.");
                    }
                }

                if (esValida)
                {
                    dal._686DPGrabarContraseñaNueva(nuevaContraseña, dni);
                    dal._686DPAgregarALita(contraseñaActual, dni);
                }

                return esValida;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al comparar o guardar la contraseña: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar o guardar la contraseña: " + ex.Message, ex);
            }
        }

        public string TraerRol(int DNI)
        {
            try
            { 
                return dal._686DPTraerRol(DNI);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al traer el rol del usuario: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al obtener el rol: " + ex.Message, ex);
            }
        }


        public void GuardarContraseña(string contraseñaAnterior, int dni)
        {
            try
            {
                dal._686DPGrabarContraseñaNueva(contraseñaAnterior, dni);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error SQL al guardar la nueva contraseña: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inesperado al guardar la nueva contraseña: " + ex.Message, ex);
            }
        }

    }
}
