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

        public static int Smooth(int[,] M, int i, int j) {
            int mRow = M.GetLength(0), mCol = M.GetLength(1);
            if (!IsValid(i, mRow) || !IsValid(j, mCol)) {
                return 0;
            }

            int sum = 0, count = 0;
            for (int n = -1; n <= 1; n++) {
                for (int m = -1; m <= 1; m++) {
                    if (IsValid(i + n, mRow) && IsValid(j + m, mCol)) {
                        sum += M[i + n, j + m];
                        count++;
                    }
                }
            }

            return sum / count;
        }

        public static bool IsValid(int i, int length) {
            return (i <= length - 1 && i >= 0);
        }

        public static int AreaOfIsland(int[,] grid, int i, int j) {
            int row = grid.GetLength(0), col = grid.GetLength(1);

            if (IsValid(i, row) && IsValid(j, col) && grid[i, j] == 1) {
                grid[i, j] = 0; //  in case of recounting
                return 1 + AreaOfIsland(grid, i - 1, j) + AreaOfIsland(grid, i + 1, j) + AreaOfIsland(grid, i, j - 1) + AreaOfIsland(grid, i, j + 1);
            } else {
                return 0;
            }
        }

        public static int RangeSum(int[] nums, int startIndex, int endIndex) {
            if (startIndex < 0 || startIndex > endIndex || nums.Length - 1 < endIndex)
                return 0;
            int sum = 0;
            for (int i = startIndex; i <= endIndex; i++) {
                sum += nums[i];
            }
            return sum;
        }
    }
}
