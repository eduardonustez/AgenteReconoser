// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client.Hubs;

namespace Microsoft.AspNet.SignalR.Client.Samples
{
    public class CommonClient
    {
        private TextWriter _traceWriter;

        public CommonClient(TextWriter traceWriter)
        {
            _traceWriter = traceWriter;
        }

        public void Run(string url) => RunAsync(url).Wait();

        public async Task RunAsync(string url)
        {
            try
            {
                await RunDemo(url);
            }
            catch (HttpClientException httpClientException)
            {
                _traceWriter.WriteLine("HttpClientException: {0}", httpClientException.Response);
                throw;
            }
            catch (Exception exception)
            {
                _traceWriter.WriteLine("Exception: {0}", exception);
                throw;
            }
        }

        private async Task RunDemo(string url)
        {
            var hubConnection = new HubConnection(url);
            hubConnection.TraceWriter = _traceWriter;

            var hubProxy = hubConnection.CreateHubProxy("ChatHub");
            hubProxy.On<int>("contador", (i) =>
            {
                int n = hubProxy.GetValue<int>("index");
                hubConnection.TraceWriter.WriteLine("{0} client state index -> {1}", i, n);
            });
            hubProxy.On<string>("callbackExample", parameter1 =>
            {
                Console.WriteLine("Recibi esto:" + parameter1);
                //string newSignature = hubProxy.GetValue<string>("signature");
                //hubConnection.TraceWriter.WriteLine("Firma obtenida {0}", i, newSignature);
            });


            await hubConnection.Start();
            //hubConnection.TraceWriter.WriteLine("transport.Name={0}", hubConnection.Transport.Name);

            //hubConnection.TraceWriter.WriteLine("Invoking long running hub method with progress...");
            var result = await hubProxy.Invoke<string, int>("ReportProgress",
                percent => hubConnection.TraceWriter.WriteLine("{0}% complete", percent),
                /* jobName */ "Long running job");
            hubConnection.TraceWriter.WriteLine("SignalR: {0}", result);

            await hubProxy.Invoke("multipleCalls");

            var resultI = await hubProxy.Invoke<int>("GetValue");
            hubConnection.TraceWriter.WriteLine("SignalR: {0}", resultI);
                      

        }
    }
}