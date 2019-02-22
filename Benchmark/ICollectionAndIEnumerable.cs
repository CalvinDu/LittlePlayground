using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [ClrJob(baseline: true)][MemoryDiagnoser]
    public class ICollectionAndIEnumerable
    {
        private IEnumerable<int> enumerable;
        private ICollection<int> collection;
        private List<int> list = new List<int>();
        private int[] array;
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
            array = list.ToArray();
        }

        public bool EnumerableAny1()
        {
            return enumerable.Any();
        }


        public bool EnumerableAny2()
        {
            return enumerable.Count() != 0;
        }


        public bool CollectionAny2()
        {
            return collection.Count != 0;
        }


        public bool CollectionAny1()
        {
            return collection.Any();
        }
        [Benchmark]
        public void EnumerableGetAt()
        {
            var result = enumerable.ElementAt(N / 2);
        }
        [Benchmark]
        public void CollectionGetAt()
        {
            var result = collection.ElementAt(N/2);
        }
        [Benchmark]
        public void ListGetAt()
        {
            var result = list[N / 2];
        }
        [Benchmark]
        public void ArrayGetAt()
        {
            var result = array[N / 2];
        }
    }
}
