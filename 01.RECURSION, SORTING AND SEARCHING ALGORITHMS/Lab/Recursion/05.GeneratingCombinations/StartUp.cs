using System;
using System.Linq;

namespace _05.GeneratingCombinations
{
    public class StartUp
    {
        public static void Main()
        {
            var set = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var vectorLength = int.Parse(Console.ReadLine());

            var vector = new int[vectorLength];
            var index = 0;
            int border = 0;

            GenerateCombinations(set, vector, index, border);
        }

        private static void GenerateCombinations(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenerateCombinations(set, vector, index + 1, i + 1);
            }
        }
    }
}
