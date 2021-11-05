using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace ContingenciaOperador.Switch
{
#if DEBUG
    /// <summary>
    /// Implementa las operaciones disponibles contra el switch de contingencia. 
    /// </summary>
    /// <remarks>Modo DUMMY</remarks>
    public class SwitchContingenciaDummy : ISwitchContingencia
    {
        /// <summary>
        /// Tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        public int IntervaloConsultaSwitch
        {
            get { return SwitchContingenciaDummy.switch_periodicity_in_seconds; }
        }

        /// <summary>
        /// Mantiene el tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        static int periodicity;

        /// <summary>
        /// Mantiene el tiempo en segundos en los que se vuelve a consultar directamente al Switch. 
        /// </summary>
        static int switch_periodicity_in_seconds
        {
            get { return SwitchContingenciaDummy.periodicity; }
            set
            {
                if (value > 0)
                {
                    SwitchContingenciaDummy.periodicity = value;
                }
            }
        }

        /// <summary>
        /// Mantiene el operador activo definido en el archivo dummy. 
        /// </summary>
        private static OperatorContingency OperatorContingency { get; set; }

        #region "Constructores"
        
        private void ReadFile()
        {
            try
            {
                string jsonString = string.Empty;                
                if (File.Exists(Path.Combine(AppContext.BaseDirectory, @"OperatorContingency.json")))
                {
                    jsonString = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, @"OperatorContingency.json"));
                    SwitchContingenciaDummy.OperatorContingency = JsonConvert.DeserializeObject<OperatorContingency>(jsonString);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {nameof(SwitchContingenciaDummy)}.{nameof(SwitchContingencia)} {ex.ToString()}");
            }
        }

        #endregion "Constructores"

        /// <summary>
        /// Obtiene y retorna el consumo del switch para determinar el operador activo actualmente. 
        /// </summary>
        public OperatorContingency ObtenerOperadorContingencia()
        {
            ReadFile();
            return SwitchContingenciaDummy.OperatorContingency;
        }
    }
#endif
}
