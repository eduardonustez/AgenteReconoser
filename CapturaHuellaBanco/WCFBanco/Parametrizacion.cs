using Entidades;
using Entidades.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace WCFBanco
{
    public class Parametrizacion
    {
        private ServicioFachadaOlimpia.ServicioColpatriaClient sb = new ServicioFachadaOlimpia.ServicioColpatriaClient();

        public RespuestaListas<Parametros> ConsultarTodosParametros(bool incluirNoHab)
        {
            //Valida si el usuario está en cache
            ObjectCache Cache = MemoryCache.Default;

            if (Cache.Contains("ListParametros"))
            {
                var res = (RespuestaListas<Parametros>)Cache["ListParametros"];

                if (res.Lista.Count > 0)
                {
                    return res;
                }
            }

            RespuestaListas<Parametros> Rl = new RespuestaListas<Parametros>();
            WCFBanco.ServicioFachadaOlimpia.RespuestaLogOfParametroVMrJHE_SDAL Todos = sb.ConsultarTodosParametros();

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok ? Entidades.Estado.Ok : Entidades.Estado.Error;

            if (Todos.Estado == ServicioFachadaOlimpia.RespuestaEstadoRespuesta.Ok)
            {
                List<WCFBanco.ServicioFachadaOlimpia.ParametroVM> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Parametros>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Parametros
                    {
                        IdParametro = x.IdParametro,
                        Parametro = x.Codigo,
                        Valor = x.Valor,
                        UsuarioModificacion = x.UsuarioModificacion,
                        FechaModificacion = x.FechaModificacion
                    }));
            }
            Cache.Add("ListParametros", Rl, DateTime.Now.AddMinutes(30));
            return Rl;
        }
    }
}