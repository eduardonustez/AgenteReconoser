using System;
using System.Windows.Forms;
using Utilidades;
using Entidades;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapturaHuellaBanco.ControlesWF
{
    public partial class ctrlReporteTiemposRespuesta : UserControl
    {
        frmBase _Base;

        TimeSpan aTiempo = new TimeSpan(0, 0, 0, 0, 30);
        TimeSpan fuera = new TimeSpan(0, 0, 0, 0, 31);
        List<LogTiempoRespuesta> dataTiempos = new List<LogTiempoRespuesta>();
        Banco.ServicioBanco sb = new Banco.ServicioBanco();

        static LogErrores error = null;


        private void ctrlReporteTiemposRespuesta_Load(object sender, EventArgs e)
        {
            try
            {
                _Base = (frmBase)this.ParentForm;
                _Base.Titulo = "REPORTE TIEMPOS DE RESPUESTA";
                _Base.MostrarIconoDashboard();
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteTiemposRespuesta : ctrlReporteTiemposRespuesta_Load";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }

        }

        public ctrlReporteTiemposRespuesta()
        {
            try
            {
                InitializeComponent();

                dtpFechaIngreso.Value = DateTime.Now;
                dtpFechaFinal.Value = DateTime.Now;
                dgvReporteTiemposRespuesta.ReadOnly = true;
                dgvReporteTiemposRespuesta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                string fechaInicio = dtpFechaIngreso.Value.Date.ToString("yyyy/MM/dd");
                fechaInicio = fechaInicio + " 00:00:00.000";

                string fechaFin = dtpFechaFinal.Value.Date.ToString("yyyy/MM/dd");
                fechaFin = fechaFin + " 23:59:59.999";

                dataTiempos = sb.ObtenerTiemposRespuesta(fechaInicio, fechaFin);


                dgvReporteTiemposRespuesta.DataSource = dataTiempos;

                dgvReporteTiemposRespuesta.Columns["Parametros"].Visible = false;
                dgvReporteTiemposRespuesta.Columns["Grupo"].Visible = false;
                dgvReporteTiemposRespuesta.Columns["Ip"].Visible = false;
                dgvReporteTiemposRespuesta.Columns["FechaFin"].Visible = false;

                lblCantidadRegistros.Text = "N° registros: " + dgvReporteTiemposRespuesta.RowCount.ToString();

                if (dgvReporteTiemposRespuesta.RowCount == 0)
                    BtnExportar.Enabled = false;
                else
                    BtnExportar.Enabled = true;

            }
            catch (Exception ex)
            {

                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteTiemposRespuesta : ctrlReporteTiemposRespuesta";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {

            string path = ConfigurationManager.AppSettings["Archivos"];
            string rutaImagenes = ConfigurationManager.AppSettings["Imagenes"];

            if (Directory.Exists(path))
            {
            }
            else
            {
                Directory.CreateDirectory(path);
            }

            string fullpath = path + "\\Archivo.pdf";


            Stream logoReconoser = new FileStream(rutaImagenes + "\\logo-reconocer.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            Stream logoColpatria = new FileStream(rutaImagenes + "\\logo-colpatria.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            Stream logoPersona = new FileStream(rutaImagenes + "\\logo-persona.png", FileMode.Open, FileAccess.Read, FileShare.Read);
            Stream logoOlimpia = new FileStream(rutaImagenes + "\\LogoOlimpia.png", FileMode.Open, FileAccess.Read, FileShare.Read);

            FileStream fs = new FileStream(fullpath, FileMode.Create, FileAccess.ReadWrite);

            Document doc = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            doc.Open();


            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            iTextSharp.text.Font _standardFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC, BaseColor.DARK_GRAY);


            iTextSharp.text.Font _standardFont3 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            iTextSharp.text.Paragraph saltoLinea = new iTextSharp.text.Paragraph("\n\n");

            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(logoColpatria);
            image.SetAbsolutePosition(30, 635);
            image.ScaleAbsolute(125f, 48f);
            doc.Add(image);

            iTextSharp.text.Image image2 = iTextSharp.text.Image.GetInstance(logoReconoser);
            image2.SetAbsolutePosition(444, 732);
            image2.ScaleAbsolute(133f, 48f);
            doc.Add(image2);


            iTextSharp.text.Image image3 = iTextSharp.text.Image.GetInstance(logoPersona);
            image3.ScalePercent(200, 200);

            iTextSharp.text.Image image4 = iTextSharp.text.Image.GetInstance(logoOlimpia);
            image4.SetAbsolutePosition(444, 20);
            image4.ScaleAbsolute(133f, 48f);
            doc.Add(image4);

            Paragraph p = new Paragraph();
            Phrase frase = new Phrase();

            Chunk texto = new Chunk("COMPROBANTE DE VALIDACIÓN DE IDENTIDAD", _standardFont);
            frase.Add(texto);
            p.Alignment = Element.ALIGN_LEFT;
            p.Add(frase);
            doc.Add(p);

            Paragraph pl = new Paragraph();
            Phrase frasel = new Phrase();

            Chunk textol = new Chunk("_________________________________________________________________________________________________", _standardFont3);
            frasel.Add(textol);
            pl.Alignment = Element.ALIGN_JUSTIFIED;
            pl.Add(frasel);
            doc.Add(pl);

            doc.Add(saltoLinea);
            doc.Add(saltoLinea);
            doc.Add(saltoLinea);
            doc.Add(saltoLinea);
            doc.Add(saltoLinea);

            Paragraph p2 = new Paragraph();
            Phrase frase2 = new Phrase();

            Chunk texto2 = new Chunk("Olimpia, líderes en seguridad Biométrica, a través de la consulta a la Registraduría Nacional Del Estado Civil, certifica al ciudadano número de identificación <<DOCUMENTO>> como <<PRIMER NOMBRE ANI>> <<SEGUNDO NOMBRE ANI>> <<PARTICULA ANI>> <<PRIMER APELLIDO ANI>> <<SEGUNDO APELLIDO ANI>> con fecha de expedición <<FECHA EXPEDICION ANI>> de <<LUGAR DE EXPEDICION ANI>> con en estado de documento: <<ESTADO>>. Su identidad fue verificada a través los dedos <<DEDO 1 CAPTURADO>> y <<DEDO 2 CAPTURADO>> La presente certificación, es de carácter informativo y es expedida en <<FECHAACTUAL DE ENTIDAD CERTIFICADORA>>", _standardFont);

            frase2.Add(texto2);
            p2.Alignment = Element.ALIGN_JUSTIFIED;
            p2.Add(frase2);

            PdfPTable tblPrueba = new PdfPTable(4);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla      

            PdfPCell clImagen = new PdfPCell(image3);
            clImagen.Colspan = 1;
            clImagen.BorderWidth = 0;
            clImagen.HorizontalAlignment = 1;

            PdfPCell clDetalle = new PdfPCell(p2);
            clDetalle.BorderWidth = 0;
            clDetalle.Colspan = 3;
            clDetalle.Column.Alignment = Element.ALIGN_JUSTIFIED;

            // Añadimos las celdas a la tabla 
            tblPrueba.AddCell(clImagen);
            tblPrueba.AddCell(clDetalle);

            doc.Add(tblPrueba);

            doc.Add(saltoLinea);
            doc.Add(saltoLinea);

            Paragraph p3 = new Paragraph();
            Phrase frase3 = new Phrase();

            Chunk texto3 = new Chunk("La presente certificación, es de carácter informativo y es expedida en <<FECHAACTUAL DE ENTIDAD CERTIFICADORA>>", _standardFont);

            frase3.Add(texto3);
            p3.Alignment = Element.ALIGN_LEFT;
            p3.Add(frase3);
            doc.Add(p3);

            doc.Add(saltoLinea);
            doc.Add(saltoLinea);
            doc.Add(saltoLinea);

            Paragraph p4 = new Paragraph();
            Phrase frase4 = new Phrase();

            Chunk texto4 = new Chunk("Atentamente,", _standardFont2);

            frase4.Add(texto4);
            p4.Alignment = Element.ALIGN_LEFT;
            p4.Add(frase4);
            doc.Add(p4);

            doc.Add(saltoLinea);

            Paragraph pl2 = new Paragraph();
            Phrase frasel2 = new Phrase();
            Chunk textol2 = new Chunk("                                                                                                 ", _standardFont3);
            frasel2.Add(textol2);
            pl2.Alignment = Element.ALIGN_JUSTIFIED;
            pl2.Add(frasel2);
            doc.Add(pl2);
            doc.Add(pl2);
            doc.Add(pl2);
            doc.Add(pl2);
            doc.Add(pl2);
            doc.Add(pl2);
            doc.Add(pl);


            Paragraph p6 = new Paragraph();
            Phrase frase6 = new Phrase();

            Chunk texto6 = new Chunk("Trabajando por un país más seguro, www.olimpiait.com", _standardFont2);

            frase6.Add(texto6);
            p6.Alignment = Element.ALIGN_LEFT;
            p6.Add(frase6);
            doc.Add(p6);

            doc.Close();
            writer.Close();
            // string newFullPath = DigitaSignature(fullpath);

            //if (newFullPath == "")
            //{
            //    return fullpath;
            //}
            //else
            //{
            //    File.Delete(fullpath);
            //    return newFullPath;
            //}
        }

        private void BtnBuscar_EventoClick(object sender, EventArgs e)
        {
            try
            {

                if (dtpFechaIngreso.Text != null)
                {

                    string fechaInicio = dtpFechaIngreso.Value.Date.ToString("yyyy/MM/dd");
                    fechaInicio = fechaInicio + " 00:00:00.000";

                    string fechaFin = dtpFechaFinal.Value.Date.ToString("yyyy/MM/dd");
                    fechaFin = fechaFin + " 23:59:59.999";

                    DateTime ini = Convert.ToDateTime(fechaInicio);
                    DateTime fn = Convert.ToDateTime(fechaFin);

                    if (ini > fn)
                    {
                        dtpFechaIngreso.Value = dtpFechaFinal.Value;
                        MessageBox.Show("La fecha de inicio no debe ser mayor a la fecha final", "Rango de fechas incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        dataTiempos.Clear();
                        dataTiempos = sb.ObtenerTiemposRespuesta(fechaInicio, fechaFin);
                        dgvReporteTiemposRespuesta.DataSource = dataTiempos;
                        lblCantidadRegistros.Text = "N° registros: " + dgvReporteTiemposRespuesta.RowCount.ToString();

                        if (dgvReporteTiemposRespuesta.RowCount == 0)
                            BtnExportar.Enabled = false;
                        else
                            BtnExportar.Enabled = true;
                    }


                }
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteTiemposRespuesta : BtnBuscar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }

        private void BtnExportar_EventoClick(object sender, EventArgs e)
        {
            try
            {
                frmBase _Base = (frmBase)this.ParentForm;
                _Base.ExportarExcel(dgvReporteTiemposRespuesta);
            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteTiemposRespuesta : BtnExportar_EventoClick";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }


        private void dgvReporteTiemposRespuesta_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                LblMetodo.Text = row.Cells["Metodo"].Value.ToString();
                LblCapa.Text = row.Cells["Capa"].Value.ToString();
                LblFecha.Text = row.Cells["FechaInicio"].Value.ToString();
                LblDuracion.Text = row.Cells["Duracion"].Value.ToString();

            }
            catch (Exception ex)
            {
                error = new LogErrores();
                error.UsuarioLogin = _Base.Usuario;
                error.Capa = "CapturaHuellaBanco";
                error.Metodo = "ctrlReporteTiemposRespuesta : dgvReporteTiemposRespuesta_RowEnter";
                error.Fecha = DateTime.Now;
                error.Descripcion = ex.Message;
                sb.InsertarLogError(error);
                throw;
            }
        }




    }
}
