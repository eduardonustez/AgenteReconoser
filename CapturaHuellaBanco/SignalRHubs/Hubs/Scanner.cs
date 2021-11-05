using Dispositivos.Implementaciones;
using Microsoft.AspNet.SignalR;
using System;

namespace SignalRHubs.Hubs
{
    public class Scanner : Hub
    {
        public void EnviarComando(OpcionesScanner opcionesScanner)
        {
            try
            {
                var documentoRecuperado = ConectorScanner.ScanWIA(opcionesScanner, CapturarExcepciones);
                Clients.All.documentMessage(documentoRecuperado);
            }
            catch (Exception e)
            {
                throw new HubException(e.Message);
            }
        }

        public void CapturarExcepciones(string mensaje)
        {
            Clients.All.excepcionCapturada(mensaje);
        }

        public void ObtenerScanners()
        {
            try
            {
                var dispositivosConectados = ConectorScanner.ObtenerDispositivosWIA(CapturarExcepciones);
                Clients.All.dispositivosConectados(dispositivosConectados);
            }
            catch (Exception e)
            {
                throw new HubException(e.Message);
            }
        }
    }
}
