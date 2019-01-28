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

        [Params(1000)]
        public int N;

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
        public bool EnumerableAny1()
        {
            return enumerable.Any();
        }

        [Benchmark]
        public bool EnumerableAny2()
        {
            return enumerable.Count() != 0;
        }

        [Benchmark]
        public bool CollectionAny2()
        {
            return collection.Count != 0;
        }

        [Benchmark]
        public bool CollectionAny1()
        {
            return collection.Any();
        }
    }
}
