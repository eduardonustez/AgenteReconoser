namespace ContingenciaOperador.Switch
{
    /// <summary>
    /// Operador activo en el switch de contingencia. 
    /// </summary>
    public class OperatorActive
    {
        /// <summary>
        /// Código único del operador.
        /// </summary>
        public string idOperator { get; set; }

        /// <summary>
        /// Nombre del operador. 
        /// </summary>
        public string operatorName { get; set; }

        /// <summary>
        /// Url de la TSA del operador.
        /// </summary>
        public string tsa { get; set; }

        /// <summary>
        /// Indicador del operador activo(0 inactivo, 1 activo).
        /// </summary>
        public string active { get; set; }

        /// <summary>
        /// Fecha de última activación.
        /// </summary>
        public string lastDateChange { get; set; }
    }
}
