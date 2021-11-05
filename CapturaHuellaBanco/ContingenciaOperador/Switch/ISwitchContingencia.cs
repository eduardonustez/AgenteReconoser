namespace ContingenciaOperador.Switch
{
    /// <summary>
    /// Abstrae las operaciones disponibles contra el switch de contingencia. 
    /// </summary>
    public interface ISwitchContingencia
    {
        /// <summary>
        /// Tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        int IntervaloConsultaSwitch { get; }

        /// <summary>
        /// Obtiene y retorna el consumo del switch para determinar el operador activo actualmente. 
        /// </summary>
        OperatorContingency ObtenerOperadorContingencia();
    }
}
