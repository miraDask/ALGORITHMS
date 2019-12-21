namespace _03.InversionCount
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var inputArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            
            Console.WriteLine(SortArray(inputArray));
        }

        private static int SortArray(int[] arr)
        {
            var tempArr = new int[arr.Length];
            return MergeSort(arr,tempArr, 0, arr.Length - 1);
        }

        private static int MergeSort(int[] arr, int[] temp, int startIndex, int endIndex)
        {

            int mid, invCount = 0;

            if (endIndex > startIndex)
            {
                mid = (endIndex + startIndex) / 2;

                invCount = MergeSort(arr, temp, startIndex, mid);
                invCount += MergeSort(arr, temp, mid + 1, endIndex);

                invCount += Merge(arr, temp, startIndex, mid + 1, endIndex);
            }

            return invCount;
        }

        private static int Merge(int[] arr, int[] tempArr, int startIndex, int midIndex, int endIndex)
        {
            int i, j, k;

            int invCount = 0;

            i = startIndex;
            j = midIndex;
            k = startIndex;

            while ((i <= midIndex - 1) && (j <= endIndex))
            {
                if (arr[i] <= arr[j])
                {
                    tempArr[k++] = arr[i++];
                }
                else
                {
                    tempArr[k++] = arr[j++];
                    invCount += midIndex - i;
                }
            }

            while (i <= midIndex - 1)
            {
                tempArr[k++] = arr[i++];
            }

            while (j <= endIndex)
            {
                tempArr[k++] = arr[j++];
            }

            for (i = startIndex; i <= endIndex; i++)
            {
                arr[i] = tempArr[i];
            }

            return invCount;
        }
    }
}
