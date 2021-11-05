using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilidades.EstampaCronologica;
using UtilidadesTest.Properties;

namespace UtilidadesTest
{
    [TestClass]
    public class UtilEstampaTest
    {
        [TestMethod]
        public void AgregarEstampaCronologicaTest()
        {
            var archivoInicial = Resources.Test;
            var archivoEstampado = UtilEstampa.AgregarEstampaCronologica(archivoInicial);
            if (!Directory.Exists("output"))
                Directory.CreateDirectory("output");
            File.WriteAllBytes("output/estampa_out.pdf", archivoEstampado);
        }
    }
}
