using System.Collections.Generic;

namespace Entidades
{
    public class Biometrias
    {
        public List<string> HuellasObligatorias { get; set; }
        public List<string> HuellasOpcionales { get; set; }
        public int IdTipoBiometria { get; set; }
        public int NumeroMuestras { get; set; }
    }
}