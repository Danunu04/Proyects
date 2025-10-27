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
                string T(string key)
                    => string.IsNullOrWhiteSpace(key) ? string.Empty
                       : (LMG?.Traducir(key) ?? key);

                if (nombre == null) nombre = string.Empty;
                if (apellido == null) apellido = string.Empty;
                if (domicilio == null) domicilio = string.Empty;
                if (email == null) email = string.Empty;

                string seguroTexto = string.IsNullOrWhiteSpace(seguro) ? T("SeguroNoInformado") : T(seguro);

                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                string path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Poliza_{(apellido ?? "SinApellido")}_{dni}.pdf");

                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20, BaseColor.BLUE);
                var subTitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);

                var titulo = new Paragraph("Asegura YA", titleFont) { Alignment = Element.ALIGN_CENTER, SpacingAfter = 20 };
                doc.Add(titulo);

                doc.Add(new Paragraph($"{T("Asegurado")}: {nombre} {apellido}", normalFont));
                doc.Add(new Paragraph($"DNI: {dni}", normalFont));
                doc.Add(new Paragraph($"{T("NumeroPoliza")}: {numeroPoliza}", normalFont));
                doc.Add(new Paragraph($"{T("Domicilio")}: {domicilio}", normalFont));
                doc.Add(new Paragraph($"{T("Email")}: {email}", normalFont));
                doc.Add(new Paragraph($"{T("SeguroContratado")}: {seguroTexto}", normalFont));
                doc.Add(new Paragraph($"{T("Prima")}: ${prima:N2}", normalFont));
                doc.Add(new Paragraph($"{T("FechaEmision")}: {DateTime.Now:dd/MM/yyyy}", normalFont));
                doc.Add(new Paragraph(" "));

                if (coberturas != null && coberturas.Count > 0)
                {
                    var subtitulo = new Paragraph(T("CoberturasIncluidas"), subTitleFont) { SpacingAfter = 10 };
                    doc.Add(subtitulo);

                    PdfPTable table = new PdfPTable(2) { WidthPercentage = 100 };
                    table.SetWidths(new float[] { 2f, 1f });

                    var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                    var headerBg = new BaseColor(0, 102, 204);
                    var cellBg = new BaseColor(245, 245, 245);

                    var h1 = new PdfPCell(new Phrase(T("Cobertura"), headerFont)) { BackgroundColor = headerBg, Padding = 5 };
                    var h2 = new PdfPCell(new Phrase(T("SumaAsegurada"), headerFont)) { BackgroundColor = headerBg, Padding = 5 };
                    table.AddCell(h1); table.AddCell(h2);

                    foreach (var c in coberturas)
                    {
                        string descripcion = T(c?.DP686_Descripcion ?? "SinDescripcion");
                        decimal sumaDec = c?.DP686_SumaAsegurada ?? 0m;

                        var cell1 = new PdfPCell(new Phrase(descripcion, normalFont)) { BackgroundColor = cellBg, Padding = 5 };
                        var cell2 = new PdfPCell(new Phrase($"${sumaDec:N2}", normalFont)) { BackgroundColor = cellBg, Padding = 5 };
                        table.AddCell(cell1); table.AddCell(cell2);
                    }

                    doc.Add(table);
                }
                else
                {
                    doc.Add(new Paragraph(T("SinCoberturas"), normalFont));
                }

                doc.Add(new Paragraph("\n" + T("LeyendaPoliza"), normalFont));
                doc.Close();

                MessageBox.Show(T("PolizaGeneradaOK") + $"\n{path}", T("TituloPDFGenerado"));
                System.Diagnostics.Process.Start(path);
            }
            catch (ArgumentNullException ane) when (ane.ParamName == "key")
            {
                MessageBox.Show("Error al generar PDF: se intentó traducir con una clave nula (seguro o descripción).", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error");
            }
        }


    }
}
