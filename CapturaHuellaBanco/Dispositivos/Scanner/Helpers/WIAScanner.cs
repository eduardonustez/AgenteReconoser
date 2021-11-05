using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using WIA;

namespace Dispositivos.Scanner.Helpers
{
    public struct WIADeviceInfo
    {
        public string DeviceID;
        public string Name;
        public WIADeviceInfo(string DeviceID, string Name)
        {
            this.DeviceID = DeviceID;
            this.Name = Name;
        }
    }

    // https://msdn.microsoft.com/en-us/library/windows/desktop/ms630313(v=vs.85).aspx
    public enum WIADeviceInfoProp
    {
        DeviceID = 2,
        Manufacturer = 3,
        Description = 4,
        Type = 5,
        Port = 6,
        Name = 7,
        Server = 8,
        RemoteDevID = 9,
        UIClassID = 10,
    }

    // http://www.papersizes.org/a-paper-sizes.htm
    public enum WIAPageSize
    {
        A4, // 8.3 x 11.7 in  (210 x 297 mm)
        Letter, // 8.5 x 11 in (216 x 279 mm)
        Legal, // 8.5 x 14 in (216 x 356 mm)
        Document, // (85,60 X 53,98 mm)
        Epson510,
    }

    public enum WIAScanQuality
    {
        Preview,
        Final,
    }

    class WIAScanner
    {
        const string wiaFormatBMP = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
        const string WIA_DEVICE_PROPERTY_PAGES_ID = "3096";
        const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
        const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
        const string WIA_SCAN_COLOR_MODE = "6146";
        class WIA_DPS_DOCUMENT_HANDLING_SELECT
        {
            public const uint FEEDER = 0x00000001;
            public const uint FLATBED = 0x00000002;
        }
        class WIA_DPS_DOCUMENT_HANDLING_STATUS
        {
            public const uint FEED_READY = 0x00000001;
        }
        class WIA_PROPERTIES
        {
            public const uint WIA_RESERVED_FOR_NEW_PROPS = 1024;
            public const uint WIA_DIP_FIRST = 2;
            public const uint WIA_DPA_FIRST = WIA_DIP_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            public const uint WIA_DPC_FIRST = WIA_DPA_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            //
            // Scanner only device properties (DPS)
            //
            public const uint WIA_DPS_FIRST = WIA_DPC_FIRST + WIA_RESERVED_FOR_NEW_PROPS;
            public const uint WIA_DPS_DOCUMENT_HANDLING_STATUS = WIA_DPS_FIRST + 13;
            public const uint WIA_DPS_DOCUMENT_HANDLING_SELECT = WIA_DPS_FIRST + 14;

        }

        /// <summary>
        /// Use scanner to scan an image (with user selecting the scanner from a dialog).
        /// </summary>
        /// <returns>Scanned images.</returns>
        public static List<Image> Scan(WIAScanQuality scanQuality, WIAPageSize pageSize, int resolution)
        {
            ICommonDialog dialog = new CommonDialog();
            Device device = dialog.ShowSelectDevice(WiaDeviceType.UnspecifiedDeviceType, true, false);
            if (device != null)
            {
                return Scan(device.DeviceID, 1, scanQuality, pageSize, resolution);
            }
            else
            {
                throw new ScannerIntegrationException("Selecciona un dispositivo para escanear...");
            }
        }

