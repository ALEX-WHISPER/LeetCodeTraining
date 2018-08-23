using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LeetCode.BinSearch;
using LeetCode.ArrayAlgorithm;

namespace LeetCode {
    class Program {
        static void Main(string[] args) {
            var sw = new Stopwatch();
            sw.Start();
            ArrayExcute();
            sw.Stop();
            var em = sw.ElapsedTicks;
            Console.WriteLine(em);
        }

        static void BinSearchExcute() {
            //var res = BinSearchProblems.SearchInsertPos(new int[] { 1, 3, 5, 6 }, 7);
            //var res = BinSearchProblems.MySqrt(8);
            //var res = BinSearchProblems.TwoSum(new int[5] { 2,7,11,15,25 }, 18);
            //var res = BinSearchProblems.Intersect(new int[] { 1,2,2,5,9,2,1 }, new int[] { 5, 9, 1, 2 });
            //var res = BinSearchProblems.Intersection(new int[] { 1 }, new int[] { 1 });
            //var res = BinSearchProblems.IsPerfectSquare(16);
            var res = BinSearchProblems.ArrangeCoins(9);
            //var res = BinSearchProblems.FindRadius(new int[] { 1,2,3,4,5 }, new int[] { 1 });
            //var res = BinSearchProblems.NextGreatestLetter(new char[] { 'c', 'f', 'j' }, 'a');

            //  [3,4,5,1]
            //  [24,69,100,99,79,78,67,36,26,19]
            //  [18, 29, 38, 59, 98, 100, 99, 98, 90]
            //  [55,59,63,99,97,94,84,81,79,66,40,38,33,23,22,21,17,9,7]
            //var res = BinSearch.BinSearchProblems.PeakIndexInMountainArray(new int[] { 55, 59, 63, 99, 97, 94, 84, 81, 79, 66, 40, 38, 33, 23, 22, 21, 17, 9, 7 });

            Console.WriteLine("res:" + res);
            //foreach (var item in res) {
            //    Console.Write(item.ToString() + " ");
            //}
        }

