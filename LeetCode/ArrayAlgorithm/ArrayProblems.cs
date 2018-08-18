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
        /// Given a flowerbed (represented as an array containing 0 and 1, where 0 means empty and 1 means not empty), and a number n, return if n new flowers can be planted in it without violating the no-adjacent-flowers rule.
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
        /// Given an integer array, find three numbers whose product is maximum and output the maximum product.
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
    }
}
