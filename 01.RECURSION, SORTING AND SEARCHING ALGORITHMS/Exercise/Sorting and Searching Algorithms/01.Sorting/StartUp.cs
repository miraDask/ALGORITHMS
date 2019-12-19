namespace _01.Sorting
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[] helpArray;

        public static void Main()
        {
            var inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortArray(inputArray);
            Console.WriteLine(string.Join(" ", inputArray));
        }

        private static void SortArray(int[] arr)
        {
            helpArray = new int[arr.Length];
            MergeSort(arr, 0, arr.Length - 1);
        }

        private static void MergeSort(int[] arr, int startIndex, int endIndex)
        {
            if (endIndex == startIndex)
            {
                return;
            }

            var midIndex = startIndex + (endIndex - startIndex) / 2;

            MergeSort(arr, startIndex, midIndex);
            MergeSort(arr, midIndex + 1, endIndex);
            Merge(arr, startIndex, endIndex, midIndex);
        }

        private static void Merge(int[] arr, int startIndex, int endIndex, int midIndex)
        {
            if (arr[midIndex] <= arr[midIndex + 1])
            {
                return;
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                helpArray[i] = arr[i];
            }

            var leftIndexPointer = startIndex;
            var rightIndexPointer = midIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndexPointer > midIndex)
                {
                    arr[i] = helpArray[rightIndexPointer++];
                }
                else if (rightIndexPointer > endIndex)
                {
                    arr[i] = helpArray[leftIndexPointer++];
                }
                else if (helpArray[leftIndexPointer] <= helpArray[rightIndexPointer])
                {
                    arr[i] = helpArray[leftIndexPointer++];
                }
                else
                {
                    arr[i] = helpArray[rightIndexPointer++];
                }
            }
        }
    }
}
