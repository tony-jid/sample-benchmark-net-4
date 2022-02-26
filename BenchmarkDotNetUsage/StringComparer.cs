using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkDotNetUsage
{
    public static class StringComparer
    {
        public static bool ContainsIgnoreCaseByToLower(this string comparer, string comparee) {
            return comparer.ToLower().Contains(comparee.ToLower());
        }

        public static bool ContainsIgnoreCaseByIndexOf(this string comparer, string comparee)
        {
            return comparer.IndexOf(comparee, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
