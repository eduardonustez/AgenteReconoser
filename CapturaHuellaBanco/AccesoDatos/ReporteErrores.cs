using Entidades;
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
    public class ReporteErrores
    {
        static LogErrores error = null;
        static RegistrarLog registro = new RegistrarLog();

        private string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

        public void InsertarLogErrores(LogErrores LO)
        {

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.InsertarLogErrores", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UsuarioLogin", LO.UsuarioLogin);
                command.Parameters.AddWithValue("@Capa", LO.Capa);
                command.Parameters.AddWithValue("@Metodo", LO.Metodo);
                command.Parameters.AddWithValue("@Fecha", LO.Fecha);
                command.Parameters.AddWithValue("@Descripcion", LO.Descripcion);
                command.Parameters.AddWithValue("@IP", LO.Ip);
                command.Parameters.AddWithValue("@MAC", LO.Mac);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ReporteErrores : InsertarLogErrores";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }
        }

        public List<LogErrores> ObtenerLogErrores(string fechaIngreso, string fechaFin, string usuario)
        {
            LogErrores LI;
            List<LogErrores> LLI = new List<LogErrores>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerLogErrores", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new LogErrores();
                        LI.UsuarioLogin = reader["UsuarioLogin"].ToString();
                        LI.Capa = reader["Capa"].ToString();
                        LI.Metodo = reader["Metodo"].ToString();
                        LI.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        LI.Descripcion = reader["Descripcion"].ToString();
                        LI.Ip = reader["IP"].ToString();
                        LI.Mac = reader["MAC"].ToString();
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ReporteErrores : ObtenerLogErrores";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }
    }
}