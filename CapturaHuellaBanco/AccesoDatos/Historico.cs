using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Utilidades;

namespace AccesoDatos
{
    public class Historico
    {
        static LogErrores error = null;
        static RegistrarLog registro = new RegistrarLog();

        private string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

        public long InsertarLogOperaciones(LogOperaciones LO)
        {
            long IdLogOperaciones = 0;

            DateTime? fecha = null;

            if (LO.FechaExpedicion != DateTime.MinValue)
            {
                fecha = LO.FechaExpedicion;
            }

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.InsertarLogOperaciones", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UsuarioLogin", LO.UsuarioLogin);
                command.Parameters.AddWithValue("@Accion", LO.Accion);
                command.Parameters.AddWithValue("@Fecha", LO.Fecha);
                command.Parameters.AddWithValue("@IdServicio", LO.IdServicio);
                command.Parameters.AddWithValue("@Sigla", LO.Sigla);
                command.Parameters.AddWithValue("@NumeroDocumento", LO.Documento);
                command.Parameters.AddWithValue("@NumeroDedo", LO.NumeroDedo);
                command.Parameters.AddWithValue("@RespuestaAFI", LO.RespuestaAFI);
                command.Parameters.AddWithValue("@FechaExpedicion", fecha);
                command.Parameters.AddWithValue("@PrimerNombre", LO.PrimerNombre);
                command.Parameters.AddWithValue("@SegundoNombre", LO.SegundoNombre);
                command.Parameters.AddWithValue("@PrimerApellido", LO.PrimerApellido);
                command.Parameters.AddWithValue("@SegundoApellido", LO.SegundoApellido);
                command.Parameters.AddWithValue("@Vigencia", LO.Vigencia);

                try
                {
                    connection.Open();
                    IdLogOperaciones = long.Parse(command.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "Historico : InsertarLogOperaciones";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
                return IdLogOperaciones;
            }
        }

        public LogOperaciones SeleccionarLogOperacionesXId(long IdOperacion)
        {
            LogOperaciones LO = new LogOperaciones();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.SeleccionarLogOperacionesXId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdOperacion", IdOperacion);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LO.IdOperacion = long.Parse(reader["IdOperacion"].ToString());
                        LO.UsuarioLogin = reader["UsuarioLogin"].ToString();
                        LO.Accion = reader["Accion"].ToString();
                        LO.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        LO.IdServicio = (int)reader["IdServicio"];
                        LO.NombreServicio = reader["NombreServicio"].ToString();
                        LO.IdTipoDocumento = (int)reader["IdTipoDocumento"];
                        LO.TipoDocumento = reader["NombreTipoDocumento"].ToString();
                        LO.Documento = reader["NumeroDocumento"].ToString();
                        //LO.NumeroDedo = Convert.ToInt32(reader["NumeroDedo"]);
                        //LO.RespuestaAFI = reader["RespuestaAFI"].ToString();
                        LO.FechaExpedicion = Convert.ToDateTime(reader["Fechaexpedicion"].ToString());
                        LO.PrimerNombre = reader["PrimerNombre"].ToString();
                        LO.SegundoNombre = reader["SegundoNombre"].ToString();
                        LO.PrimerApellido = reader["PrimerApellido"].ToString();
                        LO.SegundoApellido = reader["SegundoApellido"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "Historico : SeleccionarLogOperacionesXId";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
                return LO;
            }
        }

        public List<LogOperaciones> SeleccionarLogOperaciones(long? IdOperacion, DateTime? FechaInicio, DateTime? FechaFin, string Documento, string UsuarioLogin, string RespuestaAFI)
        {
            LogOperaciones LO;
            List<LogOperaciones> LLO = new List<LogOperaciones>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.SeleccionarLogOperaciones", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdOperacion", IdOperacion);
                command.Parameters.AddWithValue("@FechaInicio", FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", FechaFin);
                command.Parameters.AddWithValue("@Documento", Documento);
                command.Parameters.AddWithValue("@UsuarioLogin", UsuarioLogin);
                command.Parameters.AddWithValue("@RespuestaAFI", RespuestaAFI);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LO = new LogOperaciones();
                        LO.IdOperacion = long.Parse(reader["IdOperacion"].ToString());
                        LO.UsuarioLogin = reader["UsuarioLogin"].ToString();
                        LO.Accion = reader["Accion"].ToString();
                        LO.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        LO.IdServicio = (int)reader["IdServicio"];
                        LO.NombreServicio = reader["NombreServicio"].ToString();
                        LO.Sigla = reader["Sigla"].ToString();
                        LO.TipoDocumento = reader["Sigla"].ToString();
                        LO.Documento = reader["NumeroDocumento"].ToString();
                        LO.NumeroDedo = Convert.ToInt32(reader["NumeroDedo"]);
                        LO.RespuestaAFI = reader["RespuestaAFI"].ToString();
                        if (reader["Fechaexpedicion"] != DBNull.Value)
                            LO.FechaExpedicion = Convert.ToDateTime(reader["Fechaexpedicion"].ToString());
                        LO.PrimerNombre = reader["PrimerNombre"].ToString();
                        LO.SegundoNombre = reader["SegundoNombre"].ToString();
                        LO.PrimerApellido = reader["PrimerApellido"].ToString();
                        LO.SegundoApellido = reader["SegundoApellido"].ToString();
                        LO.Vigencia = reader["Vigencia"].ToString();

                        LLO.Add(LO);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "Historico : SeleccionarLogOperaciones";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
                return LLO;
            }
        }
    }
}