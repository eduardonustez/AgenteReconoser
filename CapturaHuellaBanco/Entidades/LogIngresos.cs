using System;
using System.Drawing;

namespace Entidades
{
    public class LogIngresos
    {
        public bool Exitoso { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaFin { get; set; }
        public long IdSucursal { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string NombreSucursal { get; set; }
        public string UsuarioLogin { get; set; }
    }

    public class NewLogIngresos
    {
        public Bitmap Exitoso { get; set; }
        public string Exitoso2 { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? FechaFin { get; set; }
        public string IdOficina { get; set; }
        public long IdSucursal { get; set; }
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string NombreSucursal { get; set; }
        public string UsuarioLogin { get; set; }
    }
}