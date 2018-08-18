using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BinSearch {
    class Utils {
        public static bool BinSearchResult(int[] srcArr, int target) {
            int low = 0, high = srcArr.Length - 1;
            while (low <= high) {
                int mid = low + (high - low) / 2;

                if (srcArr[mid] == target) {
                    return true;
                } else if (srcArr[mid] > target) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            }
            return false;
        }
    }
}
