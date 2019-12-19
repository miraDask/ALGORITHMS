namespace _02.QuickSort
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var unsortedArray = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            QuickSort(unsortedArray, 0, unsortedArray.Length - 1);
            Console.WriteLine(string.Join(" ", unsortedArray));
        }

        private static void QuickSort(int[] unsortedArray, int startIndex, int endIndex)
        {
            if (endIndex <= startIndex)
            {
                return;
            }

            var partitionIndex = GetPartitionIndex(unsortedArray, startIndex, endIndex);

            QuickSort(unsortedArray, startIndex, partitionIndex - 1);
            QuickSort(unsortedArray, partitionIndex + 1, endIndex);
        }

        private static int GetPartitionIndex(int[] unsortedArray, int startIndex, int endIndex)
        {
            var pivot = unsortedArray[endIndex];
            var pointerIndex = startIndex - 1;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (unsortedArray[i] <= pivot)
                {
                    Swap(unsortedArray, i, ++pointerIndex);
                }
            }

            Swap(unsortedArray, pointerIndex + 1, endIndex);
            return pointerIndex + 1;
        }

        private static void Swap(int[] unsortedArray, int index, int pointerIndex)
        {
            var temp = unsortedArray[index];
            unsortedArray[index] = unsortedArray[pointerIndex];
            unsortedArray[pointerIndex] = temp;
        }
    }
}
