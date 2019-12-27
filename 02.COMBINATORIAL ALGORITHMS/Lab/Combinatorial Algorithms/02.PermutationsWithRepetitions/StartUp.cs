namespace _02.PermutationsWithRepetitions
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static string[] arr;

        public static void Main()
        {
            arr = Console.ReadLine().Split().ToArray();
            Array.Sort(arr);
            Permute(0, arr.Length - 1);
        }

        private static void Permute(int startIndex, int endIndex)
        {
            PrintResult();
            for (int left = endIndex - 1; left >= startIndex; left--)
            {
                for (int right = left + 1; right <= endIndex; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(left, right);
                        Permute(left + 1, endIndex);
                    }
                }

                var firstElement = arr[left];
                for (int i = left; i <= endIndex - 1; i++)
                {
                    arr[i] = arr[i + 1];
                    arr[endIndex] = firstElement;
                }
            }
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}
