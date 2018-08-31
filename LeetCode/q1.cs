using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class q1
    {
        public int RemoveDuplication(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int _index = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i-1])
                    nums[_index++] = nums[i];                    
            }
            for (var i = 0; i<_index;i++)
            {
                Console.WriteLine(nums[i]);
            }
            
            return _index;
        }
    }
}
