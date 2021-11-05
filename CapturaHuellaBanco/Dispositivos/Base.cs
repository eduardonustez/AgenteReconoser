using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispositivos
{
    public static class Base
    {
        public enum DeviceType
        {
            Morpho,
            MorphoSinVentana,
            PadUIC
        }

        public static void CheckDependencies()
        {
            Olimpia.MorphoSmart.MorphoSmartDevice dv = new Olimpia.MorphoSmart.MorphoSmartDevice();
        }
        public static IDispositivo ObtenerDispositivo(DeviceType dt = DeviceType.Morpho, int PtoCOM = -1)
        {
            IDispositivo ID = null;
            switch (dt)
            {
                case DeviceType.PadUIC:
                    ID = new Implementaciones.PadUIC();
                    ID.PuertoCom = PtoCOM;
                    break;

                case DeviceType.Morpho:
                    ID = new Implementaciones.LectorMorpho();
                    break;

                case DeviceType.MorphoSinVentana:
                    ID = new Implementaciones.MorphoSmart();
                    break;
            }

            if (ID != null && ID.DetectarDispositivo())
            {
                return ID;
            }

            return null;
        }
    }
}