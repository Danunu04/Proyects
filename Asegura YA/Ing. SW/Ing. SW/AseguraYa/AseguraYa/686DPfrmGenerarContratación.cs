using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _686DP_BE;
using _686DP_BLL;

namespace AseguraYa
{
    public partial class _686DPfrmGenerarContratación : Form
    {
        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        _686DP_Cliente nuevoCliente = null;
        private int codigoPlanSeleccionado = -1;
        private decimal prima = 0;
        _686DP_BLLCLlientes bll = new _686DP_BLLCLlientes();
        _686DPBLLSeguro blls = new _686DPBLLSeguro();
        _686DP_BLLPoliza bllp = new _686DP_BLLPoliza();
        public _686DPfrmGenerarContratación()
        {
            InitializeComponent();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    int DNI = Convert.ToInt32(textBox1.Text);
                    bool existe = bll.ValidarNuevo(DNI);
                    if (!existe)
                    {
                        MessageBox.Show("El cliente no existe");
                        _686DPfrmRegistrarCliente rc = new _686DPfrmRegistrarCliente();
                        if (rc.ShowDialog() == DialogResult.OK)
                        {
                            nuevoCliente = rc.ClienteCreado;
                        }
                    }
                    else
                    {
                        nuevoCliente = bll.TraerCliente(DNI);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _686DPfrmGenerarContratación_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCombo()
        {
            try
            {
                CMBProducto.Items.Clear();
                List<string> productos = blls.TraerProductos();
                CMBProducto.Items.AddRange(productos.ToArray());

                DGCoberturas.DataSource = null;
                DGCoberturas.DataSource = blls.traerCoberturas();
                DGCoberturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DGPlan.DataSource = null;
                DGPlan.DataSource = blls.TraerPlanes();
                DGPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar planes y coberturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CMBProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Producto = CMBProducto.SelectedItem.ToString();

                List<_686DP_Plan> planes = blls.TraerPlanesFiltrado(Producto);
                DGPlan.DataSource = null;
                DGPlan.DataSource = planes;
                DGPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DGCoberturas.DataSource = null;
                DGCoberturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar planes y coberturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow fila = DGPlan.Rows[e.RowIndex];
                    codigoPlanSeleccionado = Convert.ToInt32(fila.Cells["DP686_CodigoPlan"].Value);
                    prima = Convert.ToDecimal(fila.Cells["DP686_Prima"].Value);
                    DGCoberturas.DataSource = null;
                    DGCoberturas.DataSource = blls.TraerCoberturasFiltrado(codigoPlanSeleccionado);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar plan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int DNI = Convert.ToInt32(textBox1.Text);
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Ingresá un DNI válido.", "Falta DNI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (codigoPlanSeleccionado == -1)
                {
                    MessageBox.Show("Debe seleccionar un plan antes de continuar.", "Plan no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cliente = nuevoCliente ?? bll.TraerCliente(DNI);

                List<string> faltantes = new List<string>();

                if (string.IsNullOrWhiteSpace(cliente.DP686_Email)) faltantes.Add("Email");
                if (string.IsNullOrWhiteSpace(cliente.DP686_Domicilio)) faltantes.Add("Domicilio");
                if (cliente.DP686DP_CodigoPostal == 0) faltantes.Add("Código Postal");
                if (string.IsNullOrWhiteSpace(cliente.DP686_CuitCuil)) faltantes.Add("Cuit/Cuil");
                if (string.IsNullOrWhiteSpace(cliente.DP686_CondicionIVA)) faltantes.Add("Condición IVA");
                if (string.IsNullOrWhiteSpace(cliente.DP686_TitularTarjeta)) faltantes.Add("Titular de Tarjeta");
                if (string.IsNullOrWhiteSpace(cliente.DP686_medioPago)) faltantes.Add("Medio de Pago");
                if (string.IsNullOrWhiteSpace(cliente.DP686_NTarjeta)) faltantes.Add("N° Tarjeta");

                if (faltantes.Count > 0)
                {
                    _686DPfrmDatosExtra datosextra = new _686DPfrmDatosExtra(DNI);
                    var result = datosextra.ShowDialog(); // espera que se cierre

                    if (result != DialogResult.OK)
                    {
                        MessageBox.Show("No se completaron los datos del cliente.", "Proceso cancelado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Volver a traer cliente actualizado y revalidar
                    cliente = bll.TraerCliente(DNI);

                    List<string> faltantesDespues = new List<string>();
                    if (string.IsNullOrWhiteSpace(cliente.DP686_Email)) faltantesDespues.Add("Email");
                    if (string.IsNullOrWhiteSpace(cliente.DP686_Domicilio)) faltantesDespues.Add("Domicilio");
                    if (cliente.DP686DP_CodigoPostal == 0) faltantesDespues.Add("Código Postal");
                    if (string.IsNullOrWhiteSpace(cliente.DP686_CuitCuil)) faltantesDespues.Add("Cuit/Cuil");
                    if (string.IsNullOrWhiteSpace(cliente.DP686_CondicionIVA)) faltantesDespues.Add("Condición IVA");
                    if (string.IsNullOrWhiteSpace(cliente.DP686_TitularTarjeta)) faltantesDespues.Add("Titular de Tarjeta");
                    if (string.IsNullOrWhiteSpace(cliente.DP686_medioPago)) faltantesDespues.Add("Medio de Pago");
                    if (string.IsNullOrWhiteSpace(cliente.DP686_NTarjeta)) faltantesDespues.Add("N° Tarjeta");
                    //if (cliente.DP686_FechaVencimiento == DateTime.MinValue) faltantesDespues.Add("Fecha de Vencimiento");

                    if (faltantesDespues.Count > 0)
                    {
                        MessageBox.Show("Los datos del cliente aún están incompletos:\n" + string.Join(", ", faltantesDespues), "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                int codSeguro = blls.ObtenerCodSeguroPorProducto(CMBProducto.SelectedItem.ToString());
                bllp.CrearPoliza(codSeguro, prima, DNI, codigoPlanSeleccionado);

                MessageBox.Show("Póliza generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar la contratación:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void CMBProducto_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}
