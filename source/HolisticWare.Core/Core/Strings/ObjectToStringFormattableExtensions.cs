// /*
//    Copyright (c) 2018-1
//
//    moljac
//    ObjectToStringFormattableExtensions.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */
using System;

namespace Core.Strings
{
    public static partial class ObjectToStringFormattableExtensions
    {
        #region IFormattable Members
        //public static string ToString(this object o, string format, IFormatProvider formatProvider)
        //{
        //    if (format == null) 
        //    {
        //        format = “G“;
        //    }

        //    if (formatProvider != null)
        //    {
        //        ICustomFormatter formatter = formatProvider.GetFormat(o.GetType())
        //        as ICustomFormatter;


        //    if (formatter != null)

        //        return formatter.Format(format, this, formatProvider);

        //}


        //switch(format)

        //{

        //    case “f“ : return _firstname;

        //    case “l“ : return _lastname;

        //    case “na“ : return string.Format(“{0} {1} Age= {2}“,

        //                _firstname, _lastname, _age.ToString());

        //    case “n“ :

        //    case “G“ :

        //    default : return string.Format(“{0} {1}“,
        //                      _firstname, _lastname);

        //}

    }

    #endregion

}
