using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivos.Scanner.Helpers
{
    [Serializable]
    public class ScannerIntegrationException : Exception
    {
        public ScannerIntegrationException() : base() { }
        public ScannerIntegrationException(string message) : base(message) { }
        public ScannerIntegrationException(string message, Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected ScannerIntegrationException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
