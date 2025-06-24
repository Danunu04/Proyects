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
    public partial class _686DPfrmModificarSeguro : Form
    {
        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        private int codigoPlanSeleccionado = -1;
        _686DP_Poliza poliza = null;
        _686DP_Plan plan = null;
        _686DP_BLLPoliza bll = new _686DP_BLLPoliza();
        _686DPBLLSeguro blls = new _686DPBLLSeguro();
        _686DP_BLLPlan bLLPlan = new _686DP_BLLPlan();
        _686DP_BLLCobertura bllc = new _686DP_BLLCobertura();
        public _686DPfrmModificarSeguro()
        {
            InitializeComponent();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(textBox1.Text))
                    {
                        MessageBox.Show("Solo se permiten números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        return;
                    }

                    int numeroDePoliza = Convert.ToInt32(textBox1.Text);
                    bool existe = bll.BuscarPoliza(numeroDePoliza);

                    if (!existe)
                    {
                        MessageBox.Show("El número de póliza no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    poliza = bll.traerDatosPoliza(numeroDePoliza);
                    cargarDG();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar la póliza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarDG()
        {
            try
            {
                DGPlan.DataSource = null;
                plan = bll.TraerPlan(poliza.DP686_CodPlan);
                DGPlan.DataSource = new List<_686DP_Plan> { plan };
                DGPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DGCoberura.DataSource = null;
                DGCoberura.DataSource = plan.Coberturas;
                DGCoberura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                _686DP_Seguro seguro = bll.TraerSeguro(poliza.DP686_CodSeguro);
                TXTProducto.Text = seguro.DP686_TipoProducto.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la póliza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                try
                {
                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(textBox1.Text))
                    {
                        MessageBox.Show("Solo se permiten números enteros válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTNAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (poliza == null)
                {
                    MessageBox.Show("No hay póliza cargada para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(TXTProducto.Text) || codigoPlanSeleccionado == -1)
                {
                    MessageBox.Show("Completá todos los campos requeridos.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string producto = TXTProducto.Text.Trim();
                int nPoliza = Convert.ToInt32(textBox1.Text);

                poliza.DP686_CodPlan = codigoPlanSeleccionado;
                poliza.DP686_CodSeguro = blls.ObtenerCodSeguroPorProducto(producto);
                poliza.DP686_FechaVencimiento = DateTime.Now.AddMonths(1);

                bll.ModificarPoliza(poliza);
                MessageBox.Show("Póliza modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la póliza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void _686DPfrmModificarSeguro_Load(object sender, EventArgs e)
        {

        }

        private void TXTProducto_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                string producto = TXTProducto.Text.Trim();
                if (string.IsNullOrWhiteSpace(producto)) return;

                string product = blls.buscarProducto(producto);
                if (product != null)
                {
                    DGPlan.DataSource = null;
                    List<_686DP_Plan> planes = bLLPlan.TraerPlanesFiltrado(product);
                    DGPlan.DataSource = planes;
                    DGPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar planes del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && DGPlan.Rows[e.RowIndex].Cells["DP686_CodigoPlan"].Value != null)
                {
                    DataGridViewRow fila = DGPlan.Rows[e.RowIndex];
                    codigoPlanSeleccionado = Convert.ToInt32(fila.Cells["DP686_CodigoPlan"].Value);

                    List<_686DP_Cobertura> coberturasXPLAN = bllc.TraerCoberturasFiltrado(codigoPlanSeleccionado);
                    DGCoberura.DataSource = null;
                    DGCoberura.DataSource = coberturasXPLAN;
                    DGCoberura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar plan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
