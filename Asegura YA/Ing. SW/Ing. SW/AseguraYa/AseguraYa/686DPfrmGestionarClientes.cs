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
using _686DP_SERVICIOS;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AseguraYa
{
    public partial class _686DPfrmGestionarClientes : Form
    {
        private bool estaEncriptado = false;

        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        public _686DP_Cliente ClienteCreado { get; private set; }
        _686DP_BLLCLlientes bll = new _686DP_BLLCLlientes();
        string modo;
        public _686DPfrmGestionarClientes()
        {
            InitializeComponent();
        }

        private void _686DPfrmGestionarClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            cargarDG();
        }
        private void cargarDG()
        {
            dataGridView1.DataSource = null;
            List<_686DP_Cliente> clientes = bll.TraerClientes();
            dataGridView1.DataSource = clientes;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modo = "Modificar";
            dataGridView1.ReadOnly = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DP_TXTApellido.Enabled = true;
            DP_TXTDNI.Enabled = true;
            DP_TXTNombre.Enabled = true;
            modo = "Crear";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch(modo)
            {
                case "Crear":
                    {
                        if (string.IsNullOrWhiteSpace(DP_TXTDNI.Text) || string.IsNullOrWhiteSpace(DP_TXTNombre.Text) || string.IsNullOrWhiteSpace(DP_TXTApellido.Text))
                        {
                            MessageBox.Show("Por favor, completá DNI, Nombre y Apellido.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        try
                        {
                            int dni = Convert.ToInt32(DP_TXTDNI.Text);
                            bool existe = bll.ValidarNuevo(dni); // Valida que no esté registrado ese DNI

                            if (existe)
                            {
                                MessageBox.Show("Ese cliente ya está registrado.");
                                return;
                            }



                            // Si querés devolver el cliente:
                            ClienteCreado = new _686DP_Cliente(dni, DP_TXTNombre.Text, DP_TXTApellido.Text);
                            bll.crear(ClienteCreado);
                            MessageBox.Show("El cliente ha sido creado con éxito.");
                            
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("El DNI debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }

                case "Modificar":
                    {
                        if (dataGridView1.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Debe seleccionar una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                        DataGridViewRow fila = dataGridView1.SelectedRows[0];
                        int dniSeleccionado = Convert.ToInt32(fila.Cells["DP686_DNI"].Value);

                        _686DP_Cliente cliente = bll.clientes.FirstOrDefault(c => c.DP686_DNI == dniSeleccionado);

                        if (cliente == null)
                        {
                            MessageBox.Show("No se encontró el cliente en la lista interna.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                        fila.Cells["DP686_Nombre"].Value = string.IsNullOrWhiteSpace(cliente.DP686_Nombre) ? "NULL" : cliente.DP686_Nombre;
                        fila.Cells["DP686_Apellido"].Value = string.IsNullOrWhiteSpace(cliente.DP686_Apellido) ? "NULL" : cliente.DP686_Apellido;
                        fila.Cells["DP686_Email"].Value = string.IsNullOrWhiteSpace(cliente.DP686_Email) ? "NULL" : cliente.DP686_Email;
                        fila.Cells["DP686_NTarjeta"].Value = string.IsNullOrWhiteSpace(cliente.DP686_NTarjeta) ? "NULL" : cliente.DP686_NTarjeta;
                        fila.Cells["DP686_Domicilio"].Value = string.IsNullOrWhiteSpace(cliente.DP686_Domicilio) ? "NULL" : cliente.DP686_Domicilio;
                        fila.Cells["DP686DP_CodigoPostal"].Value = cliente.DP686DP_CodigoPostal == 0 ? "NULL" : cliente.DP686DP_CodigoPostal.ToString();
                        fila.Cells["DP686_CuitCuil"].Value = string.IsNullOrWhiteSpace(cliente.DP686_CuitCuil) ? "NULL" : cliente.DP686_CuitCuil;
                        fila.Cells["DP686_CondicionIVA"].Value = string.IsNullOrWhiteSpace(cliente.DP686_CondicionIVA) ? "NULL" : cliente.DP686_CondicionIVA;
                        
                        fila.Cells["DP686_Estado"].Value = cliente.DP686_Estado == null
                        ? "NULL"
                        : (cliente.DP686_Estado == true ? "Activo" : "Inactivo");

                        fila.Cells["DP686_TitularTarjeta"].Value = string.IsNullOrWhiteSpace(cliente.DP686_TitularTarjeta) ? "NULL" : cliente.DP686_TitularTarjeta;
                        fila.Cells["DP686_medioPago"].Value = string.IsNullOrWhiteSpace(cliente.DP686_medioPago) ? "NULL" : cliente.DP686_medioPago;
                        
                        fila.Cells["DP686_FechaVencimineto"].Value = cliente.DP686_FechaVencimiento == DateTime.MinValue
                            ? "NULL"
                            : cliente.DP686_FechaVencimiento.ToShortDateString();

                        bll.GrabarCliente(cliente);
                        break;
                    }
                case "Eliminar":
                    {

                        if (dataGridView1.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Debés seleccionar un usuario para activar o desactivar.", "Seleccionar fila", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                        object valorActivo = filaSeleccionada.Cells["DP686_Estado"].Value;

                        if (valorActivo == null || valorActivo == DBNull.Value)
                        {
                            MessageBox.Show("El campo 'Estado' no tiene un valor válido.", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool estadoActual = Convert.ToBoolean(valorActivo);
                        filaSeleccionada.Cells["DP686_Estado"].Value = !estadoActual;
                        
                        int DNi = Convert.ToInt32(filaSeleccionada.Cells["DP686_DNI"].Value);
                        bll.eliminadologico(DNi);
                       
                        string mensaje = estadoActual ? "Usuario desactivado correctamente." : "Usuario Activado correctamente.";
                        MessageBox.Show(mensaje, "Cambio de estado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            modo = "Eliminar";
        }

        private void DP_TXTNombre_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTNombre.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsSoloLetras(DP_TXTNombre.Text))
                    {
                        MessageBox.Show("Solo se permiten caracteres alfabéticos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTNombre.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DP_TXTApellido_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTApellido.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsSoloLetras(DP_TXTApellido.Text))
                    {
                        MessageBox.Show("Solo se permiten caracteres alfabéticos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTApellido.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DP_TXTDNI_TextChanged(object sender, EventArgs e)
        {
            if (DP_TXTDNI.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(DP_TXTDNI.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DP_TXTDNI.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            _686DPCriptoManager cripto = new _686DPCriptoManager();

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;

                var valorCelda = fila.Cells["DP686_Email"].Value;
                if (valorCelda == null) continue;

                string contenido = valorCelda.ToString();

                if (!string.IsNullOrWhiteSpace(contenido))
                {
                    try
                    {
                        if (!estaEncriptado)
                        {
                            // Encriptar
                            string encriptado = cripto._686DPGetAES256(contenido);
                            fila.Cells["DP686_Email"].Value = encriptado;
                        }
                        else
                        {
                            // Desencriptar
                            string desencriptado = cripto._686DPGetAESDecrypt(contenido).ToString();
                            fila.Cells["DP686_Email"].Value = desencriptado;
                        }
                    }
                    catch
                    {
                        MessageBox.Show($"Error al {(estaEncriptado ? "desencriptar" : "encriptar")} el valor: {contenido}");
                    }
                }
            }

            // Invertir el estado
            estaEncriptado = !estaEncriptado;
        }
    }
}
