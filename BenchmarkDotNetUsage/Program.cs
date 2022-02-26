using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BenchmarkStringComparer>();
            //var summary = BenchmarkRunner.Run<BenchmarkCollectionConversion>();
            
            Console.ReadLine();
        }
    }
}
