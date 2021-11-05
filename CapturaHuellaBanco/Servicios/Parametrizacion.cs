using Entidades;
using Entidades.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Utilidades;

namespace Olimpia.Servicios
{
    public class Parametrizacion
    {
        private static RSACryptoServiceProvider cert = (RSACryptoServiceProvider)new X509Certificate2(Properties.Resources.client, "Olimpia.2017").PrivateKey;
        private static ServicioFachadaZeus.IServicioFachadaZeus sb = new ServicioFachadaZeus.ServicioFachadaZeusClient();
        public static List<Convenio> ConsultarConvenios(int idCliente)
        {
            List<Convenio> ret = new List<Convenio>();
            string metodo = "obtenerConvenios";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(idCliente)
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            var todos = sb.obtenerConvenios(idCliente, ticks, firma);

            foreach (var c in todos.Lista)
            {

                Convenio curr = new Convenio();
                curr.idConvenio = c.Codigo;
                curr.Nombre = c.Descripcion;
                curr.textoAutorizacion = c.TextoAutorizacion;
                curr.Biometrias = Biometria.ObtenerBiometrias(c.idCliente, c.Codigo);

                ret.Add(curr);
            }
            return ret;
        }

        public static RespuestaListas<Oficina> ConsultarTodosOficinas(bool incluirNoHab, int idCliente)
        {
            //Valida si el usuario está en cache
            ObjectCache Cache = MemoryCache.Default;

            if (Cache.Contains("ListOficinas"))
            {
                var res = (RespuestaListas<Oficina>)Cache["ListOficinas"];

                if (res.Lista.Count > 0)
                {
                    Trace.WriteLine("DFZM ListOficinas en memoria");
                    return res;
                }
            }

            RespuestaListas<Oficina> Rl = new RespuestaListas<Oficina>();

            string metodo = "obtenerOficinasActivas";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(0)
                .Concat(BitConverter.GetBytes(0))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            ServicioFachadaZeus.RespuestaConsultaOfRespuestaOficinaASHjg97_P Todos = sb.obtenerOficinasActivas(0, 0, idCliente, ticks, firma);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok ? Estado.Ok : Estado.Error;

            if (Todos.Estado == ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok)
            {
                List<ServicioFachadaZeus.RespuestaOficina> Result = Todos.Lista.ToList();
                //HACK: Se usa la direccion para traer el cliente de RNEC mientras se construye otro método para esto
                Rl.Lista = new List<Oficina>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Oficina
                    {
                        IdOficina = x.IdOficina,
                        IdZona = x.IdZona,
                        Direccion = x.Direccion.Split('|').Length > 1? x.Direccion.Split('|')[1]: x.Direccion.Split('|')[0],
                        Codigo = x.Codigo,
                        Ciudad = x.Ciudad,
                        Habilitado = x.Habilitado,
                        ClienteRNEC = x.Direccion.Split('|')[0],
                    }));
            }

