using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ArrayAlgorithm {
    class Utils {
        public static void ArrReverse(int[] nums, int start, int end) {
            if (start >= end) return; 
            while (start < end) {
                nums[start] += nums[end];
                nums[end] = nums[start] - nums[end];
                nums[start] = nums[start] - nums[end];
                start++;
                end--;
            }
        }
    }
}
