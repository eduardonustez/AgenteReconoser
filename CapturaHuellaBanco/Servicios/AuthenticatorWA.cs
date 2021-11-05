using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Configuration;
using Entidades;
using System.Runtime.Caching;
using Banco;

namespace Banco
{
    public class AutorizacionWA
    {
        private static Dictionary<int, string> ListaNegra = ObtenerListaNegra();


       public static bool ValidarAutorizacion(string Action, System.Security.Principal.WindowsIdentity Identidad)
        {
            System.Diagnostics.Trace.WriteLine("VALIDAR AUTORIZACION");
             bool Validar = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("Validar"));

             if (!Validar)
             {
                 return true;
             }

           string userlogin = "";
           System.Diagnostics.Trace.WriteLine("Identidad.Name: " + Identidad.Name);
           if (Identidad != null && !string.IsNullOrEmpty(Identidad.Name) && Identidad.Name.Contains(@"\"))
            {               
                userlogin = Identidad.Name.Substring(Identidad.Name.LastIndexOf(@"\"));
                userlogin = userlogin.Replace(@"\", "").Trim();
            }
           else
           {
               LanzarExcepcion();
           }

           System.Diagnostics.Trace.WriteLine("VALIDAR AUTORIZACION2: " + userlogin);

           var UsuariosReconoser = ObtenerUsuarios();
           var UsuarioRec = UsuariosReconoser.Lista.Find(i => i.IdUsuario == userlogin);
           if(UsuarioRec == null)
           {
               LanzarExcepcion();
           }

           string userMetodo = "";

           if (!string.IsNullOrEmpty(Action) && Action.Contains(@"/"))
           {
               userMetodo = Action.Substring(Action.LastIndexOf(@"/"));
               userMetodo = userMetodo.Replace(@"/", "").Trim();
           }

           if (ListaNegra[UsuarioRec.IdRol].Contains(userMetodo))
           {
               LanzarExcepcion();
           }           

            return true;



        }

        private static void  LanzarExcepcion()
        {
            System.Diagnostics.Trace.WriteLine("Sin Autorización");
            throw new FaultException("Sin Autorización");
        }

        private static RespuestaListas<Entidades.Parametrizacion.Usuario> ObtenerUsuarios()
        {
            ObjectCache Cache = MemoryCache.Default;

            if(Cache != null &&  Cache.Contains("UsuariosAutorizacion"))
            {
                return (RespuestaListas<Entidades.Parametrizacion.Usuario>) Cache["UsuariosAutorizacion"];

            }
            else
            {
                ServicioParametrizacion esto = new ServicioParametrizacion();
                var Usuarios = esto.ConsultarTodosUsuarios(true);
                //Cache["UsuariosAutorizacion"] = Usuarios;
                Cache.Add("UsuariosAutorizacion", Usuarios, DateTime.Now.AddHours(6));
                return Usuarios;

            }


                

        }

        private static Dictionary<int, string> ObtenerListaNegra()
        {
            Dictionary<int, string> Lista = new Dictionary<int, string>();

            //Parametrizacion
            string Parametrizacion = "ActualizarParametro;CambiarEstadoProducto;CrearActualizarProducto;CambiarEstadoServicio;CrearActualizarServicio;CambiarEstadoUsuario;CrearActualizarUsuario;CambiarEstadoRol;CrearActualizarRol;CambiarEstadoOficina;CrearActualizarOficina;EliminarZona;CrearActualizarZona;";
            string ReportesRiesgo = "ConsultarAceptaNoAcepta;ObtenerLogIngresos;";

            //Asesor (Nada de Parametrizacion)
            Lista.Add(1, Parametrizacion + ReportesRiesgo);

            //Supervisor (Nada de Parametrizacion)
            Lista.Add(2, Parametrizacion + ReportesRiesgo);

            //Riesgo (Nada de usuarios y roles y Verificar Identidad)
            Lista.Add(3, "VerificarIdentidad;CambiarEstadoUsuario;CrearActualizarUsuario;CambiarEstadoRol;CrearActualizarRol;");

            //Control (Solo usuario y roles y Verificar Identidad)
            Lista.Add(4, "VerificarIdentidad;ActualizarParametro;CambiarEstadoProducto;CrearActualizarProducto;CambiarEstadoServicio;CrearActualizarServicio;CambiarEstadoOficina;CrearActualizarOficina;EliminarZona;CrearActualizarZona;" + ReportesRiesgo);

            return Lista;


        }


    }

}