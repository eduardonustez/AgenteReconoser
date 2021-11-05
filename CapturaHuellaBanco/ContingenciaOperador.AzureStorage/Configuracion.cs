namespace ContingenciaOperador.AzureStorage
{
    public class Configuracion
    {

        public string CadenaDeConexionTablas { get; set; }
        public string Tabla { get; set; }
        public string CadenaDeConexionArchivos { get; set; }
        public string ContenedorArchivos { get; set; }
        public Configuracion Copia()
            => new Configuracion()
            {
                CadenaDeConexionArchivos = this.CadenaDeConexionArchivos,
                CadenaDeConexionTablas = this.CadenaDeConexionTablas,
                ContenedorArchivos = this.ContenedorArchivos,
                Tabla = this.Tabla
            };
      
    }
}
