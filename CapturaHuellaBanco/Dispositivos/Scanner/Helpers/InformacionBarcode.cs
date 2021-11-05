using Dispositivos.Scanner.Helpers;
using Dispositivos.Scanner.Models;
using NTwain;
using NTwain.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Dispositivos.Implementaciones
{
    public static class InformacionBarcode
    {
        public static int TipoDocumentoSeleccionado { get; set; }

        private static DatosPersonaDocumento ExtraccionMetaDataTI(string MetaData)
        {
            DatosPersonaDocumento datosCedula = new DatosPersonaDocumento();

            datosCedula.Cedula = long.Parse(MetaData.Substring(48, 11).Trim());

            string NombreCompleto = MetaData.Substring(59, 92).ToString().ToUpper();
            datosCedula.PrimerNombre = NombreCompleto.Substring(0, 23).Trim().ToUpper();
            datosCedula.SegundoApellido = NombreCompleto.Substring(23, 23).Trim().ToUpper();
            datosCedula.PrimerNombre = NombreCompleto.Substring(46, 23).Trim().ToUpper();
            datosCedula.SegundoNombre = NombreCompleto.Substring(69, 23).Trim().ToUpper();

            datosCedula.Genero = MetaData.Substring(152, 1).Trim().ToUpper();
            datosCedula.FechaExpedicion = Convert.ToDateTime(MetaData.Substring(153, 8).Substring(0, 4).Trim().ToUpper() +
                                                "/" + MetaData.Substring(153, 8).Substring(4, 2).Trim().ToUpper() +
                                                "/" + MetaData.Substring(153, 8).Substring(6, 2));
            datosCedula.FechaNacimiento = Convert.ToDateTime(MetaData.Substring(153, 8).Substring(0, 4).Trim().ToUpper() +
                                                "/" + MetaData.Substring(153, 8).Substring(4, 2).Trim().ToUpper() +
                                                "/" + MetaData.Substring(153, 8).Substring(6, 2));
            datosCedula.RH = MetaData.Substring(167, 3).Trim().ToUpper();
            return datosCedula;
        }

        private static DatosPersonaDocumento ExtraccionMetaDataCedula(string MetaData)
        {
            DatosPersonaDocumento datosCedula = new DatosPersonaDocumento();
            datosCedula.Cedula = Convert.ToInt64(MetaData.Substring(48, 10).Trim());

            string NombreCompleto = MetaData.Substring(58, 92).ToString();
            datosCedula.PrimerApellido = NombreCompleto.Substring(0, 23).Trim().ToUpper();
            datosCedula.SegundoApellido = NombreCompleto.Substring(23, 23).Trim().ToUpper();
            datosCedula.PrimerNombre = NombreCompleto.Substring(46, 23).Trim().ToUpper();
            datosCedula.SegundoNombre = NombreCompleto.Substring(69, 23).Trim().ToUpper();
            datosCedula.Genero = MetaData.Substring(151, 1).Trim().ToUpper();
            datosCedula.FechaExpedicion = Convert.ToDateTime(MetaData.Substring(152, 8).Substring(0, 4).Trim().ToUpper() +
                                              "-" + MetaData.Substring(152, 8).Substring(4, 2).Trim().ToUpper() +
                                              "-" + MetaData.Substring(152, 8).Substring(6, 2).Trim().ToUpper());
            datosCedula.FechaNacimiento = Convert.ToDateTime(MetaData.Substring(152, 8).Substring(0, 4).Trim().ToUpper() +
                                              "/" + MetaData.Substring(152, 8).Substring(4, 2).Trim().ToUpper() +
                                              "/" + MetaData.Substring(152, 8).Substring(6, 2));
            datosCedula.RH = MetaData.Substring(166, 3).Trim().ToUpper();
            return datosCedula;
        }

        public static DatosPersonaDocumento ObtenerInformacionBarcode(Image img, Action<string> action)
        {
            try
            {
                ZXing.IBarcodeReader reader = new ZXing.BarcodeReader();
                var barcodeBitmap = (Bitmap)img;
                var result = reader.Decode(barcodeBitmap);

                if (result != null)
                {
                    string MetaData = result.Text.Replace('\0', ' ');
                    DatosPersonaDocumento datosPersona = null;
                    if (TipoDocumentoSeleccionado == (int)TiposDocumento.Cedula)
                    {
                        datosPersona = ExtraccionMetaDataCedula(MetaData);
                    }
                    else if (TipoDocumentoSeleccionado == (int)TiposDocumento.TarjetaIdentidad)
                    {
                        datosPersona = ExtraccionMetaDataTI(MetaData);
                    } else
                    {
                        action.Invoke("El tipo de documento no está integrado. Solo se admite Cédula o Tarjeta de Identidad");
                    }
                    return datosPersona;
                }
                else
                {
                    action.Invoke("No se encontró información en el barcode del documento");
                    return null;
                }
            }
            catch
            {
                action.Invoke("No se obtuvo información desde el barcode del documento. Por favor, intente nuevamente.");
                return null;
            }
        }
    }
}
