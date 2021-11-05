using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Utilidades;
using UtilidadesTest.Properties;

namespace UtilidadesTest
{
    [TestClass]
    public class UtilFormatoTest
    {
        [TestMethod]
        public void AgregarInfoTest()
        {
            string documento = "123456789";
            string oficina = "oficina prueba";
            string producto = "producto prueba";
            string usuario = "asesor@empresa.com";
            string ciudad = "sutamarchán";
            byte[] grafo = Resources.Firma;
            var archivoInicial = Resources.Test;
            var archivoFinal = UtilFormato.AgregarInfo(archivoInicial, documento, oficina, producto, usuario, ciudad, grafo);
            if (!Directory.Exists("output"))
                Directory.CreateDirectory("output");
            File.WriteAllBytes("output/info_out.pdf", archivoFinal);
        }

        [TestMethod]
        public void AgregarMetadataTest()
        {
            var metadata = new Dictionary<string, string>()
            {
                {"prueba_llave", "prueba_valor" }
            };
            var archivoInicial = Resources.Test;
            var archivoFinal = UtilFormato.AgregarMetadata(archivoInicial, metadata);
            if (!Directory.Exists("output"))
                Directory.CreateDirectory("output");
            File.WriteAllBytes("output/metadata_out.pdf", archivoFinal);
        }
    }
}
