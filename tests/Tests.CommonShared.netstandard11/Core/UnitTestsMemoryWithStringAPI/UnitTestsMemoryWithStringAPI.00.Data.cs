#if XUNITusing Xunit;// NUnit aliasesusing Test = Xunit.FactAttribute;using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;// XUnit aliasesusing TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;#elif NUNITusing NUnit.Framework;// MSTest aliasesusing TestInitialize = NUnit.Framework.SetUpAttribute;using TestProperty = NUnit.Framework.PropertyAttribute;using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;using TestMethod = NUnit.Framework.TestAttribute;using TestCleanup = NUnit.Framework.TearDownAttribute;// XUnit aliasesusing Fact = NUnit.Framework.TestAttribute;#elif MSTESTusing Microsoft.VisualStudio.TestTools.UnitTesting;// NUnit aliasesusing Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;// XUnit aliasesusing Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;#endif#if BENCHMARKDOTNETusing BenchmarkDotNet.Running;using BenchmarkDotNet.Configs;using BenchmarkDotNet.Attributes.Jobs;#elseusing Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;#endifusing System;using System.Collections.Generic;using System.Text;using System.Collections;using System.Linq;using Core;namespace Tests.CommonShared.Core{    [TestClass] // for MSTest - NUnit [TestFixture] and XUnit not needed    //[SimpleJob(launchCount: 1, warmupCount: 3, targetCount: 5, invocationCount: 100, id: "QuickJob")]    [ShortRunJob]    public partial class UnitTestsMemoryWithStringAPI    {        string string_01 = "https://blog.stephencleary.com/2013/10/taskrun-etiquette-and-proper-usage.html";        Memory<char> string_01_as_memory;

        // Error CS8345:
        // Field or auto-implemented property cannot be of type 'Span<char>' unless it is an instance member of
        // a ref struct.        // Span<char> string_01_as_span = string_01.AsSpan();        public void Initialize()
        {
            string_01_as_memory = new Memory<char>(string_01.ToCharArray());

            string string_01_cloned = string_01.Clone();
            string string_01_cloned = string_01.CompareTo("a");
            string string_01_cloned = string_01.Contains("a");

            string string_01_cloned = string_01.EndsWith("a");
            string string_01_cloned = string_01.Equals("a");
            string string_01_cloned = string_01.GetEnumerator("a");
            string string_01_cloned = string_01.GetHashCode("a");
            string string_01_cloned = string_01.GetType("a");
            string string_01_cloned = string_01.GetTypeCode("a");
            string string_01_cloned = string_01.IndexOf("a");
            string string_01_cloned = string_01.IndexOfAny("a");
            string string_01_cloned = string_01.Insert("a");
            string string_01_cloned = string_01.IsNormalized("a");
            string string_01_cloned = string_01.LastIndexOf("a");
            string string_01_cloned = string_01.LastIndexOfAny("a");
            string string_01_cloned = string_01.Length;
            string string_01_cloned = string_01.Normalize();
            string string_01_cloned = string_01.PadLeft("a");
            string string_01_cloned = string_01.PadRight("a");
            string string_01_cloned = string_01.Remove("a");
            string string_01_cloned = string_01.Replace();
            string string_01_cloned = string_01.Split();
            string string_01_cloned = string_01.StartsWith();
            string string_01_cloned = string_01.Substring();
            string string_01_cloned = string_01.ToCharArray();
            string string_01_cloned = string_01.ToLower();
            string string_01_cloned = string_01.ToLowerInvariant();
            string string_01_cloned = string_01.ToString();
            string string_01_cloned = string_01.ToUpper();
            string string_01_cloned = string_01.ToUpperInvariant();
            string string_01_cloned = string_01.Trim();
            string string_01_cloned = string_01.TrimEnd();
            string string_01_cloned = string_01.TrimStart();

            string joined = string.Join(",",new string[] { "a", "b"});
            string joined = string.Compare(",", "");
            string joined = string.CompareOrdinal(",", "");
            string joined = string.Concat("", "", "", "");
            string joined = string.Copy("");
            string joined = string.Create();
            string joined = string.Empty;
            string joined = string.Equals("", "");
            string joined = string.Format("", "", "", "");
            string joined = string.Intern();
            string joined = string.IsInterned();

            string joined = string.IsNullOrEmpty()
            string joined = string.IsNullOrWhiteSpace();
            string joined = string.Join(",",new string[] { "a", "b"});
            string joined = string.ReferenceEquals();

            Memory<char> m1 = new Memory<char>();
            Memory<char>.Empty;











            return;
        }    }}