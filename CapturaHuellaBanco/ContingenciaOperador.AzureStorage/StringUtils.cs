using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContingenciaOperador.AzureStorage
{
    public class StringUtils
    {
        public static string CamelCaseToHyphen(string input)
        {
            return string.Concat(
                input.Select((x, i) => 
                i > 0 && char.IsUpper(x) ? 
                    "-" + x.ToString() 
                    : x.ToString()))
                    .ToLower();
        }
    }
}
