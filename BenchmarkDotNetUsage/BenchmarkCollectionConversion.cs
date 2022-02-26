using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetUsage
{
    [MemoryDiagnoser]
    [RPlotExporter, RankColumn]
    public class BenchmarkCollectionConversion
    {
        [Params(100, 1000)]
        public int N { get; set; }

        public int[] arrayInts { get; set; }
        public List<int> listInts { get; set; }
        public IQueryable<int> queryableInts { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            arrayInts = new int[N];
            listInts = new List<int>();
            
            for (int i = 0; i < N; i++)
            {
                arrayInts[i] = i + 1;
                listInts.Add(i + 1);
            }

            queryableInts = listInts.AsQueryable();
        }

        //[Benchmark(Baseline = true)]
        //public void ArrayToList() => arrayInts.ToList();
        //[Benchmark]
        //public void ArrayToEnumerable() => arrayInts.AsEnumerable();
        //[Benchmark]
        //public void ArrayToQueryable() => arrayInts.AsQueryable();

        //[Benchmark]
        //public void ListToArray() => listInts.ToArray();
        //[Benchmark]
        //public void ListToEnumerable() => listInts.AsEnumerable();
        //[Benchmark]
        //public void ListToQueryable() => listInts.AsQueryable();

        [Benchmark(Baseline = true)]
        public void QueryableToArray() => queryableInts.ToArray();
        [Benchmark]
        public void QueryableToList() => queryableInts.ToList();
        [Benchmark]
        public void QueryableToEnumerable() => queryableInts.AsEnumerable();
    }
}
