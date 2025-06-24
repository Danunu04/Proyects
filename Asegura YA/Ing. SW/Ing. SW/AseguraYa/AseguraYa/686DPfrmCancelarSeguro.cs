using _686DP_BE;
using _686DP_BLL;
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
    public partial class _686DPfrmCancelarSeguro : Form
    {
        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        _686DP_BLLPoliza bll = new _686DP_BLLPoliza();
        _686DP_Poliza poliza = null;
        public _686DPfrmCancelarSeguro()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(textBox1.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (int.TryParse(textBox1.Text, out int numeroDePoliza))
                    {
                        bool existe = bll.BuscarPoliza(numeroDePoliza);
                        if (!existe)
                        {
                            MessageBox.Show("El número de póliza no existe");
                        }
                        else
                        {
                            poliza = bll.traerDatosPoliza(numeroDePoliza);
                            dataGridView1.DataSource = new List<_686DP_Poliza> { poliza };
                        }
                    }
                    else
                    {
                        MessageBox.Show("Formato inválido para número de póliza.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la póliza: " + ex.Message);
            }
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text) &&
                    !string.IsNullOrEmpty(textBox2.Text) &&
                    poliza != null)
                {
                    string motivo = textBox2.Text;
                    bll.eliminarPoliza(motivo, poliza);
                    MessageBox.Show("La póliza se eliminó con éxito");
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos y seleccione una póliza válida.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la póliza: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsSoloLetras(textBox2.Text))
                    {
                        MessageBox.Show("Solo se permiten caracteres alfabéticos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
