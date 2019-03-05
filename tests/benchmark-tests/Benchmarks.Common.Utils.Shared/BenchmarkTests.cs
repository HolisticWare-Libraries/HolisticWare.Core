// /*
//    Copyright (c) 2018-5
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
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
using TestFixture = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
// XUnit aliases
using Fact=NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
// XUnit aliases
using TestFixture = Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute;
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

using System.Linq;
using UnitTests.Core.Math.Statistics.Descriptive.Sequential.Sync;
using System.IO;
using System.Reflection;
using System;

namespace Benchmarks.CommonShared
{
    [TestFixture]
    public class BenchmarkTests
    {
        [Test]
        public void Benchmark_Tests20180119Dataset01()
        {
            BenchmarkRunner
                .Run<Tests20180119Dataset01>
                (
                    ManualConfig
                    .Create(new Config())
                    //.WithLaunchCount(1)     // benchmark process will be launched only once
                    //.WithIterationTime(100) // 100ms per iteration
                    //.WithWarmupCount(3)     // 3 warmup iteration
                    //.WithTargetCount(3)     // 3 target iteration
                    //.With(BenchmarkDotNet.Jobs.Job.RyuJitX64)
                    //.With(BenchmarkDotNet.Jobs.Job.Core)
                    //.With(BenchmarkDotNet.Validators.ExecutionValidator.FailOnError)
                    .WithArtifactsPath
                    (
                        #if NUNIT
                        TestContext.CurrentContext.TestDirectory
                        #elif XUNIT
                        Environment.CurrentDirectory
                        #elif MSTEST
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        #endif
                    )
                );

            return;
        }

        [Test()]
        public void Benchmark_Tests20180119Dataset02()
        {
            BenchmarkRunner
                .Run<Tests20180119Dataset02>
                (
                    ManualConfig
                    .Create(new Config())
                    //.WithLaunchCount(1)     // benchmark process will be launched only once
                    //.WithIterationTime(100) // 100ms per iteration
                    //.WithWarmupCount(3)     // 3 warmup iteration
                    //.WithTargetCount(3)     // 3 target iteration
                    //.With(BenchmarkDotNet.Jobs.Job.RyuJitX64)
                    //.With(BenchmarkDotNet.Jobs.Job.Core)
                    //.With(BenchmarkDotNet.Validators.ExecutionValidator.FailOnError)
                    .WithArtifactsPath
                    (
                        #if NUNIT
                        TestContext.CurrentContext.TestDirectory
                        #elif XUNIT
                        Environment.CurrentDirectory
                        #elif MSTEST
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        #endif
                    )
                );

            return;
        }

        [Test()]
        public void Benchmark_Tests20180119Dataset03()
        {
            BenchmarkRunner
                .Run<Tests20180119Dataset03>
                (
                    ManualConfig
                    .Create(new Config())
                    //.WithLaunchCount(1)     // benchmark process will be launched only once
                    //.WithIterationTime(100) // 100ms per iteration
                    //.WithWarmupCount(3)     // 3 warmup iteration
                    //.WithTargetCount(3)     // 3 target iteration
                    //.With(BenchmarkDotNet.Jobs.Job.RyuJitX64)
                    //.With(BenchmarkDotNet.Jobs.Job.Core)
                    //.With(BenchmarkDotNet.Validators.ExecutionValidator.FailOnError)
                    .WithArtifactsPath
                    (
                        #if NUNIT
                        TestContext.CurrentContext.TestDirectory
                        #elif XUNIT
                        Environment.CurrentDirectory
                        #elif MSTEST
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        #endif
                    )
                );

            return;
        }

        [Test()]
        public void UnitTests20180227DataSet001()
        {
            BenchmarkRunner
                .Run<UnitTests20180227DataSet001>
                (
                    ManualConfig
                    .Create(new Config())
                    //.WithLaunchCount(1)     // benchmark process will be launched only once
                    //.WithIterationTime(100) // 100ms per iteration
                    //.WithWarmupCount(3)     // 3 warmup iteration
                    //.WithTargetCount(3)     // 3 target iteration
                    //.With(BenchmarkDotNet.Jobs.Job.RyuJitX64)
                    //.With(BenchmarkDotNet.Jobs.Job.Core)
                    //.With(BenchmarkDotNet.Validators.ExecutionValidator.FailOnError)
                    .WithArtifactsPath
                    (
                        #if NUNIT
                        TestContext.CurrentContext.TestDirectory
                        #elif XUNIT
                        Environment.CurrentDirectory
                        #elif MSTEST
                        Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                        #endif
                    )
                );

            return;
        }

    }

    public class Config : BenchmarkDotNet.Configs.ManualConfig
    {
        public Config()
        {
            /*
            [ArtifactsPath(".")]

            OneTimeSetUp: System.TypeInitializationException : 
            The type initializer for
                'UnitTests.Core.Math.Statistics.Descriptive.Sequential.Sync.Tests20180119Dataset01'
                threw an exception.
              ---- > System.UnauthorizedAccessException : 
                        Access to the path "/BenchmarkDotNet.Artifacts" is denied.


            OneTimeSetUp: System.TypeInitializationException : 
            The type initializer for
                threw an exception.
              ---- > System.UnauthorizedAccessException : 
                        Access to the path "/BenchmarkDotNet.Artifacts" is denied.
            */

            #if NUNIT
            string path = TestContext.CurrentContext.TestDirectory;
            #elif XUNIT
            string path = Environment.CurrentDirectory;
            #elif MSTEST
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            #endif

            ArtifactsPath = path;

            //No exporters defined, results will not be persisted.
            Add(DefaultConfig.Instance.GetExporters().ToArray());
            //No loggers defined, you will not see any progress!
            Add(DefaultConfig.Instance.GetLoggers().ToArray());
            //No column providers defined, result table will be empty.
            Add(DefaultConfig.Instance.GetColumnProviders().ToArray());            

            return;
        }
    }
}
