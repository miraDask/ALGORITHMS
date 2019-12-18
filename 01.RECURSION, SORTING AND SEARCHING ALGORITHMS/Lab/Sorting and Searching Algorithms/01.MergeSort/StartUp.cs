namespace _01.MergeSort
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

            Sort(unsortedArray, 0, unsortedArray.Length - 1);
            Console.WriteLine(string.Join(" ", unsortedArray));
        }

        private static void Sort(int[] unsortedArray, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return;
            }

            var midIndex = (startIndex + endIndex) / 2;

            Sort(unsortedArray, 0, midIndex);
            Sort(unsortedArray, midIndex + 1, endIndex);
            Merge(unsortedArray, startIndex, endIndex, midIndex);
        }

        private static void Merge(int[] unsortedArray, int startIndex, int endIndex, int midIndex)
        {
            if (midIndex < 0 || midIndex + 1 >= unsortedArray.Length 
                || unsortedArray[midIndex] <= unsortedArray[midIndex + 1])
            {
                return;
            }

            var helpArray = new int[unsortedArray.Length];

            for (int i = startIndex; i <= endIndex; i++)
            {
                helpArray[i] = unsortedArray[i];
            }

            var leftIndexPointer = startIndex;
            var rightIndexPointer = midIndex + 1;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (leftIndexPointer > midIndex)
                {
                    unsortedArray[i] = helpArray[rightIndexPointer++];
                }
                else if (rightIndexPointer > endIndex)
                {
                    unsortedArray[i] = helpArray[leftIndexPointer++];
                }
                else if (helpArray[leftIndexPointer] <= helpArray[rightIndexPointer])
                {
                    unsortedArray[i] = helpArray[leftIndexPointer++];
                }
                else
                {
                    unsortedArray[i] = helpArray[rightIndexPointer++];
                }
            }
        }
    }
}
