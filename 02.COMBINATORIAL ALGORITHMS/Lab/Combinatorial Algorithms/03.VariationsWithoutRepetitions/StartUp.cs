namespace _03.VariationsWithoutRepetitions
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static string[] arr;
        static string[] variation;
        static bool[] used;

        public static void Main()
        {
            arr = Console.ReadLine().Split().ToArray();
            var variationCount = int.Parse(Console.ReadLine());
            variation = new string[variationCount];
            used = new bool[arr.Length];

            GenerateVariation(0);
        }

        private static void GenerateVariation(int index)
        {
            if (index > variation.Length - 1)
            {
                Console.WriteLine(string.Join(" ", variation));
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        variation[index] = arr[i];
                        GenerateVariation(index + 1);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