        /// <summary>
        /// Use scanner to scan an image (scanner is selected by its unique id).
        /// </summary>
        /// <param name="scannerName"></param>
        /// <returns>Scanned images.</returns>
        public static List<Image> Scan(string scannerId, int pages, WIAScanQuality quality, WIAPageSize pageSize, int resolution)
        {
            List<Image> images = new List<Image>();
            bool hasMorePages = true;
            int numbrPages = pages;
            while (hasMorePages)
            {
                DeviceManager manager = new DeviceManager();
                Device device = null;
                foreach (DeviceInfo info in manager.DeviceInfos)
                {
                    if (info.DeviceID == scannerId)
                    {
                        device = info.Connect();
                        break;
                    }
                }
                if (device == null)
                {
                    string availableDevices = "";
                    foreach (DeviceInfo info in manager.DeviceInfos)
                    {
                        availableDevices += info.DeviceID + "\n";
                    }

                    throw new ScannerIntegrationException("El dispositivo no fue encontrado. Se encontraron los siguientes dispositivos:\n" + availableDevices);
                }
                SetWIAProperty(device.Properties, WIA_DEVICE_PROPERTY_PAGES_ID, 1);
                Item item = device.Items[1] as Item;

                int dpi;
                int width_pixels;
                int height_pixels;
                switch (quality)
                {
                    case WIAScanQuality.Preview:
                        dpi = resolution;
                        break;
                    case WIAScanQuality.Final:
                        dpi = 600;
                        break;
                    default:
                        throw new ScannerIntegrationException("Calidad de escaneo desconocido: " + quality.ToString());
                }
                switch (pageSize)
                {
                    case WIAPageSize.A4:
                        width_pixels = (int)(8.3f * dpi);
                        height_pixels = (int)(11.7f * dpi);
                        break;
                    case WIAPageSize.Letter:
                        width_pixels = (int)(8.5f * dpi);
                        height_pixels = (int)(11f * dpi);
                        break;
                    case WIAPageSize.Legal:
                        width_pixels = (int)(8.5f * dpi);
                        height_pixels = (int)(14f * dpi);
                        break;
                    case WIAPageSize.Document:
                        width_pixels = (int)(3.4f * dpi);
                        height_pixels = (int)(2.17f * dpi);
                        break;
                    case WIAPageSize.Epson510:
                        width_pixels = (int)(8.5f * dpi);
                        height_pixels = (int)(2.17f * dpi);
                        break;
                    default:
                        throw new ScannerIntegrationException("Tamaño de página desconocido: " + pageSize.ToString());
                }

                AdjustScannerSettings(item, dpi, 0, 0, width_pixels, height_pixels, 0, 0, 2);

                try
                {
                    ICommonDialog wiaCommonDialog = new CommonDialog();
                    ImageFile image = (ImageFile)wiaCommonDialog.ShowTransfer(item, wiaFormatBMP, false);

                    string fileName = Path.GetTempFileName();
                    File.Delete(fileName);
                    image.SaveFile(fileName);
                    image = null;
                    images.Add(Image.FromFile(fileName));
                }
                catch (Exception exc)
                {
                    throw new ScannerIntegrationException("Compruebe que el escáner esté encendido y conectado al equipo. Si la falla continua, comuníquese con el administrador para obtener ayuda");
                }
                finally
                {
                    item = null;
                    Property documentHandlingSelect = null;
                    Property documentHandlingStatus = null;
                    foreach (Property prop in device.Properties)
                    {
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_SELECT)
                            documentHandlingSelect = prop;
                        if (prop.PropertyID == WIA_PROPERTIES.WIA_DPS_DOCUMENT_HANDLING_STATUS)
                            documentHandlingStatus = prop;
                    }
                    hasMorePages = false;
                    if (documentHandlingSelect != null)
                    {
                        if ((Convert.ToUInt32(documentHandlingSelect.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_SELECT.FEEDER) != 0)
                        {
                            hasMorePages = ((Convert.ToUInt32(documentHandlingStatus.get_Value()) & WIA_DPS_DOCUMENT_HANDLING_STATUS.FEED_READY) != 0);
                        }
                    }
                }
                numbrPages -= 1;
                if (numbrPages > 0)
                    hasMorePages = true;
                else
                    hasMorePages = false;

            }
            return images;
        }

        /// <summary>
        /// Gets the list of available WIA devices.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<WIADeviceInfo> GetDevices()
        {
            List<string> devices = new List<string>();
            DeviceManager manager = new DeviceManager();
            foreach (DeviceInfo info in manager.DeviceInfos)
            {
                // https://msdn.microsoft.com/en-us/library/windows/desktop/ms630313(v=vs.85).aspx
                yield return new WIADeviceInfo(info.DeviceID, info.Properties[WIADeviceInfoProp.Manufacturer].get_Value());
            }
        }
        private static void SetWIAProperty(IProperties properties,
               object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }
        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel,
         int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";

            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
        }

    }
}
