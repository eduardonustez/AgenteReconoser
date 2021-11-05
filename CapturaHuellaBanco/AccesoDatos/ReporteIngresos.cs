using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilidades;

namespace AccesoDatos
{
    public class ReporteIngresos
    {
        static LogErrores error = null;
        static RegistrarLog registro = new RegistrarLog();

        private string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

        public int InsertarLogIngresos(LogIngresos LO)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.InsertarLogIngresos", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UsuarioLogin", LO.UsuarioLogin);
                command.Parameters.AddWithValue("@Fecha", LO.Fecha);
                command.Parameters.AddWithValue("@IP", LO.Ip);
                command.Parameters.AddWithValue("@MAC", LO.Mac);
                command.Parameters.AddWithValue("@IdSucursal", LO.IdSucursal);
                command.Parameters.AddWithValue("@FueExitoso", LO.Exitoso);

                try
                {
                    connection.Open();
                    id = int.Parse(command.ExecuteScalar().ToString());

                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ReporteIngresos : InsertarLogIngresos";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }

            }
            return id;

        }


        public List<LogIngresos> ObtenerLogIngresos(string fechaIngreso, string fechaFin, string usuario, string ip, string estado)
        {
            LogIngresos LI;
            List<LogIngresos> LLI = new List<LogIngresos>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerLogIngresos", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaIngreso", fechaIngreso);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Ip", ip);
                    command.Parameters.AddWithValue("@Estado", estado);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new LogIngresos();
                        LI.UsuarioLogin = reader["UsuarioLogin"].ToString();

                        if (reader["Fecha"].ToString() == null || reader["Fecha"].ToString() == "")
                            LI.Fecha = null;
                        else
                            LI.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());

                        if (reader["FechaFin"].ToString() == null || reader["FechaFin"].ToString() == "")
                            LI.FechaFin = null;
                        else
                            LI.FechaFin = Convert.ToDateTime(reader["FechaFin"].ToString());

                        LI.Ip = reader["IP"].ToString();
                        LI.Mac = reader["MAC"].ToString();
                        LI.IdSucursal = Convert.ToInt32(reader["IdSucursal"]);
                        LI.NombreSucursal = reader["NombreSucursal"].ToString();
                        LI.Exitoso = Convert.ToBoolean(reader["FueExitoso"]);
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "ReporteIngresos : ObtenerLogIngresos";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                    //Escribir en algún log
                }
            }

            return LLI;
        }

        public void ActulizarSalidaAplicacion(long idAutenticacion)
        {


            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ActualizarSalidaAplicacion", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdAutenticacion", idAutenticacion);

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
                    error.Metodo = "ReporteIngresos : ActulizarSalidaAplicacion";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }

            }

        }
    }
}
