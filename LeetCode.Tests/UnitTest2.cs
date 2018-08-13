using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.Tests
{
    public class UnitTest2
    {
        private readonly q2 _q2;
        public UnitTest2()
        {
            _q2 = new q2();
        }
        [Theory]
        [InlineData(new int[] { 1,2,3,1}, true)]
        public void Test(int[] nums, bool expect)
        {
            var result = _q2.ContainsDuplicate(nums);
            Assert.Equal(expect, result);
        }
    }
}
