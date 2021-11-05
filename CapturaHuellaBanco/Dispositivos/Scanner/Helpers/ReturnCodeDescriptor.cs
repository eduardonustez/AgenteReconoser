using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTwain.Data;

namespace Dispositivos.Scanner.Helpers
{
    public class ReturnCodeDescriptor
    {
        public static List<KeyValuePair<ReturnCode, string>> ReturnCodeDescriptorList { get; } = new List<KeyValuePair<ReturnCode, string>>() {
            new KeyValuePair<ReturnCode, string>(ReturnCode.Success, "Conexión exitosa"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.Failure, "Falló la conexión con el dispositivo. Verifique que el escáner se encuentre encendido y conectado"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.CheckStatus, "Operación parcialmente exitosa. Solicitar más información"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.Cancel, "Se canceló la operación. Vuelva a intentarlo"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.DSEvent, "El evento (o mensaje de Windows) pertenece a esta fuente"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.NotDSEvent, "El evento (o mensaje de Windows) no pertenece a esta fuente"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.XferDone, "Todos los datos han sido transferidos."),
            new KeyValuePair<ReturnCode, string>(ReturnCode.EndOfList, "No se han encontrado fuentes de escáner"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.InfoNotSupported, "La información no es compatible"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.DataNotAvailable, "Datos no disponibles"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.Busy, "El dispositivo se encuentra ocupado. Intente más tarde"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.ScannerLocked, "Otra aplicación está usando el escáner. Intente más tarde"),
            new KeyValuePair<ReturnCode, string>(ReturnCode.CustomBase, "Error general"),
        };
    }
}
