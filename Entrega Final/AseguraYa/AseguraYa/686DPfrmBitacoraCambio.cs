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
    public partial class _686DPfrmBitacoraCambio : Form
    {
        public _686DPfrmBitacoraCambio(object idiomaLocal)
        {
            InitializeComponent();
        }
        
        _686DPBLLClienteC bllcc = new _686DPBLLClienteC();
        List<_686DPCliente_C> clientesC = new List<_686DPCliente_C>();
        private void Aplicar_Click(object sender, EventArgs e)
        {
            if (clientesC == null || !clientesC.Any())
            {
                MessageBox.Show("No hay datos para filtrar.");
                return;
            }

            var filtrada = clientesC.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                if (int.TryParse(textBox2.Text.Trim(), out int dni))
                {
                    filtrada = filtrada.Where(c => c.DP686_DNI == dni);
                }
                else
                {
                    MessageBox.Show("El DNI debe ser numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (dateTimePicker1.Checked)
            {
                DateTime fechaDesde = dateTimePicker1.Value.Date;
                filtrada = filtrada.Where(c => c.DP686_Fecha.Date >= fechaDesde);
            }

            if (dateTimePicker2.Checked)
            {
                DateTime fechaHasta = dateTimePicker2.Value.Date;
                filtrada = filtrada.Where(c => c.DP686_Fecha.Date <= fechaHasta);
            }

            dataGridView1.DataSource = filtrada.ToList();

            if (!filtrada.Any())
                MessageBox.Show("No se encontraron registros que coincidan con los filtros aplicados.");
        }

        private void _686DPfrmBitacoraCambio_Load(object sender, EventArgs e)
        {
            clientesC = bllcc.TraerCambios();
            dataGridView1.DataSource = clientesC;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientesC;
            dataGridView1.DataSource = clientesC;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ReadOnly = true;
        }

        private void Desbloquear_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un cliente para desbloquear.");
                return;
            }

            _686DPCliente_C seleccionado = (_686DPCliente_C)dataGridView1.SelectedRows[0].DataBoundItem;

            var duplicadoActivo = clientesC
                .FirstOrDefault(c => c.DP686_DNI == seleccionado.DP686_DNI &&
                                     c.ID != seleccionado.ID &&
                                     c.DP686_Estado == true);

            if (duplicadoActivo != null)
            {
                duplicadoActivo.DP686_Estado = false;
                duplicadoActivo.DP686_Activo = false;
                bllcc.ActualizarClienteC(duplicadoActivo);
            }

            seleccionado.DP686_Estado = true;
            seleccionado.DP686_Activo = true;
            bllcc.ActualizarClienteC(seleccionado);

            _686DP_BLLCLlientes bllClientes = new _686DP_BLLCLlientes();
            bllClientes.ReemplazarCliente(seleccionado);

            clientesC = bllcc.TraerCambios();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clientesC;

            MessageBox.Show("Cliente desbloqueado correctamente.");
        }
    }
}
