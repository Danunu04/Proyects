using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _686DP_BE;
using _686DP_SERVICIOS.Observer;
using System.Numerics;

namespace AseguraYa
{
    public class _686DP_GeneradorDePolizas
    {
        public static void GenerarPolizaBasica(
    string nombre, string apellido, int dni, string domicilio, string email,
    string seguro, decimal prima, List<_686DP_Cobertura> coberturas,
    string idioma, _686DP_LanguajeManager LMG, int numeroPoliza)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Poliza_{apellido}_{dni}.pdf");
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLUE);
                var subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                Paragraph titulo = new Paragraph("Asegura YA", titleFont);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 20;
                doc.Add(titulo);

                doc.Add(new Paragraph($"{LMG.Traducir("Asegurado")}: {nombre} {apellido}", normalFont));
                doc.Add(new Paragraph($"DNI: {dni}", normalFont));
                doc.Add(new Paragraph($"{LMG.Traducir("NumeroPoliza")}: {numeroPoliza.ToString()}", normalFont));
                doc.Add(new Paragraph($"{LMG.Traducir("Domicilio")}: {domicilio}", normalFont));
                doc.Add(new Paragraph($"{LMG.Traducir("Email")}: {email}", normalFont));
                doc.Add(new Paragraph($"{LMG.Traducir("SeguroContratado")}: {LMG.Traducir(seguro)}", normalFont));
                doc.Add(new Paragraph($"{LMG.Traducir("Prima")}: ${prima:N2}", normalFont));
                doc.Add(new Paragraph($"{LMG.Traducir("FechaEmision")}: {DateTime.Now:dd/MM/yyyy}", normalFont));
                doc.Add(new Paragraph(" "));

                if (coberturas != null && coberturas.Count > 0)
                {
                    Paragraph subtitulo = new Paragraph(LMG.Traducir("CoberturasIncluidas"), subTitleFont);
                    subtitulo.SpacingAfter = 10;
                    doc.Add(subtitulo);

                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 2f, 1f });

                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    var headerBgColor = new BaseColor(0, 102, 204); 
                    var cellBgColor = new BaseColor(245, 245, 245);

                    PdfPCell h1 = new PdfPCell(new Phrase(LMG.Traducir("Cobertura"), headerFont));
                    h1.BackgroundColor = headerBgColor;
                    h1.Padding = 5;
                    PdfPCell h2 = new PdfPCell(new Phrase(LMG.Traducir("SumaAsegurada"), headerFont));
                    h2.BackgroundColor = headerBgColor;
                    h2.Padding = 5;

                    table.AddCell(h1);
                    table.AddCell(h2);

                    foreach (var c in coberturas)
                    {
                        string descripcion = LMG.Traducir(c.DP686_Descripcion ?? "SinDescripcion");
                        string suma = $"${c.DP686_SumaAsegurada:N2}";

                        PdfPCell cell1 = new PdfPCell(new Phrase(descripcion, normalFont));
                        cell1.BackgroundColor = cellBgColor;
                        cell1.Padding = 5;
                        PdfPCell cell2 = new PdfPCell(new Phrase(suma, normalFont));
                        cell2.BackgroundColor = cellBgColor;
                        cell2.Padding = 5;

                        table.AddCell(cell1);
                        table.AddCell(cell2);
                    }

                    doc.Add(table);
                }
                else
                {
                    doc.Add(new Paragraph(LMG.Traducir("SinCoberturas"), normalFont));
                }

                doc.Add(new Paragraph("\n" + LMG.Traducir("LeyendaPoliza"), normalFont));
                doc.Close();

                MessageBox.Show(LMG.Traducir("PolizaGeneradaOK") + $"\n{path}", LMG.Traducir("TituloPDFGenerado"));
                System.Diagnostics.Process.Start(path); // Abre el PDF automáticamente
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error");
            }
        }

    }
}
