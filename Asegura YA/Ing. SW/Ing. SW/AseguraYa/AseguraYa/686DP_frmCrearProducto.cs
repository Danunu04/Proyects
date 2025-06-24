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
using _686DP_BE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AseguraYa
{
    public partial class _686DP_frmCrearProducto : Form
    {
        int seleccion = 0;
        _686DP_ExpresionesRegulares _686DP_ExpresionesRegulares = new _686DP_ExpresionesRegulares();
        private int codigoPlanSeleccionado = -1;

        public _686DP_frmCrearProducto()
        {
            InitializeComponent();
            DGPlan.CellClick += DGPlan_CellClick;

        }
        _686DPBLLSeguro bll = new _686DPBLLSeguro();
        _686DP_BLLPlan bllp = new _686DP_BLLPlan();
        _686DP_BLLCobertura bllc = new _686DP_BLLCobertura();

        private void _686DP_frmCrearProducto_Load(object sender, EventArgs e)
        {
            
            CargarCombo();

            TXTDescripcionCobertura.Enabled = false;
            TXTFranquicia.Enabled = false;
            TXTProductos.Enabled = false;
            TXTSumaAsegurada.Enabled = false;

            BTNCrearProducto.Enabled = false;

            BTNCrearPlan.Enabled = false;
            BTNModificarPlan.Enabled= false;

            BTNCrearCobertura.Enabled= false;
            BTNAsociarPlan.Enabled= false;

            cmbProductos.Enabled = false;

            DGCobertura.ReadOnly = true;
            DGPlan.ReadOnly = true;
        }

        private void CargarCombo()
        {
            cmbProductos.Items.Clear();
            List<string> productos = bll.TraerProductos();
            cmbProductos.Items.AddRange(productos.ToArray());

            DGCobertura.DataSource = null;
            List<_686DP_Cobertura> Cobeturas = bllc.traerCoberturas();
            DGCobertura.DataSource = Cobeturas;
            DGCobertura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DGPlan.DataSource = null;
            List<_686DP_Plan> Planes = bllp.TraerPlanes();
            DGPlan.DataSource = Planes;
            DGPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RBCrearProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (RBCrearProducto.Checked)
            {
                TXTDescripcionCobertura.Enabled = false;
                TXTFranquicia.Enabled = false;
                TXTProductos.Enabled = true;
                TXTSumaAsegurada.Enabled = false;

                BTNCrearProducto.Enabled = true;

                BTNCrearPlan.Enabled = false;
                BTNModificarPlan.Enabled = false;

                BTNCrearCobertura.Enabled = false;
                BTNAsociarPlan.Enabled = false;

                cmbProductos.Enabled = false;

            }
            else
            {
                
                TXTDescripcionCobertura.Enabled = false;
                TXTFranquicia.Enabled = false;
                TXTProductos.Enabled = false;
                TXTSumaAsegurada.Enabled = false;

                BTNCrearProducto.Enabled = false;

                BTNCrearPlan.Enabled = false;
                BTNModificarPlan.Enabled = false;

                BTNCrearCobertura.Enabled = false;
                BTNAsociarPlan.Enabled = false;
            }
        }

        private void RBAgruparSeguro_CheckedChanged(object sender, EventArgs e)
        {
            if(RBAgruparSeguro.Checked)
            {
                
                TXTDescripcionCobertura.Enabled = true;
                TXTFranquicia.Enabled = true;
                TXTProductos.Enabled = false;
                TXTSumaAsegurada.Enabled = true;

                BTNCrearProducto.Enabled = false;

                BTNCrearPlan.Enabled = true;
                BTNModificarPlan.Enabled = true;

                BTNCrearCobertura.Enabled = true;
                BTNAsociarPlan.Enabled = true;

                cmbProductos.Enabled = true;
            }
        }

        private void BTNCrearProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXTProductos.Text != "")
                {
                    string nProducto = TXTProductos.Text;

                    bool existe = bll.VaidarProducto(nProducto);
                    if (!existe)
                    {
                        bll.CrearProucto(nProducto);
                        MessageBox.Show("Se ha creado el producto con éxito");
                        cmbProductos.Items.Add(nProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNCrearPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TXTFranquicia.Text))
                {
                    MessageBox.Show("Ingresá una franquicia para crear el plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProductos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccioná un producto antes de crear el plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string producto = cmbProductos.SelectedItem.ToString();
                decimal franquicia = Convert.ToDecimal(TXTFranquicia.Text);
                decimal prima = Convert.ToDecimal(TXTPrima.Text);

                bllp.CrearPlan(producto, franquicia, prima);

                MessageBox.Show("Plan creado con éxito.");
                CargarCombo(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("error en la carga de plan: " + ex.Message);
            }
            
        }


        private void DGPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = DGPlan.Rows[e.RowIndex];
                codigoPlanSeleccionado = Convert.ToInt32(fila.Cells["DP686_CodigoPlan"].Value);
                List <_686DP_Cobertura> coberturasXPLAN = bllc.TraerCoberturasFiltrado(codigoPlanSeleccionado);
                DGCobertura.DataSource = null;
                DGCobertura.DataSource = coberturasXPLAN;
            }
        }

        private void DGPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGPlan.SelectedRows.Count > 0)
                {
                    DataGridViewRow fila = DGPlan.SelectedRows[0];

                    DGCobertura.DataSource = null;
                    List<_686DP_Cobertura> Cobeturas = bllc.traerCoberturas();
                    DGCobertura.DataSource = Cobeturas;
                    DGCobertura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    MessageBox.Show("Por favor, seleccioná un plan de la tabla.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al recargar coberturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNCrearCobertura_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGPlan.SelectedRows.Count > 0)
                {
                    int codigoPlan = Convert.ToInt32(DGPlan.SelectedRows[0].Cells["DP686_CodigoPlan"].Value);

                    string descripcion = TXTDescripcionCobertura.Text;
                    decimal suma = Convert.ToDecimal(TXTSumaAsegurada.Text);

                    bool yaVisible = DGCobertura.Rows
                        .Cast<DataGridViewRow>()
                        .Any(r =>
                            r.Cells["DP686_Descripcion"].Value.ToString() == descripcion &&
                            Convert.ToDecimal(r.Cells["DP686_SumaAsegurada"].Value) == suma);

                    if (yaVisible)
                    {
                        MessageBox.Show("❌ Esta cobertura ya fue creada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    int codigoCobertura = bllc.CrearCobertura(descripcion, suma);
                    bllp.AsociarCoberturaAPlan(codigoPlan, codigoCobertura);

                    List<_686DP_Cobertura> coberturas = bllc.TraerCoberturasFiltrado(codigoPlan);
                    DGCobertura.DataSource = null;
                    DGCobertura.DataSource = coberturas;
                    limpiar();
                }
                else
                {
                    MessageBox.Show("Seleccioná un plan antes de agregar una cobertura.", "Atención");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear cobertura: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {
            TXTDescripcionCobertura.Text = "";
            TXTFranquicia.Text = "";
            TXTPrima.Text = "";
            TXTSumaAsegurada.Text = "";
            TXTProductos.Text = "";
            cmbProductos.SelectedIndex = -1;
        }

        private void BTNModificarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                seleccion++;

                if (seleccion == 1)
                {
                    DGCobertura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    DGCobertura.DataSource = null;
                    List<_686DP_Cobertura> Cobeturas = bllc.traerCoberturas();
                    DGCobertura.DataSource = Cobeturas;

                    if (DGCobertura.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccioná una cobertura antes de continuar.");
                        return;
                    }

                    int codigoCobertura = Convert.ToInt32(DGCobertura.SelectedRows[0].Cells["CodigoCobertura"].Value);

                    
                    if (bllp.YaExisteRelacionCoberturaPlan(codigoPlanSeleccionado, codigoCobertura))
                    {
                        MessageBox.Show("Esta cobertura ya está asociada al plan.");
                        return;
                    }

                    bllp.AsociarCoberturaAPlan(codigoPlanSeleccionado, codigoCobertura);
                    MessageBox.Show("Cobertura asociada con éxito.");
                }
                else if (seleccion == 2)
                {
                    if (codigoPlanSeleccionado == -1)
                    {
                        MessageBox.Show("Seleccioná un plan primero.");
                        return;
                    }

                    if (DGCobertura.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Seleccioná al menos una cobertura para aplicar.");
                        return;
                    }

                    foreach (DataGridViewRow fila in DGCobertura.SelectedRows)
                    {
                        int codigoCobertura = Convert.ToInt32(fila.Cells["CondigoCobertura"].Value); 

                        if (!bllp.YaExisteRelacionCoberturaPlan(codigoPlanSeleccionado, codigoCobertura))
                        {
                            bllp.AsociarCoberturaAPlan(codigoPlanSeleccionado, codigoCobertura);
                        }
                    }

                    MessageBox.Show("Coberturas asociadas con éxito.");
                    seleccion = 0;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Error: No se pudo acceder a la fila seleccionada.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                seleccion = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                seleccion = 0;
            }
        }

        private void BTNAsociarPlan_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGPlan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccioná un plan primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbProductos.SelectedItem == null)
                {
                    MessageBox.Show("Seleccioná un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int codigoPlan = Convert.ToInt32(DGPlan.SelectedRows[0].Cells["DP686_CodigoPlan"].Value);
                string producto = cmbProductos.SelectedItem.ToString();
                int codSeguro = bll.ObtenerCodSeguroPorProducto(producto);

                if (bll.YaExisteRelacionSeguroPlan(codSeguro, codigoPlan))
                {
                    MessageBox.Show("Ese seguro ya está asociado al plan.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bllp.AsociarPlanASeguro(codigoPlan, codSeguro);
                MessageBox.Show("Plan asociado al seguro con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al asociar plan con seguro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProductos.SelectedItem != null)
                {
                    string Producto = cmbProductos.SelectedItem.ToString();

                    List<_686DP_Plan> planes = bllp.TraerPlanesFiltrado(Producto);
                    DGPlan.DataSource = null;
                    DGPlan.DataSource = planes;
                    DGPlan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    DGCobertura.DataSource = null;
                    DGCobertura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar planes y coberturas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TXTProductos_TextChanged(object sender, EventArgs e)
        {
            if (TXTProductos.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares. _686DPEsSoloLetras (TXTProductos.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TXTProductos.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TXTDescripcionCobertura_TextChanged(object sender, EventArgs e)
        {
            if (TXTDescripcionCobertura.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsSoloLetras(TXTDescripcionCobertura.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TXTDescripcionCobertura.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TXTFranquicia_TextChanged(object sender, EventArgs e)
        {
            if (TXTFranquicia.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(TXTFranquicia.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TXTFranquicia.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TXTPrima_TextChanged(object sender, EventArgs e)
        {
            if (TXTPrima.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(TXTPrima.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TXTPrima.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TXTSumaAsegurada_TextChanged(object sender, EventArgs e)
        {
            if (TXTSumaAsegurada.Text != "")
            {
                try
                {

                    if (!_686DP_ExpresionesRegulares._686DPEsNumero(TXTSumaAsegurada.Text.ToString()))
                    {
                        MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TXTSumaAsegurada.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
