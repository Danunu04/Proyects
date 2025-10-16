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
            Console.WriteLine("PagoOk");
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
    }
}
