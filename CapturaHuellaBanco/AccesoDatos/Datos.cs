using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using Entidades;

namespace AccesoDatos
{
    public abstract class Datos
    {
        /* public Object EjecutarSP(string NombreSP, Dictionary<string,string>, Object o)
         {
             string con = ConfigurationManager.ConnectionStrings["ConexionReconoserColpatria"].ToString();

             using (SqlConnection connection = new SqlConnection(con))
             {
                 SqlCommand command = new SqlCommand(NombreSP, connection);
                 command.CommandType = CommandType.StoredProcedure;

                 //SqlParameter par = command.Parameters.AddWithValue("key", "value");

                 try
                 {
                     connection.Open();
                     SqlDataReader reader = command.ExecuteReader();
                     XmlReader xml = command.ExecuteXmlReader();
                     //DataTable table = reader.GetSchemaTable();

                     
                     while (reader.Read())
                     {
                         //reader[0], reader[1], reader[2]);
                     }
                     reader.Close();
                     

        Object n = new List<Servicio>();
                    return n;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
        }*/
    }
}
