using System;

namespace ContingenciaOperador.Switch
{
    /// <summary>
    /// Configuracion de operador activo en el switch de contingencia. 
    /// </summary>
    public class OperatorContingency
    {
        /// <summary>
        /// Tiempo en minutos configurado para consulta al switch.
        /// </summary>
        public string periodicity { get; set; }

        /// <summary>
        /// Operador activo en el switch de contingencia. 
        /// </summary>
        public OperatorActive operatorActive { get; set; }

        /// <summary>
        /// Fecha y hora de consulta.
        /// </summary>
        public DateTime dateOperation { get; set; }
    }
}
