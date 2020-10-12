using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Strings
{
    public static class SystemObjectExtensions
    {
        public static string ToString(this object o, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return o.ToString();
            }

            return o.ToString
                    (
                        format, 
                        // System.Globalization.CultureInfo.CurrentCulture
                        new FormatProvider()
                    );
        }

        public static string ToString(this object o, string format, FormatProvider provider)
        {
            string formatted = null;

            if (String.IsNullOrEmpty(format))
            {
                formatted = o.ToString();

                return formatted;
            }

            IFormatProvider ifp = null;

            if (provider == null)
            {
                ifp = provider.CurrentCulture;
            }
            else
            {
                formatted = provider.FormatMethod(o, format);
            }

            return formatted;
        }

    }
}
