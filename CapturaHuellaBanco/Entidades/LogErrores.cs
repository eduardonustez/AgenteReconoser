using System;
using System.Reflection;

namespace Entidades
{
    public class LogErrores
    {
        private string _capa;

        public LogErrores()
        {
            _capa = $"Servicio Notarias: {Assembly.GetEntryAssembly().GetName().Version}";
        }

        public string Capa { get { return _capa; } }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string IdOficina { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string Metodo { get; set; }
        public string UsuarioLogin { get; set; }
    }

    public class LogHallazgoBiometrico
    {
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string IdOficina { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string Metodo { get; set; }
        public string UsuarioLogin { get; set; }
    }

    public class NewLogErrores
    {
        public string Capa { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string UsuarioLogin { get; set; }
    }
}