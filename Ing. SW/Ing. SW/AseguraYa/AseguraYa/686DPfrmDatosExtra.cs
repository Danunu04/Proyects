using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _686DP_BE;
using _686DP_BLL;

namespace AseguraYa
{
    public partial class _686DPfrmDatosExtra : Form
    {
        private int dni;
        private _686DP_Cliente cliente;
        private _686DP_BLLCLlientes bll = new _686DP_BLLCLlientes();
        public _686DPfrmDatosExtra(int dNI)
        {
            InitializeComponent();
            this.FormClosing += _686DPfrmDatosExtra_FormClosing;
            this.dni = dNI;
            cliente = bll.clientes.FirstOrDefault(c => c.DP686_DNI == dni);
        }

        private void _686DPfrmDatosExtra_Load(object sender, EventArgs e)
        {
            label1.Text = "DNI: " + dni.ToString();
        }

        private bool DatosCompletos()
        {
            return !string.IsNullOrWhiteSpace(TXTEmail.Text) &&
                   !string.IsNullOrWhiteSpace(TXTDomicilio.Text) &&
                   !string.IsNullOrWhiteSpace(TXTCodigoPostal.Text) &&
                   !string.IsNullOrWhiteSpace(TXTCuil.Text) &&
                   !string.IsNullOrWhiteSpace(TXTTitulartarjeta.Text) &&
                   !string.IsNullOrWhiteSpace(TXTNTarjeta.Text) &&
                   !string.IsNullOrWhiteSpace(TXTiva.Text) &&
                   !string.IsNullOrWhiteSpace(TXTMedioDePago.Text);
        }

        private void _686DPfrmDatosExtra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && !DatosCompletos())
            {
                MessageBox.Show("No puede cerrar el formulario sin completar los datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!DatosCompletos())
            {
                MessageBox.Show("Debe completar todos los datos antes de continuar.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cliente != null)
            {
                cliente.DP686_Email = TXTEmail.Text;
                cliente.DP686_Domicilio = TXTDomicilio.Text;
                cliente.DP686DP_CodigoPostal = Convert.ToInt32(TXTCodigoPostal.Text);
                cliente.DP686_CuitCuil = Convert.ToInt32(TXTCuil.Text);
                cliente.DP686_TitularTarjeta = TXTTitulartarjeta.Text;
                cliente.DP686_NTarjeta = Convert.ToInt32(TXTNTarjeta.Text);
                cliente.DP686_CondicionIVA = TXTiva.Text;
                cliente.DP686_medioPago = TXTMedioDePago.Text;
            }

            bll.GrabarCliente(cliente);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
