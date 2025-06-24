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
        _686DP_ExpresionesRegulares regex = new _686DP_ExpresionesRegulares();
        private _686DP_Cliente cliente;
        private _686DP_BLLCLlientes bll = new _686DP_BLLCLlientes();
        public _686DPfrmDatosExtra(int dNI)
        {
            InitializeComponent();
            this.FormClosing += _686DPfrmDatosExtra_FormClosing;
            this.dni = dNI;
            cliente = bll.TraerCliente(dni);
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
            try
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
                    cliente.DP686DP_CodigoPostal = Convert.ToInt32(TXTCodigoPostal.Text); // puede tirar error
                    cliente.DP686_CuitCuil = TXTCuil.Text;
                    cliente.DP686_TitularTarjeta = TXTTitulartarjeta.Text;
                    cliente.DP686_NTarjeta = TXTNTarjeta.Text;
                    cliente.DP686_CondicionIVA = "1";
                    cliente.DP686_medioPago = TXTMedioDePago.Text;

                    bll.GrabarCliente(cliente);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Código Postal debe ser un número válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TXTEmail_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTEmail.Text) && !regex._686DPEsEmail(TXTEmail.Text))
            {
                MessageBox.Show("Email inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTEmail.Clear();
                TXTEmail.Focus();
            }
        }

        private void TXTDomicilio_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTDomicilio.Text) && !regex._686DPEsSoloLetras(TXTDomicilio.Text))
            {
                MessageBox.Show("El domicilio solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTDomicilio.Clear();
                TXTDomicilio.Focus();
            }
        }

        private void TXTCodigoPostal_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTCodigoPostal.Text) && !regex._686DPEsNumero(TXTCodigoPostal.Text))
            {
                MessageBox.Show("Código postal inválido. Solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTCodigoPostal.Clear();
                TXTCodigoPostal.Focus();
            }
        }

        private void TXTCuil_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTCuil.Text) && !regex._686DPEsCuitCuil(TXTCuil.Text))
            {
                MessageBox.Show("CUIT/CUIL inválido. Debe contener exactamente 11 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTCuil.Clear();
                TXTCuil.Focus();
            }
        }

        private void TXTiva_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void TXTTitulartarjeta_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTTitulartarjeta.Text) && !regex._686DPEsSoloLetras(TXTTitulartarjeta.Text))
            {
                MessageBox.Show("El titular de la tarjeta solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTTitulartarjeta.Clear();
                TXTTitulartarjeta.Focus();
            }
        }

        private void TXTMedioDePago_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTMedioDePago.Text) && !regex._686DPEsSoloLetras(TXTMedioDePago.Text))
            {
                MessageBox.Show("El medio de pago solo debe contener letras.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTMedioDePago.Clear();
                TXTMedioDePago.Focus();
            }
        }

        private void TXTNTarjeta_MouseLeave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TXTNTarjeta.Text) && !regex._686DPEsTarjetaCredito(TXTNTarjeta.Text))
            {
                MessageBox.Show("Número de tarjeta inválido. Debe tener entre 13 y 19 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTNTarjeta.Clear();
                TXTNTarjeta.Focus();
            }
        }
    }
}
