// /*
//    Copyright (c) 2018-1
//
//    moljac
//    Test.cs
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
using NUnit.Framework;
using System;

using Core.Strings;
using System.Collections.Generic;

namespace UnitTests.NUnit.HolisticWare.Core
{
    public class ToStringFormattableTests
    {
        [Test()]
        public void PersonToStringTestCase()
        {
            int i = 5;

            Console.WriteLine($"int i = {i.ToString("CS=")}");

            Person p = new Person();

            string output_default = null;
            string output_custom = null;
            string output_expected = null;

            output_default = p.ToString();
            output_custom =  p.ToString("CS singleline");
            output_expected = "UnitTests.NUnit.HolisticWare.Core.Person";

            Console.WriteLine($"Person p = {output_default}");
            Console.WriteLine($"Person p = {output_custom}");

            Assert.AreEqual(output_default, output_expected);

            return;
        }

        [Test()]
        public void ListToStringTestCase()
        {
            List<int> ints = new List<int>
            {
                1,
                5,
                7,
                11
            };

            string output_default  = null;
            string output_custom   = null;
            string output_expected = null;

            output_default  = ints.ToString();
            output_expected = "System.Collections.Generic.List`1[System.Int32]";

            Console.WriteLine($"List<int> ints = {ints}");
            Console.WriteLine($"List<int> ints = {output_default}");
            Assert.AreEqual(output_default, output_expected);


            output_custom = ints.ToString("CS multiline");
            output_expected = "";

            Console.WriteLine($"List<int> ints = {output_custom}");
            Assert.AreEqual(output_custom, output_expected);


            output_custom   = ints.ToString("CS singleline");
            output_expected = "";

            Console.WriteLine($"List<int> ints = {output_custom}");
            Assert.AreEqual(output_custom, output_expected);


            return;
        }
    }
}
