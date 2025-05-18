using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _686DP_SERVICIOS;
using _686DP_BLL;
using _686DP_SERVICIOS.Singleton;


namespace AseguraYa
{
    public partial class _686DPfrmLogIn : Form
    {
        private bool MostrarPassword;
        private int Intentos;
        _686DP_BLLUsuario _686DP_BLLUsuario;
        _686DPCriptoManager _686DPCriptoManager;
        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares;
        
        public _686DPfrmLogIn()
        {
            InitializeComponent();
            _686DP_BLLUsuario = new _686DP_BLLUsuario();
            _686DPCriptoManager = new _686DPCriptoManager();
            _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        }

        private void DP_BTNIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                if (_686DP_Singleton.Instancia._686DPIsLogged())
                {
                    MessageBox.Show("Ya hay una sesión activa, prueba de nuevo mas tarde", "Sesión activa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int DNI = Convert.ToInt32(DP_TXTUsuario.Text);
                string Contraseña = DP_TXTContraseña.Text;
                string ContraseñaHash = _686DPCriptoManager._686DPGetSHA256(Contraseña);
                if (DP_TXTUsuario.Text != "" || DP_TXTContraseña.Text != "")
                {
                    string Usuario = _686DP_BLLUsuario._686DPTraerUsuario(DNI);
                    if(Usuario != "")
                    {
                        bool Activo = _686DP_BLLUsuario._686DPTraerEstado(DNI);
                        if(Activo)
                        {
                            bool Bloqueado = _686DP_BLLUsuario._686DPCuentaBloqueada(DNI);
                            if(!Bloqueado)
                            {
                                string ContraseñaBD = _686DP_BLLUsuario._686DPTraerContraseña(DNI);
                                if (ContraseñaHash == ContraseñaBD)
                                {
                                    _686DP_Usuario usuarioCompleto = _686DP_BLLUsuario._686DPGenerarUsuarioSingleton(Usuario, ContraseñaHash, DNI);
                                    _686DP_Singleton.Instancia._686DPLogIN(usuarioCompleto);
                                    MessageBox.Show("La sesión se inició correctamente");
                                    _686DP_BLLUsuario._686DPReestablecerIntentos(DNI);
                                    string _686DPRol = _686DP_BLLUsuario.TraerRol(DNI);
                                    if (_686DPRol == "Amdmin")
                                    {
                                        (this.MdiParent as Form1)?.ActivarRol();
                                        this.Close();
                                    }
                                    else
                                    {
                                        (this.MdiParent as Form1)?.Activar();
                                        this.Close();
                                    }
                                    bool cambiarContraseña = _686DP_BLLUsuario._686DPCambiarContraseña(DNI);
                                    if (cambiarContraseña)
                                    {
                                        _686DPfrmCambiarContraseña cambiarcontra = new _686DPfrmCambiarContraseña();
                                        cambiarcontra.Show();
                                        (this.MdiParent as Form1)?.DesactivarTodo();
                                        this.Close();
                                    }


                                }
                                else
                                {
                                    
                                    _686DP_BLLUsuario.RegistrarError(DNI);
                                    int intentos = _686DP_BLLUsuario._686DPTraerIntentos(DNI);
                                    MessageBox.Show($"Contraseña incorrecta, intentos restantes: {3-intentos}", "Error De inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    if (intentos >= 3)
                                    {
                                        _686DP_BLLUsuario._686DPBloquearUsuario(DNI);
                                        MessageBox.Show("Su usuario ha sido bloqueado, comunicarse con el administrador", "Error De inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Su cuenta está bloqueada por muchos intentos de acceso fallidos, contactar al administrador para ser debloqueado");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario desactivado por baja del mismo, solicitar activación", "Error De inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario incorrecto", "Error De inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos", "Error De inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DP_BTNIniciarSesion_MouseHover(object sender, EventArgs e)
        {
            DP_BTNIniciarSesion.BackColor = Color.White;
            DP_BTNIniciarSesion.ForeColor = Color.Black;
        }

        private void DP_BTNIniciarSesion_MouseLeave(object sender, EventArgs e)
        {
            DP_BTNIniciarSesion.BackColor = Color.DarkSlateGray;
            DP_BTNIniciarSesion.ForeColor= Color.White;
        }

        private void _686DPfrmLogIn_Load(object sender, EventArgs e)
        {
            DP_TXTUsuario.BorderStyle = BorderStyle.None;
            DP_TXTContraseña.BorderStyle = BorderStyle.None;
        }

        private void DP_TXTUsuario_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTUsuario.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(DP_TXTUsuario.Text))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTUsuario.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarPassword = !MostrarPassword;
            DP_TXTContraseña.PasswordChar = MostrarPassword ? '\0' : '*';
        }

        private void DP_TXTContraseña_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