            Cache.Add("ListOficinas", Rl, DateTime.Now.AddMinutes(120));
            Trace.WriteLine("DFZM ListOficinas NO!!! en memoria");
            return Rl;
        }

        public static bool ConsultarInyeccionHuellas(List<HuellaAFI> Dedos, string NumeroDocumento)
        {
            if (ConfigurationManager.AppSettings.Get("HashHuellas") == "true")
            {
                //Valida si existe una huella totalmente igual en caché
                ObjectCache Cache = MemoryCache.Default;
                if (Cache.Contains("DocVSHuellas"))
                {
                    var v = (List<DocVSHuellas>)Cache["DocVSHuellas"];

                    foreach (HuellaAFI AuxHuella in Dedos)
                    {
                        var auxhash = UtilidadesHuellas.sha256_hash(AuxHuella.Template);

                        if (v.Where(x => x.Huella == auxhash).Count() > 0)
                            return true;

                        else
                            v.Add(new DocVSHuellas { Documento = NumeroDocumento, Huella = auxhash });                        
                    }
                    //guardar huella en cache
                    Cache.Add("DocVSHuellas", v, DateTime.Now.AddHours(6));
                }
                else
                {
                    List<DocVSHuellas> LDH = new List<DocVSHuellas>();
                    Dedos.ForEach(x => LDH.Add(new DocVSHuellas { Documento = NumeroDocumento, Huella = UtilidadesHuellas.sha256_hash(x.Template) }));
                    Cache.Add("DocVSHuellas", LDH, DateTime.Now.AddHours(6));
                }
            }
            return false;
        }
       
        public static RespuestaListas<Parametros> ConsultarTodosParametros(bool incluirNoHab, int idCliente)
        {
            //Valida si el usuario está en cache
            ObjectCache Cache = MemoryCache.Default;

            if (Cache.Contains("ListParametros"))
            {
                var res = (RespuestaListas<Parametros>)Cache["ListParametros"];

                if (res.Lista.Count > 0)
                {
                    System.Diagnostics.Trace.WriteLine("DFZM ListParametros en memoria");
                    return res;
                }
            }

            RespuestaListas<Parametros> Rl = new RespuestaListas<Parametros>();

            string metodo = "obtenerParametros";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(0)
                .Concat(BitConverter.GetBytes(0))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));
            ServicioFachadaZeus.RespuestaConsultaOfRespuestaParametroYT4_S8D3r Todos = sb.obtenerParametros(0, 0, idCliente, ticks, firma);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok ? Estado.Ok : Estado.Error;

            if (Todos.Estado == ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok)
            {
                List<ServicioFachadaZeus.RespuestaParametro> Result = Todos.Lista.ToList();
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
            Trace.WriteLine("DFZM ListParametros NO!!! en memoria");
            return Rl;
        }

        public static RespuestaListas<Producto> ConsultarTodosProductos(bool incluirNoHab, int idCliente)
        {
            //Valida si el usuario está en cache
            ObjectCache Cache = MemoryCache.Default;

            if (Cache.Contains("ListProductos"))
            {
                var res = (RespuestaListas<Producto>)Cache["ListProductos"];

                if (res.Lista.Count > 0)
                {
                    Trace.WriteLine("DFZM ListProductos en memoria");
                    return res;
                }
            }

            RespuestaListas<Producto> Rl = new RespuestaListas<Producto>();

            string metodo = "obtenerProductosActivos";
            long ticks = DateTime.UtcNow.AddHours(-5).Ticks;
            byte[] data = BitConverter.GetBytes(0)
                .Concat(BitConverter.GetBytes(0))
                .Concat(BitConverter.GetBytes(idCliente))
                .Concat(BitConverter.GetBytes(ticks))
                .Concat(Encoding.UTF8.GetBytes(metodo))
                .ToArray();

            byte[] firma = cert.SignData(data, CryptoConfig.MapNameToOID("SHA256"));

            ServicioFachadaZeus.RespuestaConsultaOfRespuestaProductoJNSkRAIg Todos = sb.obtenerProductosActivos(0, 0, idCliente, ticks, firma);

            Rl.CodigoError = Todos.CodigoError;
            Rl.DescripcionError = Todos.DescripcionError;
            Rl.Estado = Todos.Estado == ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok ? Estado.Ok : Estado.Error;

            if (Todos.Estado == ServicioFachadaZeus.RespuestaEstadoRespuesta.Ok)
            {
                List<ServicioFachadaZeus.RespuestaProducto> Result = Todos.Lista.ToList();
                Rl.Lista = new List<Producto>();
                Result.ForEach(x =>
                    Rl.Lista.Add(new Producto
                    {
                        IdProducto = x.IdProducto,
                        IdServicio = x.IdServicio,
                        Codigo = x.Codigo,
                        Descripcion = x.Descripcion,
                        Habilitado = x.Habilitado
                    }));
            }

            Cache.Add("ListProductos", Rl, DateTime.Now.AddMinutes(30));
            System.Diagnostics.Trace.WriteLine("DFZM ListProductos NO!!! en memoria");
            return Rl;
        }

        public static DateTime GetNetworkTime()
        {
            //default Windows time server
            const string ntpServer = "time.windows.com";

            // NTP message size - 16 bytes of the digest (RFC 2030)
            var ntpData = new byte[48];

            //Setting the Leap Indicator, Version Number and Mode values
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;

            //The UDP port number assigned to NTP is 123
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            //NTP uses UDP

            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);

                //Stops code hang if NTP is blocked
                socket.ReceiveTimeout = 3000;

                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }

            //Offset to get to the "Transmit Timestamp" field (time at which the reply 
            //departed the server for the client, in 64-bit timestamp format."
            const byte serverReplyTime = 40;

            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);

            return networkDateTime.ToLocalTime();
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
    }
}