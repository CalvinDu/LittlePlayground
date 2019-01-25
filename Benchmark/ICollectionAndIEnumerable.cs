using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [ClrJob(baseline: true)]
    public class ICollectionAndIEnumerable
    {
        private IEnumerable<int> enumerable;
        private ICollection<int> collection;
        private List<int> list = new List<int>();

        [Params(100000)]
        public int N;

        [Params(1000)]
        public int C;

        [GlobalSetup]
        public void Setup()
        {
            for (var i = 0; i < N; i++)
            {
                list.Add(i);
            }
            enumerable = list;
            collection = list;
        }

        [Benchmark]
        public void CountEnumerable()
        {
            int count;
            for (var i = 0; i < C; i++)
            {
                count = enumerable.Count();
            }
        }

        [Benchmark]
        public void CountCollection()
        {
            int count;
            for (var i = 0; i < C; i++)
            {
                count = collection.Count;
            }
        }
    }
}
