using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCFServicioReconoser
{
    using RequestEntities;

    [ServiceContract]
    internal interface IRestWCFReconososer
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "CapturarHuella/{cedula}/{dedo}/{captura}/{ticks}")]
        RespuestaCaptura CapturarHuella(string cedula, string dedo, string captura, string ticks);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ValidarIdentidad/{cedula}/{asesor}/{oficina}/{producto}/{ticks}/{*idConvenio}")]
        RespuestaValidacion ValidarIdentidad(string cedula, string asesor, string oficina, string producto, string ticks, string idConvenio);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "ValidarIdentidadSecu/{cedula}/{asesor}/{oficina}/{producto}/{ticks}/{*idConvenio}")]
        RespuestaValidacion ValidarIdentidadSecu(string cedula, string asesor, string oficina, string producto, string ticks, string idConvenio);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ObtenerFormatoAutorizacion/{cedula}/{ticks}/{*idConvenio}")]
        RespuestaObtenerFormato ObtenerFormatoAutorizacion(string cedula, string ticks, string idConvenio);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GenerarAutorizacion/{cedula}/{asesor}/{oficina}/{producto}/{ticks}/{*idConvenio}")]
        RespuestaGenerarAutorizacion GenerarAutorizacion(string cedula, string asesor, string oficina, string producto, string ticks, string idConvenio);

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "CancelarCaptura/{ticks}")]
        void CancelarCaptura(string ticks);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "CapturarHuella")]
        RespuestaCaptura CapturarHuellaP(CapturarHuellaRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ValidarIdentidad")]
        RespuestaValidacion ValidarIdentidadP(ValidarIdentidadRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ValidarIdentidadSecu")]
        RespuestaValidacion ValidarIdentidadSecuP(ValidarIdentidadSecuRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ObtenerFormatoAutorizacion")]
        RespuestaObtenerFormato ObtenerFormatoAutorizacionP(ObtenerFormatoAutorizacionRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "GenerarAutorizacion")]
        RespuestaGenerarAutorizacion GenerarAutorizacionP(GenerarAutorizacionRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "CancelarCaptura")]
        void CancelarCapturaP(CancelarCapturaRequest request);

        [OperationContract]
        [WebInvoke(Method = "OPTIONS", UriTemplate = "*")]
        void GetOptions();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "ConsultarEstado")]
        RespuestaConsultaEstado ConsultarEstado();
    }
}