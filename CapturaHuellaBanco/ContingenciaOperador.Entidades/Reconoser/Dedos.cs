using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContingenciaOperador.Entidades.Reconoser
{
    public enum Dedos
    {
        [Display(Name = nameof(Recursos.PulgarDerecho), ResourceType = typeof(Recursos))]
        [Description("Pulgar Derecho")]
        PulgarDerecho = 1,
        [Display(Name = nameof(Recursos.IndiceDerecho), ResourceType = typeof(Recursos))]
        [Description("Indice Derecho")]
        IndiceDerecho = 2,
        [Display(Name = nameof(Recursos.MedioDerecho), ResourceType = typeof(Recursos))]
        [Description("Medio Derecho")]
        MedioDerecho = 3,
        [Display(Name = nameof(Recursos.AnularDerecho), ResourceType = typeof(Recursos))]
        [Description("Anular Derecho")]
        AnularDerecho = 4,
        [Display(Name = nameof(Recursos.MeniqueDerecho), ResourceType = typeof(Recursos))]
        [Description("Menique Derecho")]
        MeniqueDerecho = 5,
        [Display(Name = nameof(Recursos.PulgarIzquierdo), ResourceType = typeof(Recursos))]
        [Description("Pulgar Izquierdo")]
        PulgarIzquierdo = 6,
        [Display(Name = nameof(Recursos.IndiceIzquierdo), ResourceType = typeof(Recursos))]
        [Description("Indice Izquierdo")]
        IndiceIzquierdo = 7,
        [Display(Name = nameof(Recursos.MedioIzquierdo), ResourceType = typeof(Recursos))]
        [Description("Medio Izquierdo")]
        MedioIzquierdo = 8,
        [Display(Name = nameof(Recursos.AnularIzquierdo), ResourceType = typeof(Recursos))]
        [Description("Anular Izquierdo")]
        AnularIzquierdo = 9,
        [Display(Name = nameof(Recursos.MeniqueIzquierdo), ResourceType = typeof(Recursos))]
        [Description("Menique Izquierdo")]
        MeniqueIzquierdo = 10
    }
}
