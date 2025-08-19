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
    public partial class GestionDeRespaldo : Form
    {
        _686DP_BLLBackUpRestore _686DP_BLLBackUpRestore;
        public GestionDeRespaldo()
        {
            InitializeComponent();
            _686DP_BLLBackUpRestore = new _686DP_BLLBackUpRestore();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            { ElegirRuta(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ElegirRuta()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak"; 
                saveFileDialog.Title = "Guardar archivo de Backup";
                saveFileDialog.DefaultExt = "bak"; 
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = saveFileDialog.FileName;

                    try
                    {
                        _686DP_BLLBackUpRestore.RealizarBackupBD(rutaArchivo);
                        MessageBox.Show("Backup realizado exitosamente en: " + rutaArchivo);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al realizar el backup: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("No se seleccionó ninguna ubicación para guardar el archivo de backup.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { Restaurar(); }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Restaurar()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak";
                openFileDialog.Title = "Seleccionar archivo de backup";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivoBackup = openFileDialog.FileName; 
                    Console.WriteLine("Ruta seleccionada para restaurar: " + rutaArchivoBackup);

                    _686DP_BLLBackUpRestore.RealizarRestoreBD(rutaArchivoBackup);
                }
                else
                {
                    MessageBox.Show("No se seleccionó ningún archivo de backup.");
                }
            }
        }
    }
}
