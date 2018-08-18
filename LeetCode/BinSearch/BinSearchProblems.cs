using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.BinSearch {
    class BinSearchProblems {
        /// <summary>
        /// Given a sorted array and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order
        /// </summary>
        /// <param src int array ="array"></param>
        /// <param target int num ="target"></param>
        public static int SearchInsertPos(int[] array, int target) {
            var low = 0;
            var high = array.Length - 1;
            
            while (low <= high) {
                var mid = (low + high) / 2;

                if (target < array[mid]) {
                    high = mid - 1;
                } else if (target > array[mid]) {
                    low = mid + 1;
                } else {
                    return mid;
                }
            }
            return low;
        }

        /// <summary>
        /// Implement int sqrt(int x).
        /// Compute and return the square root of x, where x is guaranteed to be a non-negative integer.
        /// Since the return type is an integer, the decimal digits are truncated and only the integer part of the result is returned.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int MySqrt(int x) {
            if (x == 0) {
                return 0;
            }
            int low = 1, high = int.MaxValue;
            int mid = low + (high - low) / 2;

            while (low < high) {
                if (x/mid < mid) {
                    high = mid - 1;
                } else if (x/mid > mid) {
                    if (x / (mid + 1) < mid + 1) {
                        return mid;
                    }
                    low = mid + 1;
                } else {
                    return mid;
                }
                mid = low + (high - low) / 2;
            }
            return mid;
        }

        /// <summary>
        /// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target) {
            #region v0.2
            int left = 0, right = numbers.Length - 1;
            int[] res = new int[2];

            while (left < right) {
                var sum = numbers[left] + numbers[right];
                if (sum == target) {
                    res[0] = left + 1;
                    res[1] = right + 1;
                    break;
                } else if (sum > target) {
                    right--;
                } else {
                    left++;
                }
            }
            return res;
            #endregion
        }

        /// <summary>
        /// Given two arrays, write a function to compute their intersection.
        /// Each element in the result should appear as many times as it shows in both arrays.
        /// The result can be in any order.
        /// https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersect(int[] nums1, int[] nums2) {
            List<int> resArrList = new List<int>();
            Dictionary<int, int> _dic = new Dictionary<int, int>();

            for (int i = 0; i < nums1.Length; i++) {
                if (!_dic.ContainsKey(nums1[i]))
                    _dic.Add(nums1[i], 1);
                 else
                    _dic[nums1[i]]++;
            }

            for (int i = 0; i < nums2.Length; i++) {
                if (_dic.ContainsKey(nums2[i]) && _dic[nums2[i]] > 0) {
                    resArrList.Add(nums2[i]);
                    _dic[nums2[i]]--;
                }
            }

            int[] resArr = new int[resArrList.Count];
            for (int i = 0; i < resArr.Length; i++) {
                resArr[i] = resArrList[i];
            }
            return resArr;
        }

        /// <summary>
        /// Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FirstBadVersion(int n) {
            //int low = 1, high = n;
            //while (low < high) {
            //    int mid = low + (high - low) / 2;
            //    if (IsBadVersion(mid)) {
            //        high = mid;
            //    } else {
            //        low = mid + 1;
            //    }
            //}
            //return low;
            return 0;
        }

        /// <summary>
        /// Given two arrays, write a function to compute their intersection.
        /// Each element in the result must be unique.
        /// The result can be in any order.
        /// https://leetcode.com/problems/intersection-of-two-arrays/description/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public static int[] Intersection(int[] nums1, int[] nums2) {
            #region v1.0 O(n)
            //int[] res;
            //List<int> _ls = new List<int>();
            //Dictionary<int, int> _dic = new Dictionary<int, int>();

            //for (int i = 0; i < nums1.Length; i++) {
            //    if (!_dic.ContainsKey(nums1[i])) {
            //        _dic.Add(nums1[i], 1);
            //    }
            //}

            //for (int i = 0; i < nums2.Length; i++) {
            //    if (_dic.ContainsKey(nums2[i]) && _dic[nums2[i]] > 0) {
            //        _dic[nums2[i]]--;
            //    }
            //}

            //foreach (var item in _dic.Keys) {
            //    if (_dic[item] == 0) {
            //        _ls.Add(item);
            //    }
            //}

            //res = new int[_ls.Count];
            //for (int i = 0; i < res.Length; i++) {
            //    res[i] = _ls[i];
            //}

            //return res;
            #endregion

            #region v1.1 O(nlogn)
            Array.Sort(nums2);
            List<int> _ls = new List<int>();

            for (int i = 0; i < nums1.Length; i++) {
                if (Utils.BinSearchResult(nums2, nums1[i])) {
                    if (_ls.Contains(nums1[i])) {
                        continue;
                    }
                    _ls.Add(nums1[i]);
                }
            }

            int[] res = new int[_ls.Count];
            for (int i = 0; i < _ls.Count; i++) {
                res[i] = _ls[i];
            }

            return res;
            #endregion
        }

        /// <summary>
        /// Given a positive integer num, write a function which returns True if num is a perfect square else False.
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsPerfectSquare(int num) {
            if (num == 0 || num == 1) {
                return true;
            }

            int low = 0, high = num;
            while (low <= high) {
                long mid = low + (high - low) / 2;  //  NOTE: use long to hold mid to avoid overflow(mid * mid)!!!
                if (mid * mid == num) {
                    return true;
                } else if (mid * mid > num) {
                    high = (int)mid - 1;
                } else {
                    low = (int)mid + 1;
                }
            }
            return false;
        }

        /// <summary>
        /// n = 5
        /// The coins can form the following rows:
        /// ¤
        /// ¤ ¤
        /// ¤ ¤
        /// Because the 3rd row is incomplete, we return 2.
        /// </summary>
        /// <param count of coins ="n"></param>
        /// <returns></returns>
        public static int ArrangeCoins(int n) {
            if (n == 0) {
                return 0;
            }

            int low = 1, high = n;
            while (low <= high) {
                int mid = low + (high - low) / 2;
                double comCount = 0.5 * mid * mid + 0.5 * mid;
                if (comCount == n) {
                    return mid;
                } else if (comCount > n) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            }
            return high;
        }

        /// <summary>
        ///  given positions of houses and heaters on a horizontal line, find out minimum radius of heaters so that all houses could be covered by those heaters.
        /// </summary>
        /// <param name="houses"></param>
        /// <param name="heaters"></param>
        /// <returns></returns>
        public static int FindRadius(int[] houses, int[] heaters) {
            int res = 0;

            //  sort array of heaters for binary search
            Array.Sort(heaters);

            for (int i = 0; i < houses.Length; i++) {
                int house = houses[i];

                //  search the insert index of every house element in heaters array
                int insertIndex = SearchInsertPos(heaters, house);
                int dist1 = insertIndex - 1 >= 0 ? house - heaters[insertIndex - 1] : int.MaxValue;  //  calc the dist between the house and the heater on its left
                int dist2 = insertIndex >= heaters.Length ? int.MaxValue : heaters[insertIndex] - house; //  calc the dist between the house and the heater on its right

                res = Math.Max(res, Math.Min(dist1, dist2));
            }

            return res;
        }

        /// <summary>
        /// Given a list of sorted characters letters containing only lowercase letters, and given a target letter target, find the smallest element in the list that is larger than the given target.
        /// Letters also wrap around.For example, if the target is target = 'z' and letters = ['a', 'b'], the answer is 'a'
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static char NextGreatestLetter(char[] letters, char target) {
            int n = letters.Length;
            int low = 0, high = n;
            while (low < high) {
                int mid = low + (high - low) / 2;
                if (letters[mid] > target)
                    high = mid;
                else
                    low = mid + 1;
            }
            return letters[low % n];
        }

        /// <summary>
        /// https://leetcode.com/problems/peak-index-in-a-mountain-array/description/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public static int PeakIndexInMountainArray(int[] A) {
            int mid = (A.Length - 1) / 2;
            int left = mid - 1, right = mid + 1;

            if (A[right] > A[mid]) {
                while (right < A.Length - 1) {
                    if (A[right] > A[right + 1]) break;
                    else right++;
                }
                return right;
            } else if (A[left] > A[mid]) {
                while (left > 0) {
                    if (A[left] > A[left - 1]) break;
                    else left--;
                }
                return left;
            } else {
                return mid;
            }
        }
    }
}
