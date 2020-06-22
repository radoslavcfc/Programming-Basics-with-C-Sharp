using System;
using System.Collections.Generic;

namespace AlgoPlay
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            var result = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
            if (result != null)
            {
                Console.WriteLine(result.Item1 + ", " + result.Item2);
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
    }
   
}
