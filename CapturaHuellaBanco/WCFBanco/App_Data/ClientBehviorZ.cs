using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace WCFBanco
{
    public class ClientBehviorZ : IEndpointBehavior
    {
        public string Username { get; set; }
   public string Password { get; set; }
   public bool Firmar { get; set; }

   public ClientBehviorZ(string username, string password, bool Firmar)
   {
      this.Username = username;
      this.Password = password;
      this.Firmar = Firmar;
   }


        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            //throw new NotImplementedException();
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new MessageInspectorZ(this.Username, this.Password, this.Firmar));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            //throw new NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            //throw new NotImplementedException();
        }
    }
}