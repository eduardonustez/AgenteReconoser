using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Utilidades
{
    public class UtilidadesCOM
    {
        private const int BUFFER_SIZE = 1024;

        private static DEVPROPKEY DEVPKEY_BusReportedDeviceDesc;

        static UtilidadesCOM()
        {
            // llave para acceder a la propiedad "Bus Reported Device Description" que es una identificacion propia del dispositivo
            // y no del driver
            DEVPKEY_BusReportedDeviceDesc = new DEVPROPKEY();
            DEVPKEY_BusReportedDeviceDesc.fmtid = new Guid(0x540b947e, 0x8b40, 0x45bc, 0xa8, 0xa2, 0x6a, 0x0b, 0x89, 0x4c, 0xbd, 0xa2);
            DEVPKEY_BusReportedDeviceDesc.pid = 4;
        }

        public static List<DispositivoCOM> ObtenerDispositvosCOM()
        {
            Guid[] guids = ObtenerGUIDs("Ports");
            List<DispositivoCOM> devices = new List<DispositivoCOM>();
            for (int i = 0; i < guids.Length; i++)
            {
                IntPtr ptrGrpDisp = SetupDiGetClassDevs(ref guids[i], 0, 0, 2);
                if (ptrGrpDisp != IntPtr.Zero)
                {
                    try
                    {
                        for (uint j = 0; true; j++)
                        {
                            SP_DEVINFO_DATA datosDisp = new SP_DEVINFO_DATA();
                            datosDisp.cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
                            bool ok = SetupDiEnumDeviceInfo(ptrGrpDisp, j, ref datosDisp);
                            if (!ok)
                            {
                                // fin del grupo de dispositivos
                                break;
                            }

                            DispositivoCOM disp = new DispositivoCOM();
                            disp.puerto = ObtenerNombreDisp(ptrGrpDisp, datosDisp);
                            disp.descripcionDriver = ObtenerDescripcionDriver(ptrGrpDisp, datosDisp);
                            disp.descripcionBus = ObtenerDescripcionBus(ptrGrpDisp, datosDisp);
                            devices.Add(disp);
                        }
                    }
                    finally
                    {
                        SetupDiDestroyDeviceInfoList(ptrGrpDisp);
                    }
                }
            }
            return devices;
        }

        private static string ObtenerDescripcionBus(IntPtr ptrGrpDisp, SP_DEVINFO_DATA datosDisp)
        {
            byte[] ptrBuf = new byte[BUFFER_SIZE];
            uint propRegDataType;
            uint RequiredSize;
            bool ok = SetupDiGetDevicePropertyW(ptrGrpDisp, ref datosDisp, ref DEVPKEY_BusReportedDeviceDesc,
                out propRegDataType, ptrBuf, BUFFER_SIZE, out RequiredSize, 0);
            if (!ok)
            {
                return string.Empty;
            }
            return System.Text.UnicodeEncoding.Unicode.GetString(ptrBuf, 0, (int)RequiredSize - 2);
        }

        private static string ObtenerDescripcionDriver(IntPtr ptrGrpDisp, SP_DEVINFO_DATA datosDisp)
        {
            byte[] ptrBuf = new byte[BUFFER_SIZE];
            uint propRegDataType;
            uint RequiredSize;
            bool ok = SetupDiGetDeviceRegistryProperty(ptrGrpDisp, ref datosDisp, 0 /*Descripcion*/,
                out propRegDataType, ptrBuf, BUFFER_SIZE, out RequiredSize);
            if (!ok)
            {
                return string.Empty;
            }
            return Encoding.Unicode.GetString(ptrBuf, 0, (int)RequiredSize - 2);
        }

        private static Guid[] ObtenerGUIDs(string tipo)
        {
            uint tamanoArreglo = 0;
            Guid[] ret = new Guid[1];

            bool status = SetupDiClassGuidsFromName(tipo, ref ret[0], 1, out tamanoArreglo);
            if (true == status)
            {
                if (1 < tamanoArreglo)
                {
                    ret = new Guid[tamanoArreglo];
                    SetupDiClassGuidsFromName(tipo, ref ret[0], tamanoArreglo, out tamanoArreglo);
                }
            }
            else
            {
                throw new System.ComponentModel.Win32Exception();
            }

            return ret;
        }

        private static string ObtenerNombreDisp(IntPtr ptrGrpDisp, SP_DEVINFO_DATA datosDisp)
        {
            IntPtr hDeviceRegistryKey = SetupDiOpenDevRegKey(ptrGrpDisp, ref datosDisp, 1, 0, 1, 1);
            if (hDeviceRegistryKey == IntPtr.Zero)
            {
                throw new Exception("Error al obtener llave de registro para el nombre del dispositivo");
            }

            byte[] ptrBuf = new byte[BUFFER_SIZE];
            uint l = (uint)ptrBuf.Length;
            try
            {
                uint lpRegKeyType;
                int res = RegQueryValueEx(hDeviceRegistryKey, "PortName", 0, out lpRegKeyType, ptrBuf, ref l);
                if (res != 0)
                {
                    throw new Exception("Error al leer el nombre del dispositivo desde el registro");
                }
            }
            finally
            {
                RegCloseKey(hDeviceRegistryKey);
            }

            return Encoding.Unicode.GetString(ptrBuf, 0, (int)l - 2);
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int RegCloseKey(IntPtr hKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        private static extern int RegQueryValueEx(IntPtr hKey, string lpValueName, int lpReserved, out uint lpType,
                    byte[] lpData, ref uint lpcbData);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiClassGuidsFromName(string ClassName,
                    ref Guid ClassGuidArray1stItem, uint ClassGuidArraySize,
                    out uint RequiredSize);

        // Microsoft setupapi es una libreria no administrada incluida desde windows 7 en adelante.
        // Permite, entre otras cosas, acceder a las propiedades avanzadas de drivers y dispositivos.
        // Para mayor informacion, visitar la pagina de referencia de setupapi:
        // https://msdn.microsoft.com/es-es/library/windows/hardware/ff550897(v=vs.85).aspx
        [DllImport("setupapi.dll")]
        private static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInterfaceData);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, uint iEnumerator, uint hParent, uint nFlags);

        [DllImport("setupapi.dll", SetLastError = true)]
        private static extern bool SetupDiGetDevicePropertyW(
            IntPtr deviceInfoSet,
            [In] ref SP_DEVINFO_DATA DeviceInfoData,
            [In] ref DEVPROPKEY propertyKey,
            [Out] out uint propertyType,
            byte[] propertyBuffer,
            uint propertyBufferSize,
            out uint requiredSize,
            uint flags);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetupDiGetDeviceRegistryProperty(
            IntPtr DeviceInfoSet,
            ref SP_DEVINFO_DATA DeviceInfoData,
            uint Property,
            out uint PropertyRegDataType,
            byte[] PropertyBuffer,
            uint PropertyBufferSize,
            out uint RequiredSize);

        [DllImport("Setupapi", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetupDiOpenDevRegKey(IntPtr hDeviceInfoSet, ref SP_DEVINFO_DATA deviceInfoData, uint scope,
            uint hwProfile, uint parameterRegistryValueKind, uint samDesired);
        public struct DispositivoCOM
        {
            public string descripcionBus;
            public string descripcionDriver;
            public string puerto;
        }

        /// <summary>
        /// Llave que permite acceder a una propiedad especifica del dispositivo
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct DEVPROPKEY
        {
            public Guid fmtid;
            public uint pid;
        }

        /// <summary>
        /// Estructura que contiene la informacion de un dispositivo en un DeviceInformationSet
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct SP_DEVINFO_DATA
        {
            public uint cbSize;
            public Guid ClassGuid;
            public uint DevInst;
            public UIntPtr Reserved;
        };
    }
}