using System;

namespace _04.GeneratingVectors
{
    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var vector = new int[number];

            GenerateVectors(vector, 0);
        }

        private static void GenerateVectors(int[] vector, int index)
        {
            if (index > vector.Length - 1)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenerateVectors(vector, index + 1);
            }
        }
    }
}
