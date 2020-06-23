using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AlgoPlay
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var list = new List<int>() 
            {
                3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,
                3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,
                3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,
                3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9,3, 1, 5, 7, 5, 9
            };
            var sumToFind = 10;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = FindTwoSum(list, sumToFind);
            stopWatch.Stop();

            if (result != null)
            {
                Console.WriteLine(result.Item1 + ", " + result.Item2);
                Console.WriteLine(stopWatch.Elapsed);
                Console.WriteLine();
            }

            stopWatch.Reset();
            Console.WriteLine("Sorted");

            stopWatch.Start();

            var sorted = FindTwoSumWithSort(list, sumToFind);

            stopWatch.Stop();

            if (sorted != null)
            {
                Console.WriteLine(sorted.Item1 + ", " + sorted.Item2);
                Console.WriteLine(stopWatch.Elapsed);
            }

            stopWatch.Reset();
            Console.WriteLine("Array");

            stopWatch.Start();

            var arrayed = FindTwoSumWithArraySort(list.ToArray(), sumToFind);

            stopWatch.Stop();

            if (sorted != null)
            {
                Console.WriteLine(arrayed.Item1 + ", " + arrayed.Item2);
                Console.WriteLine(stopWatch.Elapsed);
            }

            
        }

        private static Tuple<int,int> FindTwoSum(List<int> list, int sum)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count - i - 1; j++)
                {
                    var current = list[i];
                    var adjacent = list[j];
                    if (current + adjacent == sum)
                    {
                        return new Tuple<int, int>(i, (j));
                    }
                }
            }
            
            return null;
        }
        private static Tuple<int, int> FindTwoSumWithSort(List<int> list, int sum)
        {
            int left, right;
            var originalList = new List<int> (list);
           
            QuickSort(list, 0, list.Count - 1);

            left = 0;
            right = list.Count - 1;
            while (left < right)
            {
                if (list[left] + list[right] == sum)
                {
                    return new Tuple<int, int>(originalList.IndexOf(list[left]), originalList.IndexOf(list[right]));
                }

                else if (list[left] + list[right] < sum)
                {
                    left++;
                }

                else
                {
                    right--;
                }
                // A[i] + A[j] > sum 
                    
            }
           
            return null;
        }

        private static Tuple<int, int> FindTwoSumWithArraySort(int [] arrayInt, int sum)
        {
            int left, right;
            var originalList = new List<int>(arrayInt);

            arrayInt.ToList().Sort();

            left = 0;
            right = arrayInt.Length - 1;
            while (left < right)
            {
                if (arrayInt[left] + arrayInt[right] == sum)
                {
                    return new Tuple<int, int>(originalList.IndexOf(arrayInt[left]), originalList.IndexOf(arrayInt[right]));
                }

                else if (arrayInt[left] + arrayInt[right] < sum)
                {
                    left++;
                }

                else
                {
                    right--;
                }
                // A[i] + A[j] > sum 

            }

            return null;
        }

        private static void QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);

                if (pivot > 1)
                {
                    QuickSort(list, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(list, pivot + 1, right);
                }
            }
        }

        private static int Partition(List<int> list, int left, int right)
        {
            int pivot = list[left];

            while (true)
            {
                while (list[left] < pivot)
                {
                    left++;
                }

                while (list[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (list[left] == list[right]) return right;

                    int temp = list[left];
                    list[left] = list[right];
                    list[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
