namespace _02.Searching
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var searchedElement = int.Parse(Console.ReadLine());

            var indexOfSearchedElement = BinarySearch(array, searchedElement, 0, array.Length - 1);
            Console.WriteLine(indexOfSearchedElement);
        }

        private static int BinarySearch(int[] array, int searchedElement, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }
            else
            {
                var middleIndex = (startIndex + endIndex) / 2;

                if (array[middleIndex] < searchedElement)
                {
                    return BinarySearch(array, searchedElement, middleIndex + 1, endIndex);
                }
                else if (array[middleIndex] > searchedElement)
                {
                    return BinarySearch(array, searchedElement, startIndex, middleIndex - 1);
                }
                else
                {
                    return middleIndex;
                }
            }
        }
    }
}