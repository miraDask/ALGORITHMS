namespace _02.NestedLoops
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var vectorSize = int.Parse(Console.ReadLine());
            var vector = new int[vectorSize];

            GenerateVectors(vectorSize, 0, vector);
        }

        private static void GenerateVectors(int vectorSize, int index, int[] vector)
        {
            if (index == vectorSize)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }
            else
            {
                for (int i = 1; i <= vectorSize; i++)
                {
                    vector[index] = i;
                    GenerateVectors(vectorSize, index + 1, vector);
                }
            }
        }
    }
}
