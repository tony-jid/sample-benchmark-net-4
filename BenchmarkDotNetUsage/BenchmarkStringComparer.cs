using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetUsage
{
    //[ClrJob(baseline: true), CoreJob, MonoJob, CoreRtJob]
    [MemoryDiagnoser]
    [RPlotExporter, RankColumn]
    public class BenchmarkStringComparer
    {
        [Params(100, 1000)]
        public int N { get; set; }

        public string comparer = "Benchmarking is really hard (especially microbenchmarking), you can easily make a mistake during performance measurements.";
        public string comparee = "benchmarking";

        [GlobalSetup]
        public void Setup()
        {
            //data = new byte[N];
            //new Random(42).NextBytes(data);
        }

        [Benchmark(Baseline = true)]
        public void ContainsIgnoreCaseByToLower()
        {
            for (int i = 0; i < N; i++)
            {
                StringComparer.ContainsIgnoreCaseByToLower(comparer, comparee);
            }
        }

        [Benchmark]
        public void ContainsIgnoreCaseByIndexOf()
        {
            for (int i = 0; i < N; i++)
            {
                StringComparer.ContainsIgnoreCaseByIndexOf(comparer, comparee);
            }
        }
    }
}
