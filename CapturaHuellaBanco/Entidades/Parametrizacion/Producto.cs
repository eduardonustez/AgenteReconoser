namespace Entidades.Parametrizacion
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdProducto { get; set; }
        public int IdServicio { get; set; }
        public string Servicio { get; set; }
    }
}