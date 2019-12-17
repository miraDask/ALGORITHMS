namespace _01.ReverseArray
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var reversedInput = ReverseArray(input, input.Length - 1);

            Console.WriteLine(reversedInput);
        }

        private static string ReverseArray(string[] input, int index)
        {
            if (index == 0)
            {
                return input[0];
            }

            return input[index] + " " + ReverseArray(input, index - 1);
        }
    }
}
