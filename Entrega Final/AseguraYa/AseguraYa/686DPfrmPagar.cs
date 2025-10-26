using _686DP_BLL;
using _686DP_SERVICIOS.Observer;
using Org.BouncyCastle.Pqc.Crypto.Lms;
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
    public partial class _686DPfrmPagar : Form
    {
        _686DP_BLLSiniestro blls = new _686DP_BLLSiniestro();
        _686DP_BLLDigitoVerificador BLLDV = new _686DP_BLLDigitoVerificador();
        public int CodSiniestro { get; set; }
        public int NroPoliza { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }
        public string EvaluacionSistema { get; set; }

        string idioma;

        _686DP_LanguajeManager LMG = new _686DP_LanguajeManager();
        _686DP_Idioma IdiomaClase = new _686DP_Idioma();

        private bool pagoRealizado = false;
        public _686DPfrmPagar(int codSiniestro, int nroPoliza, string descripcion, double valor, string evaluacion, string idi)
        {
            InitializeComponent();

            CodSiniestro = codSiniestro;
            NroPoliza = nroPoliza;
            Descripcion = descripcion;
            Valor = valor;
            EvaluacionSistema = evaluacion;

           
            txtCodSiniestro.Text = codSiniestro.ToString();
            txtNroPoliza.Text = nroPoliza.ToString();
            txtDescripcion.Text = descripcion;
            txtValor.Text ="$"+ valor.ToString();
            txtEvaluacion.Text = evaluacion;
            idioma = idi;
            registrarForm();
        }

        public _686DPfrmPagar()
        {
            InitializeComponent();
            this.FormClosing += _686DPfrmPagar_FormClosing;
        }

        private void _686DPfrmPagar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pagoRealizado) return;

            e.Cancel = true;

            var result = MessageBox.Show(
                LMG.Traducir("PagoRequerido"),
                LMG.Traducir("Requerido"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                try
                {
                    BTNPagar.PerformClick();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(LMG.Traducir("ErrorPago")+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
            }
        }



        private void _686DPfrmPagar_Load(object sender, EventArgs e)
        {
            LMG.CargarMensajesGlobales(idioma);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void BTNPagar_Click(object sender, EventArgs e)
        {
            blls.Pagar(CodSiniestro);
            Console.WriteLine(LMG.Traducir("PagoOk"));
            BLLDV.CalcularDigitoVerificador("Factura");
            this.Close();
        }

        private void registrarForm()
        {
            Form fi = this;
            LMG.RegistrarForm(fi);
            IdiomaClase.AgregarObsevador(LMG);
            IdiomaClase.CambiarIdioma(idioma);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