        static void ArrayExcute() {
            //var res = ArrayProblems.TwoSum(new int[] { 3,2,4 }, 6);
            //var res = ArrayProblems.RemoveDuplicates(new int[] { 0,0,1,1,1,2,2,3,3,4 });
            //var res = ArrayProblems.RemoveElement(new int[] { 0,1,2,2,3,0,4,2 }, 2);

            //var res = ArrayProblems.PlusOne(new int[] { 9,9,9,9 });
            //foreach (var item in res) {
            //    Console.Write(item.ToString() + " ");
            //}

            //ArrayProblems.Merge(new int[] { 1,2,3,0,0,0,0 }, 3, new int[] { 0,2,5,6 }, 4);

            //var res = ArrayProblems.Generate(5);
            //for (int i = 0; i < res.Count; i++) {
            //    var row = res[i];
            //    for (int j = 0; j < row.Count; j++) {
            //        Console.Write(row[j] + " ");
            //    }
            //    Console.WriteLine("");
            //}

            //var res = ArrayProblems.GetRow(3);
            //foreach (var item in res) {
            //    Console.Write(item.ToString() + " ");
            //}

            //var res = ArrayProblems.MaxProfit(new int[] { 7,6,4,3,1 });
            //Console.WriteLine("res: " + res);

            //ArrayProblems.Rotate(new int[] { 1,2,3,4,5,6,7 }, 3);

            //var res = ArrayProblems.ContainsDuplicate(new int[] { 1,1,2,2,3,4,5,6,7,8,9 });
            //var res = ArrayProblems.ContainsNearbyDuplicate(new int[] { 1,0,1,1 }, 1);
            //var res = ArrayProblems.MissingNumber(new int[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 });
            //var res = ArrayProblems.FindMaxConsecutiveOnes(new int[] { 1,1,1,1,1,0,0,1,0,1,1,1,1,1,1 });
            //var res = ArrayProblems.MaxDistToClosest(new int[] { 0,0,1,0,1 });
            //Console.WriteLine("res: " + res);

            //var res = ArrayProblems.MatrixReshape(new int[,] { { 1, 2, 3, 5}, { 3, 4, 8, 8 } }, 4, 2);
            //for (int i = 0; i < res.GetLength(0); i++) {
            //    for (int j = 0; j < res.GetLength(1); j++) {
            //        Console.Write(res[i, j] + " ");
            //    }
            //    Console.WriteLine("");
            //}

            //var res = ArrayProblems.CanPlaceFlowers(new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0 }, 4);
            //var res = ArrayProblems.MaximumProduct(new int[] { -4,-3,-2,1,66 });
            //Console.WriteLine("res: " + res);

            //ArrayProblems.Transpose(new int[][] { new int[] { 1,2,3 }, new int[] { 4,5,6 } });

            //var res = ArrayProblems.FindMaxAverage(new int[] { 1,12,-5,-6,50,3 }, 4);
            //Console.WriteLine("res: " + res);

            //var res = ArrayProblems.ImageSmoother(new int[,] {
            //    { 1,1,1 },
            //    { 1,0,1 },
            //    { 1,1,1 }
            //});
            //for (int i = 0; i < res.GetLength(0); i++) {
            //    for (int j = 0; j < res.GetLength(1); j++) {
            //        Console.Write(res[i, j] + " ");
            //    }
            //    Console.WriteLine("");
            //}

            //var res = ArrayProblems.FindLengthOfLCIS(new int[] { 1,3,4,7,8,8,9,10,12 });
            //var res = ArrayProblems.MaxAreaOfIsland(new int[,] {
            //    { 1, 1, 0, 0, 0 }, 
            //    { 1, 1, 0, 0, 0 }, 
            //    { 0, 0, 0, 1, 1 }, 
            //    { 0, 0, 0, 1, 1 }
            //});
            //var res = ArrayProblems.FindShortestSubArray(new int[] { 1,2,2,3,1,4 });
            //var res = ArrayProblems.IsOneBitCharacter(new int[] { 1,0 });
            //var res = ArrayProblems.PivotIndex(new int[] { -1,-1,-1,0,1,1 });
            //var res = ArrayProblems.DominantIndex(new int[] { 0,1,2,4,8,0,0 });
            //var res = ArrayProblems.IsToeplitzMatrix(new int[,] {
            //    { 18 },
            //    { 66 }
            //});
            //Console.WriteLine("res: " + res);

            //string str1 = "abbxxxxzzy", str2 = "abc", str3 = "abcdddeeeeaabbbcd", str4 = "aaabbbbbaaaaaaacccddddddd";
            //var res = ArrayProblems.LargeGroupPositions(str4);
            //for (int i = 0; i < res.Count; i++) {
            //    for (int j = 0; j < res[i].Count; j++) {
            //        Console.Write(res[i][j] + " ");
            //    }
            //    Console.WriteLine("");
            //}

            //var res = ArrayProblems.FlipAndInvertImage(new int[][] {
            //    new int[] { 1,1,0 },
            //    new int[] { 1,0,1 },
            //    new int[] { 0,0,0 }
            //});
            //for (int i = 0; i < res.Length; i++) {
            //    for (int j = 0; j < res[0].Length; j++) {
            //        Console.Write(res[i][j] + " ");
            //    }
            //    Console.WriteLine("");
            //}

            //var res = ArrayProblems.FairCandySwap(new int[] { 2,4 }, new int[] { 1,2,5 });
            //for (int i = 0; i < res.Length; i++) {
            //    Console.Write(res[i] + " ");
            //}

            //var res = ArrayProblems.MinCostClimbingStairs(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 });
            //var res = ArrayProblems.ThirdMax(new int[] { 1, 2, 3, 4, 5, 6 });   //  {1,2,-2147483648}, {1,2,2,5,3,5}, {1,2,2}, {1,-2147483648,2}, {5,2,2}
            var res = ArrayProblems.CheckPossibility(new int[] { 2,3,3,2,4 });
            Console.WriteLine("res: " + res);
        }
    }
}
