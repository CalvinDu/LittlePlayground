using System;
using Xunit;
using LeetCode;

namespace LeetCode.Tests
{
    public class q1Test
    {
        private readonly q1 _q1;

        public q1Test()
        {
            _q1 = new q1();
        }
        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, 2)]
        [InlineData(new int[] { 1, 1, 2, 2, 3, 5, 7, 7, 7, 8 }, 6)]
        [InlineData(new int[] { }, 0)]
        public void Test1(int[] input , int length)
        {
            var result = _q1.RemoveDuplication(input);
            Assert.Equal<int>(length,result);
        }
    }
}
