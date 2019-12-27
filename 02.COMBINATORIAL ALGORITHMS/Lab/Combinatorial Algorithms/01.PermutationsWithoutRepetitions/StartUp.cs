namespace _01.PermutationsWithoutRepetitions
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static string[] arr;

        public static void Main()
        {
            arr = Console.ReadLine().Split().ToArray();
            Permute(0);
        }

        private static void Permute(int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
            else
            {
                Permute(index + 1);

                for (int i = index + 1; i < arr.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
