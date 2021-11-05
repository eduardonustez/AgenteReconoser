using System;
using System.Collections.Generic;
using System.Drawing;

namespace Entidades
{
    public class LogOperaciones
    {
        public string Accion { get; set; }
        public string CodigoError { get; set; }
        public string DescripcionError { get; set; }
        public string Documento { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public List<HuellaAFI> HA { get; set; }
        public long? IdAutorizacion { get; set; }
        public string IdOficina { get; set; }
        public long IdOperacion { get; set; }
        public Guid? IdPeticion { get; set; }
        public int IdProducto { get; set; }
        public int IdServicio { get; set; }
        public int IdTipoDocumento { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string Nombre { get; set; }
        public string NombreDedo { get; set; }
        public string NombreServicio { get; set; }
        public int NumeroDedo { get; set; }
        public string PrimerApellido { get; set; }
        public string PrimerNombre { get; set; }
        public Bitmap Respuesta { get; set; }
        public string RespuestaAFI { get; set; }
        public string Rol { get; set; }
        public string SegundoApellido { get; set; }
        public string SegundoNombre { get; set; }
        public string Serial { get; set; }
        public string Sigla { get; set; }
        public string TipoDocumento { get; set; }
        public string UsuarioLogin { get; set; }
        public string Vigencia { get; set; }
        public string Zona { get; set; }
    }

    public class TransaccionesOficina
    {
        public int AprobadosField { get; set; }
        public int IdProducto { get; set; }
        public int NoAprobadosField { get; set; }
        public string OficinaField { get; set; }
        public string Producto { get; set; }
        public int ValorUnitarioField { get; set; }
    }
}