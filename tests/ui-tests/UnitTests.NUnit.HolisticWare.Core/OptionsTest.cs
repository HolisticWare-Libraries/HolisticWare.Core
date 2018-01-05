using NUnit.Framework;

using System;

using Core.Strings;
using System.Collections.Generic;

namespace UnitTests.NUnit.HolisticWare.Core
{
    [TestFixture()]
    public class OptionsTest
    {
        [Test()]
        public void OptionsTestCase()
        {
            string[] options_strings = new string[]
            {
                "cs=new,public",
                "cs=new,public arg1=2 arg2=3 arg3=2,5 ",
                "cs=new,public arg1:2 arg2=3 arg3=2,5 ",
                "cs=new,public arg1:2 arg2=3 arg3=2,5 ",
            };

            foreach (string options_string in options_strings)
            {
                Options options = new Options();
                options.ContentTextual = options_string;

                List<Option> list_options = options.Parse(options_string, new string[] { " " });

                foreach(Option o in list_options)
                {
                    Console.WriteLine($"Option.Content  = {o.Content}");
                    Console.WriteLine($"Option.Key      = {o.Key}");
                    Console.WriteLine($"Option.Value    = {o.Value}");
                    Console.WriteLine($"Option.Values   = {o.Values.ToString("L")}");
                }
            }

            return;
        }
    }
}
