using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Autenticacion
{
    public class Solicitud
    {
        [Display(Name = "Asesor")]
        [Required]
        [StringLength(100, ErrorMessage = "El número de carácteres es demasiado largo")]
        public string Asesor { get; set; }

        [Display(Name = "Estado")]
        public int Estado { get; set; }

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "No. de Solicitud")]
        public int IdSolicitudes { get; set; }
        [Display(Name = "Estación")]
        public string Maquina { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Número de Identidad")]
        [Required]
        [StringLength(100, ErrorMessage = "El número de carácteres es demasiado largo")]
        public string NumeroIdentidad { get; set; }

        [Display(Name = "Servicio")]
        [Required]
        [StringLength(100, ErrorMessage = "El número de carácteres es demasiado largo")]
        public string Servicio { get; set; }

        [Display(Name = "Tipo de Identidad")]
        [Required]
        [StringLength(100, ErrorMessage = "El número de carácteres es demasiado largo")]
        public string TipoIdentidad { get; set; }
        [Display(Name = "Usuario Aprobado")]
        public bool UsuarioAprobado { get; set; }
    }
}