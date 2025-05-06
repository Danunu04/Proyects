using _686DP_SERVICIOS.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AseguraYa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _686DP_Desactivar();
        }

        private void _686DP_Desactivar()
        {
            DP_Admin.Enabled = false;
            DP_Contratacion.Enabled = false;
            Dp_Siniestros.Enabled = false;

        }

        private void DP_IniciarSesion_Click(object sender, EventArgs e)
        {
            _686DPfrmLogIn logIn = new _686DPfrmLogIn();
            logIn.MdiParent = this;
            logIn.Show();
        }

        private void DP_GestionDeUsuarios_Click(object sender, EventArgs e)
        {
            _686DPfrmGestionUsuarios GestionUsuarios = new _686DPfrmGestionUsuarios();
            GestionUsuarios.MdiParent = this;
            GestionUsuarios.Show();
        }

        private void DP_CambiarContraseña_Click(object sender, EventArgs e)
        {
            _686DPfrmCambiarContraseña cambiarcontraseña = new _686DPfrmCambiarContraseña();
            cambiarcontraseña.MdiParent = this;
            cambiarcontraseña.Show();
        }

        internal void Activar()
        {
            DP_Admin.Enabled = true;
            DP_Contratacion.Enabled = true;
            Dp_Siniestros.Enabled = true;
        }

        private void DP_CerrarSesion_Click(object sender, EventArgs e)
        {
            if (_686DP_Singleton.Instancia._686DPIsLogged())
            {
                _686DP_Singleton.Instancia._686DPLogOut();
                MessageBox.Show("Sesión cerrada correctamente.", "Cerrar sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay una sesión activa para cerrar.", "Cerrar sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DP_CambiarIdioma_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todavia no hago nada");
        }

        private void Dp_Ayuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Todavia no hago nada");
        }

        internal void ActivarRol()
        {
            DP_Admin.Enabled = true;
            DP_Contratacion.Enabled = true;
            Dp_Siniestros.Enabled = true;
            DP_CambiarContraseña.Enabled = false;
        }

        private void generarContratacion_Click(object sender, EventArgs e)
        {
            _686DPfrmGenerarContratación contratacion = new _686DPfrmGenerarContratación();
            contratacion.MdiParent = this;
            contratacion.Show();
        }

        private void verPolizas_Click(object sender, EventArgs e)
        {
            _686DPfrmVerPolizas Polizas = new _686DPfrmVerPolizas();
            Polizas.MdiParent = this;
            Polizas.Show();
        }
    }
}
