using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    public class q2
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>(nums);
            foreach (var item in set)
                Console.WriteLine(item);
            Console.WriteLine($"{set.Count }, { nums.Length}, {set.Count == nums.Length}");
            return set.Count != nums.Length;
        }
    }
}
