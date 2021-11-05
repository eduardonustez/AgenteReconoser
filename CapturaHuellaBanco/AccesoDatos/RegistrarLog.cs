using Entidades;
using System;
using Utilidades;

namespace AccesoDatos
{
    public class RegistrarLog
    {
        
        public void InsertarLogError(LogErrores error)
        {
            try
            {
                ObtenerIP ObtenerIp = new ObtenerIP();
                ObtenerMac MyMac = new ObtenerMac();

                InsertarError(error.UsuarioLogin, error.Capa, error.Metodo, error.Fecha, error.Descripcion, ObtenerIp.GetIP(), MyMac.GetMac());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
          
        }


        public LogErrores InsertarError(string usuarioLogin, string capa, string metodo, DateTime fecha, string descripcion, string ip, string mac)
        {
            LogErrores LI = new LogErrores();
            LI.UsuarioLogin = usuarioLogin;
            LI.Capa = capa;
            LI.Metodo = metodo;
            LI.Fecha = fecha;
            LI.Descripcion = descripcion;
            LI.Ip = ip;
            LI.Mac = mac;

            ReporteErrores reporte = new ReporteErrores();
            reporte.InsertarLogErrores(LI);
            return LI;
        }
    }
}
