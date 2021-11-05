using System;
using System.Collections.Generic;
using System.IO;
using iText.IO.Image;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Utilidades
{
    public static class UtilFormato
    {
        public static byte[] AgregarMetadata(byte[] documento, Dictionary<string, string> metadata)
        {
            using (var inStream = new MemoryStream(documento))
            using (var reader = new PdfReader(inStream))
            using (var outStream = new MemoryStream())
            using (var writer = new PdfWriter(outStream))
            using (var document = new PdfDocument(reader, writer))
            {
                var info = document.GetTrailer().GetAsDictionary(PdfName.Info);
                foreach (var property in metadata)
                {
                    info.Put(new PdfName(property.Key), new PdfString(property.Value));
                }
                document.Close();
                return outStream.ToArray();
            }
        }

        public static byte[] AgregarInfo(byte[] documento, string numeroDocumento, string oficina, string producto, string usuario, string ciudad, byte[] grafo = null)
        {
            using (var inStream = new MemoryStream(documento))
            using (var reader = new PdfReader(inStream))
            using (var outStream = new MemoryStream())
            using (var writer = new PdfWriter(outStream))
            using (var document = new PdfDocument(reader, writer))
            {
                Dictionary<string, string> Valores = new Dictionary<string, string>(){
                        { "Fecha:", DateTime.Now.ToString()},
                        { "Documento:", numeroDocumento },
                        { "Oficina:", oficina },
                        { "Producto:", producto},
                        { "Asesor:", usuario },
                        { "Ciudad:", ciudad }
                    };

                Table table = new Table(2);
                table.SetTextAlignment(TextAlignment.LEFT);
                table.SetWidth(200);
                table.SetFontSize(8);

                if(grafo != null && grafo.Length > 0)
                {
                    var imgGrafo = new Image(ImageDataFactory.Create(grafo),80,265,90);
                    table.AddCell(new Cell(1, 2).Add(imgGrafo).SetBorder(Border.NO_BORDER));
                }
                foreach (var valor in Valores)
                {
                    table.AddCell(new Cell().Add(new Paragraph(valor.Key)).SetBorder(Border.NO_BORDER));
                    table.AddCell(new Cell().Add(new Paragraph(valor.Value)).SetBorder(Border.NO_BORDER));
                }
                table.SetBorder(Border.NO_BORDER);

                var pageCount = document.GetNumberOfPages();
                for (var i = 1; i <= pageCount; i++)
                {
                    var page = document.GetPage(pageCount);
                    var pdfCanvas = new PdfCanvas(page);
                    var rectangle = new iText.Kernel.Geom.Rectangle(80, 150, 200, 150);
                    var canvas = new Canvas(pdfCanvas, rectangle);
                    canvas.Add(table);
                    canvas.Close();
                }

                document.Close();
                return outStream.ToArray();
            }
        }
    }
}
