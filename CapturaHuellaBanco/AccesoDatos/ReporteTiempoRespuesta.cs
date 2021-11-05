using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilidades;

namespace AccesoDatos
{
    public class ReporteTiempoRespuesta
    {
        static LogErrores error = null;
        static RegistrarLog registro = new RegistrarLog();

        private string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

        public void InsertarLogTiemposRespuesta(LogTiempoRespuesta LO)
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.InsertarLogsTiemposRespuesta", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Metodo", LO.Metodo);
                command.Parameters.AddWithValue("@Parametros", LO.Parametros);
                command.Parameters.AddWithValue("@Capa", LO.Capa);
                command.Parameters.AddWithValue("@FechaInicio", LO.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", LO.FechaFin);
                command.Parameters.AddWithValue("@Duracion", LO.Duracion);
                command.Parameters.AddWithValue("@Ip", LO.Ip);
                command.Parameters.AddWithValue("@Grupo", LO.Grupo);

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
                    error.Metodo = "ReporteTiempoRespuesta : InsertarLogTiemposRespuesta";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }
        }

        public List<LogTiempoRespuesta> ObtenerLogTiemposRespuesta(string fechaIngreso, string fechaFin)
        {
            LogTiempoRespuesta LI;
            List<LogTiempoRespuesta> LLI = new List<LogTiempoRespuesta>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerLogTiemposRespuesta", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new LogTiempoRespuesta();
                        LI.Metodo = reader["Metodo"].ToString();
                        LI.Parametros = reader["Parametros"].ToString();
                        LI.Capa = reader["Capa"].ToString();
                        LI.FechaInicio = Convert.ToDateTime(reader["FechaInicio"]);
                        LI.FechaFin = Convert.ToDateTime(reader["FechaFin"]);
                        LI.Duracion = reader["Duracion"].ToString();
                        LI.Ip = reader["Ip"].ToString();  
                        LI.Grupo = Guid.Parse(reader["Grupo"].ToString());  
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ReporteTiempoRespuesta : ObtenerLogTiemposRespuesta";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }
    }
}