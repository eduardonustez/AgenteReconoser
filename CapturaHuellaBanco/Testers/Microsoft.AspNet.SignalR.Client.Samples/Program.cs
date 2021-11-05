// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.AspNet.SignalR.Client.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var writer = Console.Out;
            var client = new CommonClient(writer);
            client.Run("http://localhost:8899/signalR");

            Console.ReadKey();
        }
    }
}
