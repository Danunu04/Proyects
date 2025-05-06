using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            bll= new _686DP_BLLUsuario();
        }

        private void label3_Click(object sender, EventArgs e)
        {

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

        private void DP_TXTContraseñaActual_TextChanged(object sender, EventArgs e)
        {
            string contraseñaActual = DP_TXTContraseñaActual.Text;
            string contraseñaActualHash = _686DPCriptoManager._686DPGetSHA256(contraseñaActual); // Deberías usar SHA256 si así se guardó
            int DNI = _686DP_Singleton.Instancia.Usuario._686DPDNI;
            string ContraseñaBD = bll._686DPTraerContraseña(DNI);
            if (contraseñaActualHash == ContraseñaBD)
            {
                if (DP_TXTContraseñaNueva.Text == DP_TXTConfirmación.Text)
                {
                    bll._686DPVerificarContraseñas(DNI);
                    string contraseñaNuevaHash = _686DPCriptoManager._686DPGetSHA256(DP_TXTContraseñaNueva.Text);
                    bool ok = bll._686DPCompararContraseñas(contraseñaNuevaHash, ContraseñaBD,DNI);
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                MessageBox.Show("Contraseña actual incorrecta", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
