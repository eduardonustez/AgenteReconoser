using System;

namespace ContingenciaOperador.Entidades
{
    public class DatosPeticionRS
    {
        public int IdCliente { get; set; }

        public Guid Convenio { get; set; }

        public string Asesor { get; set; }

        public string IdOficina { get; set; }

        public int IdProducto { get; set; }

        public string Tramite{ get; set; }
        
        public string TipoDocumento{ get; set; }

        public string Documento { get; set; }

        public string IP { get; set; }

        public string Mac { get; set; }

        public string Serial { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }
        
        public int TipoBiometrico { get; set; }

        public int IdServicio { get; set; }

        public Guid IdPeticion { get; set; }
    }
}
