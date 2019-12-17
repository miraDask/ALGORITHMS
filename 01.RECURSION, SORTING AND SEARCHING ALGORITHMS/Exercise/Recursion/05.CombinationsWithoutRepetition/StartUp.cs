namespace _05.CombinationsWithoutRepetition
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var numbersRange = int.Parse(Console.ReadLine());
            var vectorSize = int.Parse(Console.ReadLine());

            var vector = new int[vectorSize];

            GenerateVectors(numbersRange, 0, vector, 0);
        }

        private static void GenerateVectors(int numbersRange, int index, int[] vector, int borderNumber)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            else
            {
                for (int i = 1; i <= numbersRange; i++)
                {
                    if (i >= borderNumber)
                    {
                        vector[index] = i;
                        GenerateVectors(numbersRange, index + 1, vector, i + 1);
                    }
                }
            }
        }
    }
}

