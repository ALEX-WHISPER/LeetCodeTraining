using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ArrayAlgorithm {
    class ArrayProblems {
        public static int[] TwoSum(int[] nums, int target) {
            #region dictionary
            Dictionary<int, int> _dic = new Dictionary<int, int>();
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++) {
                if (!_dic.ContainsKey(nums[i]) && !_dic.ContainsKey(target - nums[i]))
                    _dic.Add(target - nums[i], i);
                else {
                    res[0] = _dic[nums[i]];
                    res[1] = i;
                }
            }
            return res;
            #endregion
        }

        /// <summary>
        /// Given a sorted array nums, remove the duplicates in-place such that each element appear only once and return the new length
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicates(int[] nums) {
            if (nums.Length <= 1) return nums.Length;
            int id = 1;
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] != nums[i - 1]) nums[id++] = nums[i];
            }
            for (int i = 0; i < id; i++) {
                Console.Write(nums[i] + " ");
            }
            return id;
        }

        /// <summary>
        /// Given an array nums and a value val, remove all instances of that value in-place and return the new length.
        /// Do not allocate extra space for another array, you must do this by modifying the input array in-place with O(1) extra memory.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int RemoveElement(int[] nums, int val) {
            int id = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != val) {
                    if (nums[id] == val) {
                        nums[id] = nums[i] + nums[id]; nums[i] = nums[id] - nums[i]; nums[id] = nums[id] - nums[i];
                    }
                    id++;
                }
            }

            for (int i = 0; i < id; i++) {
                Console.Write(nums[i] + " ");
            }
            return id;
        }

        /// <summary>
        /// Given a non-empty array of digits representing a non-negative integer, plus one to the integer.
        /// The digits are stored such that the most significant digit is at the head of the list, and each element in the array contain a single digit.
        /// You may assume the integer does not contain any leading zero, except the number 0 itself.
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int[] PlusOne(int[] digits) {
            #region ugly version
            //int n = digits.Length + 1;
            //int[] res = new int[n];
            //Array.Copy(digits, 0, res, 1, digits.Length);

            //if (res[n - 1] < 9) {
            //    res[n - 1]++;
            //} else {
            //    res[n - 1] = 0; res[n - 2]++;
            //    for (int i = n - 2; i > 0; i--) {
            //        if (res[i] <= 9)  break;
            //        else {
            //            res[i] = 0; res[i - 1]++;
            //        }
            //    }
            //}

            //if (res[0] == 0) {
            //    Array.Copy(res, 1, digits, 0, digits.Length);
            //    return digits;
            //} else {
            //    return res;
            //}
            #endregion
            #region beautiful version
            int n = digits.Length;
            for (int i = n - 1; i >= 0; i--) {
                if (digits[i] < 9) {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            int[] res = new int[n + 1];
            res[0] = 1;
            return res;
            #endregion
        }

        /// <summary>
        /// Given two sorted integer arrays nums1 and nums2, merge nums2 into nums1 as one sorted array.
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public static void Merge(int[] nums1, int m, int[] nums2, int n) {
            int pa = m - 1, pb = n - 1, pc = m + n - 1;
            while (pa >= 0 && pb >= 0) {
                if (nums1[pa] > nums2[pb])
                    nums1[pc--] = nums1[pa--];
                else
                    nums1[pc--] = nums2[pb--];
            }
            while (pb >= 0) {
                nums1[pc--] = nums2[pb--];
            }

            foreach (var item in nums1) {
                Console.Write(item.ToString() + " ");
            }
        }

        /// <summary>
        /// Given a non-negative integer numRows, generate the first numRows of Pascal's triangle.
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public static IList<IList<int>> Generate(int numRows) {
            IList<IList<int>> res = new List<IList<int>>();
            IList<int> row = new List<int>();

            for (int i = 0; i < numRows; i++) {
                row.Insert(0, 1);
                for (int j = 1; j < row.Count - 1; j++) {
                    row[j] += row[j + 1];
                }
                res.Add(new List<int>(row));    //  create a new instance to store the values of current row, otherwise all elements in [res] will be the same cause row is a reference type
            }
            
            return res;
        }

        /// <summary>
        /// Given a non-negative index k where k ≤ 33, return the kth index row of the Pascal's triangle. 
        /// Note that the row index starts from 0.
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public static IList<int> GetRow(int rowIndex) {
            IList<int> tarRow = new List<int>();

            for (int i = 0; i <= rowIndex; i++) {
                tarRow.Insert(0, 1);
                for (int j = 1; j < tarRow.Count - 1; j++) {
                    tarRow[j] += tarRow[j + 1];
                }
            }
            return tarRow;
        }

        /// <summary>
        /// Say you have an array for which the ith element is the price of a given stock on day i.
        /// Design an algorithm to find the maximum profit.You may complete as many transactions as you like
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public static int MaxProfit(int[] prices) {
            int minPrice = int.MaxValue;
            int tran = 0, res = 0;

            for (int i = 0; i < prices.Length; i++) {
                minPrice = Math.Min(prices[i], minPrice);
                tran = Math.Max(tran, prices[i] - minPrice);

                if (tran > 0) {
                    minPrice = prices[i];
                    res += tran;
                    tran = 0;
                }
            }

            return res;
        }

        /// <summary>
        /// Input: [1,2,3,4,5,6,7] and k = 3
        /// Output: [5,6,7,1,2,3,4]
        /// Explanation:
        /// rotate 1 steps to the right: [7,1,2,3,4,5,6]
        /// rotate 2 steps to the right: [6,7,1,2,3,4,5]
        /// rotate 3 steps to the right: [5,6,7,1,2,3,4]
        /// do it with O(1) extra space
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static void Rotate(int[] nums, int k) {
            #region O(1) space, O(n^2) time
            //int n = 0;
            //while (n < k) {
            //    for (int i = nums.Length - 1; i > 0; i--) {
            //        nums[i] += nums[i - 1];
            //        nums[i - 1] = nums[i] - nums[i - 1];
            //        nums[i] = nums[i] - nums[i - 1];
            //    }
            //    n++;
            //}
            #endregion

            #region O(0) space, O(n) time, using API
            Array.Reverse(nums, 0, nums.Length);
            Array.Reverse(nums, 0, k % nums.Length);
            Array.Reverse(nums, k % nums.Length, nums.Length - k % nums.Length);
            #endregion

            #region O(0) space, O(n) time, implement reverse
            k = k % nums.Length;
            Utils.ArrReverse(nums, 0, nums.Length - 1);
            Utils.ArrReverse(nums, 0, k - 1);
            Utils.ArrReverse(nums, k, nums.Length - 1);
            #endregion

            for (int i = 0; i < nums.Length; i++) {
                Console.Write(nums[i] + " ");
            }
        }

        /// <summary>
        /// Given an array of integers, find if the array contains any duplicates.
        /// Your function should return true if any value appears at least twice in the array, and it should return false if every element is distinct.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool ContainsDuplicate(int[] nums) {
            HashSet<int> set = new HashSet<int>();
            
            for (int i = 0; i < nums.Length; i++) {
                if (set.Contains(nums[i])) return true;
                set.Add(nums[i]);
            }
            return false;
        }

        /// <summary>
        /// Given an array of integers and an integer k, 
        /// find out whether there are two distinct indices i and j in the array such that nums[i] = nums[j] and the absolute difference between i and j is at most k.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static bool ContainsNearbyDuplicate(int[] nums, int k) {
            Dictionary<int, int> _dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) {
                if (_dic.ContainsKey(nums[i])) {
                    if (Math.Abs(_dic[nums[i]] - i) <= k) return true;
                    _dic[nums[i]] = i;
                } 
                else
                    _dic.Add(nums[i], i);
            }
            return false;
        }

        /// <summary>
        /// Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MissingNumber(int[] nums) {
            #region sum
            //int sum = (1 + nums.Length) * nums.Length / 2;
            //for (int i = 0; i < nums.Length; i++) {
            //    sum -= nums[i];
            //}
            //return sum;
            #endregion

            #region sort
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] != i) return i;
            }
            return 0;
            #endregion
        }

        /// <summary>
        /// Given a binary array, find the maximum number of consecutive 1s in this array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMaxConsecutiveOnes(int[] nums) {
            int sum = 0, max = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] == 0) {
                    max = Math.Max(sum, max);
                    sum = 0;
                } else
                    sum++;
            }
            return Math.Max(sum,max);
        }

        /// <summary>
        /// In a row of seats, 1 represents a person sitting in that seat, and 0 represents that the seat is empty. 
        /// There is at least one empty seat, and at least one person sitting.
        /// Alex wants to sit in the seat such that the distance between him and the closest person to him is maximized.
        /// Return that maximum distance to closest person.
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public static int MaxDistToClosest(int[] seats) {
            List<int> ls_occup = new List<int>();
            
            for (int i = 0; i < seats.Length; i++) {
                if (seats[i] == 1) ls_occup.Add(i);
            }

            int dist = 0;

            //  所有被占座位之中的最大距离
            for (int i = ls_occup.Count - 1; i > 0; i--) {
                int curDist = (ls_occup[i] - ls_occup[i - 1]) / 2;
                dist = Math.Max(dist, curDist);
            }

            int firstStep = ls_occup[0];    //  第一个空闲座位与第一个被占座位的距离
            int lastStep = (seats.Length - 1) - ls_occup[ls_occup.Count - 1];   //  最后一个被占的座位与最后一个空闲座位的距离
            int largerStep = Math.Max(firstStep, lastStep);

            return Math.Max(dist, largerStep);
        }

        /// <summary>
        /// Given an array of 2n integers, your task is to group these integers into n pairs of integer, say (a1, b1), (a2, b2), ..., (an, bn) which makes sum of min(ai, bi) for all i from 1 to n as large as possible.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ArrayPairSum(int[] nums) {
            Array.Sort(nums);
            int res = 0;
            for (int i = 0; i < nums.Length; i += 2) {
                res += nums[i];
            }
            return res;
        }

        /// <summary>
        /// You're given a matrix represented by a two-dimensional array, and two positive integers r and c representing the row number and column number of the wanted reshaped matrix, respectively.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int[,] MatrixReshape(int[,] nums, int r, int c) {
            #region clumsy
            //if (nums.Length != r * c) return nums;

            //List<int> _ls = new List<int>();
            //for (int i = 0; i < nums.GetLength(0); i++) {
            //    for (int j = 0; j < nums.GetLength(1); j++) {
            //        _ls.Add(nums[i, j]);
            //    }
            //}

            //int[,] res = new int[r, c];
            //for (int i = 0; i < r; i++) {
            //    for (int j = 0; j < c; j++) {
            //        res[i, j] = _ls[i * c + j];
            //    }
            //}
            //return res;
            #endregion

            #region concise
            int n = nums.GetLength(0), m = nums.GetLength(1);
            if (n * m != r * c) return nums;

            int[,] res = new int[r, c];
            for (int i = 0; i < r * c; i++) {
                res[i / c, i % c] = nums[i / m, i % m];
            }
            return res;
            #endregion
        }

        /// <summary>
        /// https://leetcode.com/problems/can-place-flowers/description/
        /// </summary>
        /// <param name="flowerbed"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool CanPlaceFlowers(int[] flowerbed, int n) {
            #region stupid: find all 1s' index, count how many flowers could place between each pair of adjacent occupied flower
            //List<int> ls_occup = new List<int>();
            //for (int i = 0; i < flowerbed.Length; i++) {
            //    if (flowerbed[i] == 1) ls_occup.Add(i);
            //}
            //if (ls_occup.Count < 1) return flowerbed.Length >= 2 * n - 1;

            //int count = 0;
            //for (int i = ls_occup.Count - 1; i > 0; i--) {
            //    int curDist = (ls_occup[i] - ls_occup[i - 1]) - 2;
            //    count += curDist / 2;
            //}

            //if (ls_occup[0] != 0) {
            //    int firstStep = ls_occup[0];
            //    count += firstStep / 2;
            //}
            //if (ls_occup[ls_occup.Count - 1] != flowerbed.Length - 1) {
            //    int lastStep = flowerbed.Length - 1 - ls_occup[ls_occup.Count - 1];
            //    count += lastStep / 2;
            //}
            //return count >= n;
            #endregion

            #region neat: find the adjacent flowers for each element, if both of them are 0, then this place can be plant, set it to 1 and count in
            int count = 0;
            for (int i = 0; i < flowerbed.Length && count < n; i++) {
                if (flowerbed[i] == 0) {
                    int next = (i == flowerbed.Length - 1) ? 0 : flowerbed[i + 1];
                    int pre = i == 0 ? 0 : flowerbed[i-1];
                    if (next == 0 && pre == 0) {
                        flowerbed[i] = 1;
                        count++;
                    }
                }
            }
            return count == n;
            #endregion
        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-product-of-three-numbers/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaximumProduct(int[] nums) {
            #region time complexity: O(nlogn), using Array.Sort()
            //Array.Sort(nums);
            //int n = nums.Length;
            ////  最大乘积: nums[n-1] * nums[n-2] * nums[n-3] || nums[n-1] * nums[0] * nums[1]; (-2,-1,3,4,60 || -4,-3,-2,-1,60)
            //return Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3], nums[n - 1] * nums[1] * nums[0]);
            #endregion

            #region time complexity: O(n), find the 3 max and the 2 min manually
            int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;
            int min1 = int.MaxValue, min2 = int.MaxValue;

            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] > max1) {
                    max3 = max2; max2 = max1;
                    max1 = nums[i];
                } else if (nums[i] > max2) {
                    max3 = max2;
                    max2 = nums[i];
                } else if (nums[i] > max3) {
                    max3 = nums[i];
                }

                if (nums[i] < min1) {
                    min2 = min1;
                    min1 = nums[i];
                } else if (nums[i] < min2) {
                    min2 = nums[i];
                }
            }

            return Math.Max(max1*max2*max3, max1*min1*min2);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[][] Transpose(int[][] A) {
            if (A.Length < 1) {
                return A;
            }

            int[][] res = new int[A[0].Length][];
            for (int i = 0; i < res.Length; i++) {
                res[i] = new int[A.Length];
            }

            for (int i = 0; i < res.Length; i++) {
                for (int j = 0; j < res[i].Length; j++) {
                    res[i][j] = A[j][i];
                }
            }

            for (int i = 0; i < res.Length; i++) {
                for (int j = 0; j < res[i].Length; j++) {
                    Console.Write(res[i][j] + " ");
                }
                Console.WriteLine("");
            }
            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/maximum-average-subarray-i/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double FindMaxAverage(int[] nums, int k) {
            int sum = 0;

            //  add up the first 4 elements
            for (int i = 0; i < k; i++) {
                sum += nums[i];
            }

            //  sliding window, move forward if the latter one is bigger
            int max = sum;
            for (int i = k; i < nums.Length; i++) {
                sum -= nums[i - k];
                sum += nums[i];
                max = Math.Max(max, sum);
            }
            return max / 1.0 / k;
        }

        /// <summary>
        /// https://leetcode.com/problems/image-smoother/description/
        /// </summary>
        /// <param name="M"></param>
        /// <returns></returns>
        public static int[,] ImageSmoother(int[,] M) {
            int row = M.GetLength(0), col = M.GetLength(1);
            int[,] res = new int[row, col];

            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    res[i, j] = Utils.Smooth(M, i, j);
                }
            }
            
            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/longest-continuous-increasing-subsequence/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindLengthOfLCIS(int[] nums) {
            if (nums.Length < 1)
                return 0;
            int res = 1, len = 1;
            for (int i = 0; i < nums.Length - 1; i++) {
                len = nums[i + 1] > nums[i] ? len + 1 : 1;
                res = Math.Max(res, len);
            }
            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/max-area-of-island/description/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public static int MaxAreaOfIsland(int[,] grid) {
            int area, max = 0;
            for (int i = 0; i < grid.GetLength(0); i++) {
                for (int j = 0; j < grid.GetLength(1); j++) {
                    area = Utils.AreaOfIsland(grid, i, j);  //  dfs(depth-first-search)
                    max = Math.Max(max, area);
                }
            }
            return max;
        }

        /// <summary>
        /// https://leetcode.com/problems/degree-of-an-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindShortestSubArray(int[] nums) {
            int degree = 1, len = nums.Length;
            
            Dictionary<int, int[]> _dic = new Dictionary<int, int[]>();
            for (int i = 0; i < nums.Length; i++) {
                int num = nums[i];
                if (_dic.ContainsKey(num)) {
                    _dic[num][0]++;
                    _dic[num][2] = i;
                } else {
                    _dic.Add(num, new int[] { 1, i, i });   //  first: elem degree, second: the first index, thrid: the last index
                }
                degree = Math.Max(degree, _dic[num][0]);    //  degree of the whole array
            }

            foreach (var key in _dic.Keys) {
                int[] val = _dic[key];
                if (val[0] == degree) {
                    len = Math.Min(val[2] - val[1] + 1, len);
                }
            }
            
            return len;
        }

        /// <summary>
        /// https://leetcode.com/problems/1-bit-and-2-bit-characters/description/
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static bool IsOneBitCharacter(int[] bits) {
            int p = 0;
            while (p < bits.Length - 1) {
                if (bits[p] == 0) p += 1;
                else p += 2;
            }
            return p == bits.Length - 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/find-pivot-index/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int PivotIndex(int[] nums) {
            int sum = 0, half = 0;
            for (int i = 0; i < nums.Length; i++) {
                sum += nums[i];
            }

            for (int i = 0; i < nums.Length; i++) {
                if (sum == half * 2 + nums[i])
                    return i;
                half += nums[i];
            }
            return -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/largest-number-at-least-twice-of-others/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int DominantIndex(int[] nums) {
            int max1 = int.MinValue, max2 = int.MinValue;
            int index = 0;
            for (int i = 0; i < nums.Length; i++) {
                if (nums[i] > max1) {
                    max2 = max1;
                    max1 = nums[i];
                    index = i;
                } else if (nums[i] > max2)
                    max2 = nums[i];
            }
            //Console.WriteLine("max1: {0}, max2: {1}", max1, max2);
            return max1 >= max2 * 2 ? index : -1;
        }

        /// <summary>
        /// https://leetcode.com/problems/toeplitz-matrix/description/
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static bool IsToeplitzMatrix(int[,] matrix) {
            int row = matrix.GetLength(0), col = matrix.GetLength(1);
            for (int i = 0; i < row; i++) {
                if (!Utils.IsValid(i + 1, row)) continue;

                for (int j = 0; j < col; j++) {
                    if (!Utils.IsValid(j + 1, col))  continue;

                    if (matrix[i, j] != matrix[i + 1, j + 1])  return false;
                }
            }
            return true;
        }

        /// <summary>
        /// https://leetcode.com/problems/positions-of-large-groups/description/
        /// </summary>
        /// <param name="S"></param>
        /// <returns></returns>
        public static IList<IList<int>> LargeGroupPositions(string S) {
            string str = string.Concat(S, "A");
            char curChar = S[0];
            int count = 0;
            IList<IList<int>> res = new List<IList<int>>();

            for (int i = 0; i < str.Length; i++) {
                char c = str[i];
                if (c != curChar) {
                    curChar = c;
                    if (count >= 3) res.Add(new List<int> { i-count, i-1 });
                    count = 1;
                } else {
                    count++;
                }
            }
            
            return res;
        }

        /// <summary>
        /// https://leetcode.com/problems/flipping-an-image/description/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int[][] FlipAndInvertImage(int[][] A) {
            int row = A.Length, col = A[0].Length;
            for (int i = 0; i < row; i++) {
                for (int j = col - 1; j >= col / 2; j--) {
                    int left = col - 1 - j, right = j;
                    if (A[i][left] == A[i][right])
                        continue;
                    int temp = A[i][left];
                    A[i][left] = A[i][right];
                    A[i][right] = temp;
                }
            }

            for (int i = 0; i < row; i++) {
                for (int j = 0; j < col; j++) {
                    A[i][j] = A[i][j] == 0 ? 1 : 0;
                }
            }
            
            return A;
        }

        /// <summary>
        /// https://leetcode.com/problems/fair-candy-swap/description/
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int[] FairCandySwap(int[] A, int[] B) {
            int sumA = 0, sumB = 0, average = 0, diff = 0;
            foreach (int a in A) { sumA += a; }
            foreach (int b in B) { sumB += b; }
            average = (sumA + sumB) / 2;
            diff = sumA - average;

            for (int i = 0; i < A.Length; i++) {
                for (int j = 0; j < B.Length; j++) {
                    if (A[i] - B[j] == diff) {
                        return new int[] { A[i], B[j] };
                    }
                }
            }

            return null;
        }

        #region the last part
        /// <summary>
        /// https://leetcode.com/problems/min-cost-climbing-stairs/description/
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static int MinCostClimbingStairs(int[] cost) {
            int n = cost.Length;
            int[] dp = new int[n];
            dp[0] = cost[0]; dp[1] = cost[1];
            for (int i = 2; i < n; i++) {
                dp[i] = cost[i] + Math.Min(dp[i-1], dp[i-2]);
            }
            return Math.Min(dp[n-1], dp[n-2]);
        }

        /// <summary>
        /// https://leetcode.com/problems/third-maximum-number/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int ThirdMax(int[] nums) {
            int? max1 = null, max2 = null, max3 = null;
            for (int i = 0; i < nums.Length; i++) {
                int num = nums[i];
                if (num.Equals(max1) || num.Equals(max2) || num.Equals(max3))
                    continue;
                if (max1 == null || num > max1) {
                    max3 = max2; max2 = max1; max1 = num;
                } else if (max2 == null || num > max2) {
                    max3 = max2; max2 = num;
                } else if (max3 == null || num > max3) {
                    max3 = num;
                }
            }
            return max3 == null ? (int)max1 : (int)max3;
        }

        /// <summary>
        /// https://leetcode.com/problems/non-decreasing-array/description/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool CheckPossibility(int[] nums) {
            #region clumzy
            //int pa = 0, pb = nums.Length - 1;
            //while (pa < nums.Length - 1) {
            //    if (nums[pa + 1] >= nums[pa]) pa++;
            //    else break;
            //}

            //while (pb > 0) {
            //    if (nums[pb - 1] <= nums[pb]) pb--;
            //    else break;
            //}

            ////  completely ascending
            //if (pa == nums.Length - 1 && pb == 0) {
            //    return true;
            //}

            //else {
            //    if ((pb - pa) > 1) return false;
            //    if (pa > 0 && pb < nums.Length - 1)
            //        return nums[pa - 1] <= nums[pb] || nums[pa] <= nums[pb+1];
            //    return true;
            //}
            #endregion
            #region concise
            int count = 0;
            for (int i = 1; i < nums.Length; i++) {
                if (nums[i-1] > nums[i]) {
                    count++;
                    if (i == 1) nums[i - 1] = nums[i];
                    else {
                        if (nums[i - 2] <= nums[i])
                            nums[i - 1] = nums[i];
                        else
                            nums[i] = nums[i - 1]; 
                    }
                }
            }
            return count <= 1;
            #endregion
        }
        #endregion
    }
}
