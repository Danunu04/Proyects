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
    public partial class _686DPfrmRegistrarCliente : Form
    {
        _686DP_BLLCLlientes clientes = new _686DP_BLLCLlientes();
        public _686DP_Cliente ClienteCreado { get; private set; }
        public _686DPfrmRegistrarCliente()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DP_TXTDNI.Text) || string.IsNullOrWhiteSpace(DP_TXTNombre.Text) ||string.IsNullOrWhiteSpace(DP_TXTApellido.Text))
            {
                MessageBox.Show("Por favor, completá DNI, Nombre y Apellido.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int dni = Convert.ToInt32(DP_TXTDNI.Text);
                bool existe = clientes.ValidarNuevo(dni); // Valida que no esté registrado ese DNI

                if (existe)
                {
                    MessageBox.Show("Ese cliente ya está registrado.");
                    return;
                }

                

                // Si querés devolver el cliente:
                ClienteCreado = new _686DP_Cliente(dni, DP_TXTNombre.Text, DP_TXTApellido.Text);
                clientes.crear(ClienteCreado);
                MessageBox.Show("El cliente ha sido creado con éxito.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("El DNI debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
