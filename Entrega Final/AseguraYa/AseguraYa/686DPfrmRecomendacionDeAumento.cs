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
    public partial class _686DPfrmRecomendacionDeAumento : Form
    {
        _686DP_BLLSiniestro blls = new _686DP_BLLSiniestro();
        public _686DPfrmRecomendacionDeAumento(string idiomaLocal)
        {
            InitializeComponent();
        }

        private void _686DPfrmRecomendacionDeAumento_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = blls.traerSiniestrosMayoresA5();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AumentarCuota_Click(object sender, EventArgs e)
        {
            using (frmInputBox frm = new frmInputBox("Ingrese el porcentaje de aumento:", "Aumento de Póliza"))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string valorIngresado = frm.Resultado;
                    MessageBox.Show($"Ingresaste: {valorIngresado}%", "Resultado");
                }
            }
        }
    }
}
