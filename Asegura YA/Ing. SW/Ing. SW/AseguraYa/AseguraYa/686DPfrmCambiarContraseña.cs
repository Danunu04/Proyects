using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _686DP_BLL;
using _686DP_SERVICIOS;
using _686DP_SERVICIOS.Singleton;

namespace AseguraYa
{
    public partial class _686DPfrmCambiarContraseña : Form
    {
        _686DPCriptoManager _686DPCriptoManager;
        _686DP_BLLUsuario bll;
        public _686DPfrmCambiarContraseña()
        {
            InitializeComponent();
            _686DPCriptoManager = new _686DPCriptoManager();
            bll = new _686DP_BLLUsuario();
        }

        private void DP_BTNAplicar_MouseHover(object sender, EventArgs e)
        {
            DP_BTNAplicar.ForeColor = Color.Black;
            DP_BTNAplicar.BackColor = Color.White;
        }

        private void DP_BTNAplicar_MouseLeave(object sender, EventArgs e)
        {
            DP_BTNAplicar.ForeColor = Color.White;
            DP_BTNAplicar.BackColor = Color.DarkSlateGray;
        }

        private void _686DPfrmCambiarContraseña_Load(object sender, EventArgs e)
        {
            DP_TXTConfirmación.BorderStyle = BorderStyle.None;
            DP_TXTContraseñaActual.BorderStyle = BorderStyle.None;
            DP_TXTContraseñaNueva.BorderStyle = BorderStyle.None;
        }

        private void _686DPfrmCambiarContraseña_FormClosing(object sender, FormClosingEventArgs e)
        {
            int DNI = _686DP_Singleton.Instancia.Usuario._686DPDNI;
            bool cambiarContraseña = bll._686DPCambiarContraseña(DNI);

            if (cambiarContraseña)
            {
                MessageBox.Show("Debe cambiar su contraseña antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void DP_BTNAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string contraseñaActual = DP_TXTContraseñaActual.Text;
                string contraseñaNueva = DP_TXTContraseñaNueva.Text;
                string confirmacion = DP_TXTConfirmación.Text;
                int DNI = _686DP_Singleton.Instancia.Usuario._686DPDNI;

                string contraseñaActualHash = _686DPCriptoManager._686DPGetSHA256(contraseñaActual);
                string contraseñaBD = bll._686DPTraerContraseña(DNI);

                if (contraseñaActualHash != contraseñaBD)
                {
                    MessageBox.Show("Contraseña actual incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (contraseñaNueva != confirmacion)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string contraseñaNuevaHash = _686DPCriptoManager._686DPGetSHA256(contraseñaNueva);
                bll._686DPVerificarContraseñas(DNI);

                bool ok = bll._686DPCompararContraseñas(contraseñaNuevaHash, contraseñaBD, DNI);

                if (ok)
                {
                    bll._686DPNuevaContra(contraseñaNuevaHash, DNI);
                    bll._ReestablecerObligatoriedadeContraseña(DNI);
                    MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_686DP_Singleton.Instancia._686DPIsLogged())
                    {
                        _686DP_Singleton.Instancia._686DPLogOut();
                        MessageBox.Show("Sesión cerrada por cuestiones de seguridad.", "Cerrar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hubo un error inesperado en el cambio de contraseña" + ex.Message);
            }
            
        }

        private void DP_TXTContraseñaActual_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
