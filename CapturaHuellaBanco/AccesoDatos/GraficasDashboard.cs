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
    public class GraficasDashboard
    {
        LogErrores error = null;

        RegistrarLog registro = new RegistrarLog();

        private string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

        public List<CantidadSolicitudes> ObtenerCantidadSolicitudes()
        {
            CantidadSolicitudes LI;
            List<CantidadSolicitudes> LLI = new List<CantidadSolicitudes>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerSolicitudesXAccion", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new CantidadSolicitudes();
                        LI.Accion = reader["Accion"].ToString();
                        LI.Cantidad = (int)reader["Cantidad"];
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : ObtenerCantidadSolicitudes";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }

        public List<RespuestaXsolicitud> ObtenerRespuestaXsolicitud()
        {
            RespuestaXsolicitud LI;
            List<RespuestaXsolicitud> LLI = new List<RespuestaXsolicitud>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerCantidadEstadosXAccion", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new RespuestaXsolicitud();
                        LI.Accion = (string)reader["Accion"];
                        LI.Cantidad = (int)reader["Cantidad"];
                        LI.RespuestaAFI = (string)reader["RespuestaAFI"];
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : ObtenerRespuestaXsolicitud";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }


        public List<TiemposDentroYFuera> ObtenerTiemposDentroYFuera()
        {
            TiemposDentroYFuera LI;
            List<TiemposDentroYFuera> LLI = new List<TiemposDentroYFuera>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerCantidadSolicitudesXLimite", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new TiemposDentroYFuera();
                        LI.Dentro = (int)reader["Dentro"];
                        LI.Fuera = (int)reader["Fuera"];
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : ObtenerTiemposDentroYFuera";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }

        public List<SolicitudesAprobadassXServicio> ObtenerSolicitudesAprobadassXServicio(string fechaInicio, string fechaFin)
        {
            SolicitudesAprobadassXServicio LI;
            List<SolicitudesAprobadassXServicio> LLI = new List<SolicitudesAprobadassXServicio>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerAprobadasXServicio", connection);
                command.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaIngreso", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new SolicitudesAprobadassXServicio();
                        LI.Accion = (string)reader["Accion"];
                        LI.Cantidad = (int)reader["Cantidad"];
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : ObtenerSolicitudesAprobadassXServicio";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }

        public List<SolicitudesAprobadassVSNoAprobadas> ObtenerSolicitudesAprobadassVSNoAprobadasa(string fechaInicio, string fechaFin)
        {
            SolicitudesAprobadassVSNoAprobadas LI;
            List<SolicitudesAprobadassVSNoAprobadas> LLI = new List<SolicitudesAprobadassVSNoAprobadas>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerAprobadasVSNoAprobadas", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new SolicitudesAprobadassVSNoAprobadas();
                        LI.Accion = (string)reader["Accion"];
                        LI.Cantidad = (int)reader["Cantidad"];
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : ObtenerSolicitudesAprobadassVSNoAprobadasa";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }

        public List<HitsVSNoHitsXDias> ObtenerHitsVSNoHitsXDias(int dias)
        {
            HitsVSNoHitsXDias LI;
            List<HitsVSNoHitsXDias> LLI = new List<HitsVSNoHitsXDias>();

            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerHitsVSNoHitsXDias", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@Dias", dias);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LI = new HitsVSNoHitsXDias();
                        LI.Fecha = (string)reader["Fecha"];
                        LI.Aprobado = (int)reader["Aprobado"];
                        LI.No_aprobado = (int)reader["No_aprobado"];
                        LLI.Add(LI);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : ObtenerHitsVSNoHitsXDias";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return LLI;
        }


        public int AprobadosHoy(string fechaInicio, string fechaFin)
        {
            int aprobados = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerTrnasaccionesAprobadasHoy", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        aprobados = (int)reader["Aprobados"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : AprobadosHoy";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return aprobados;


        }

        public int NoAprobadosHoy(string fechaInicio, string fechaFin)
        {
            int noAprobados = 0;
            using (SqlConnection connection = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("Historico.ObtenerTrnasaccionesNoAprobadasHoy", connection);
                command.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        noAprobados = (int)reader["NoAprobados"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    error = new LogErrores();
                    error.UsuarioLogin = "System";
                    error.Capa = "AccesoDatos";
                    error.Metodo = "GraficasDashboard : NoAprobadosHoy";
                    error.Fecha = DateTime.Now;
                    error.Descripcion = ex.Message;
                    registro.InsertarLogError(error);
                }
            }

            return noAprobados;


        }
    }
}
