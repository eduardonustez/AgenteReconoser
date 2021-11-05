using System;

namespace Utilidades
{
    public class UtilidadesFecha
    {
        public static bool CantidadDias(DateTime A, DateTime B)
        {
            var days = (int)(B - A).TotalDays;

            if (days < 31)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool EsmayorAB(DateTime A, DateTime B)
        {
            string fini = A.ToShortDateString();
            string ffin = B.ToShortDateString();
            DateTime dini = Convert.ToDateTime(fini);
            DateTime dfin = Convert.ToDateTime(ffin);

            if (dini > dfin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}