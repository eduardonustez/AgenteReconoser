namespace Entidades
{
    public class FormatoProteccion
    {
        public bool Aceptacion { get; set; }
        public byte[] DocumentoAutorizacion { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public string IdOficina { get; set; }
        public string IpTerminal { get; set; }
        public string Login { get; set; }
        public string NumeroDocumento { get; set; }
        public string Producto { get; set; }
        public string Sigla { get; set; }
    }
}