using Entidades;
using Entidades.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades;

namespace AccesoDatos
{
    public class ParametrizacionDatos
    {
        static LogErrores error = null;
        static RegistrarLog registro = new RegistrarLog();

        private string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

        public List<Servicio> SeleccionarServicios()
        {
            List<Servicio> List = new List<Servicio>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Parametrizacion.SeleccionarServicios", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Servicio s = new Servicio();

                        s.IdServicio = (int)reader["IdServicio"];
                        s.Codigo = reader["NombreServicio"].ToString();

                        List.Add(s);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ParametrizacionDatos : SeleccionarServicios";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
                return List;
            }
        }

        public List<TipoDocumento> SeleccionarTipoDocumentos()
        {
            List<TipoDocumento> List = new List<TipoDocumento>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Parametrizacion.SeleccionarTipoDocumentos", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoDocumento t = new TipoDocumento();

                        t.IdTipoDocumento = (int)reader["IdTipoDocumento"];
                        t.NombreTipoDocumento = reader["NombreTipoDocumento"].ToString();
                        t.Sigla = reader["Sigla"].ToString();

                        List.Add(t);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {

                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ParametrizacionDatos : SeleccionarTipoDocumentos";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
                return List;
            }
        }

        public string ObtenerParametro(long IdSucursal, string ParametroNombre)
        {
            string ParametroValor = string.Empty;

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Parametrizacion.ObtenerParametro", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdSucursal", IdSucursal);
                command.Parameters.AddWithValue("@ParametroNombre", ParametroNombre);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ParametroValor = reader["ParametroValor"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ParametrizacionDatos : ObtenerParametro";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
                return ParametroValor;
            }
        }
    }
}