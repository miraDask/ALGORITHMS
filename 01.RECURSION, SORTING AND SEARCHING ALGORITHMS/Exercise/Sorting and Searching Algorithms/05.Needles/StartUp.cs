namespace _05.Needles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var countInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var needles = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var indecies = InsertNeedlesInNumberCollection(numbers, needles);
            Console.WriteLine(string.Join(" ", indecies));
        }

        private static List<int> InsertNeedlesInNumberCollection(List<int> numbers, int[] needles)
        {
            int prev = numbers[numbers.Count - 1];

            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                if (numbers[i] == 0)
                {
                    numbers[i] = prev;
                }

                prev = numbers[i];
            }

            var result = new List<int>();

            for (int i = 0; i < needles.Length; i++)
            {
                bool isIn = false;

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[j] >= needles[i])
                    {
                        result.Add(j);
                        isIn = true;
                        break;
                    }
                }

                if (!isIn)
                {
                    int index = numbers.Count - 1;
                    while (index > 0 && numbers[index] == 0)
                    {
                        index--;
                    }
                    if (numbers[index] == 0)
                    {
                        index--;
                    }
                    result.Add(index + 1);
                }
            }

            return result;
        }
    }
}
