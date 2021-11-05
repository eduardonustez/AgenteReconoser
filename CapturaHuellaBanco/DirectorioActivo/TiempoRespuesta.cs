using System;

namespace Utilidades
{
    public class TiempoRespuesta
    {
        public string ObtenerTiempo(DateTime Fechainicion, DateTime FechaFin)
        {
            try
            {
                var tiempo = Fechainicion.Subtract(FechaFin).ToString("hh\\:mm\\:ss\\.fff");

                return tiempo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}