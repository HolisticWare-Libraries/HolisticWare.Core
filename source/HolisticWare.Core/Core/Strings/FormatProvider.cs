using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Strings
{
    public partial class FormatProvider 
                : 
                System.IFormatProvider, //System.Globalization.CultureInfo
                System.ICustomFormatter
    {
        private System.Globalization.CultureInfo culture_info = null;

        public System.Globalization.CultureInfo CurrentCulture
        {
            get
            {
                return culture_info;     
            }  
            set
            {
                culture_info = value;
            }
        }

        public FormatProvider()
        {
            FormatMethod = FormatDefault;

            return;
        }

        public Func<object, string, string> FormatMethod;

        public string FormatDefault(object o, string format)
        {
            Options options = new Options()
            {
                ContentTextual = format
            };

            StringBuilder sb = new StringBuilder();

            switch (format.ToUpperInvariant())
            {
                case "CSHARP":
                case "CS":
                    Type t = o.GetType();
                    string type_fq = t.FullName;
                    string type = t.Name;
                    string variable_name = type.ToLowerInvariant();
                    sb.AppendLine($"{type_fq} {variable_name}= new {type_fq} ();");
                    break;
                default:
                    HandleOtherFormats(format, o);
                    break;
            }

            return sb.ToString();
        }

        public string Format(string fmt, object arg, IFormatProvider formatProvider)
        {
            return this.FormatDefault(arg, fmt);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            else if (arg != null)
                return arg.ToString();
            else
                return String.Empty;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        string ICustomFormatter.Format(string format, object arg, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
