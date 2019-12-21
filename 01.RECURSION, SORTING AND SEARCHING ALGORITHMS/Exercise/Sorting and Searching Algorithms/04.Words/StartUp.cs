namespace _04.Words
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static int count;
        static char[] characters;

        public static void Main()
        {
            characters = Console.ReadLine().ToCharArray();

            if (CharsAreUnique())
            {
                count = Factorial(characters.Length);
            }
            else
            {
                GeneratePermutations(0);
            }

            Console.WriteLine(count);
        }

        private static bool CharsAreUnique()
        {
            var uniqueCharacters = new HashSet<char>(characters);

            if (uniqueCharacters.Count == characters.Length)
            {
                return true;
            }

            return false;
        }

        private static int Factorial(int number)
        {
            var factorial = 1;

            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        private static void GeneratePermutations(int index)
        {
            if (index == characters.Length)
            {
                if (IsValid())
                {
                    count++;
                }

                return;
            }

            var swapped = new HashSet<char>();

            for (int i = index; i < characters.Length; i++)
            {
                if (!swapped.Contains(characters[i]))
                {
                    Swap(i, index);
                    GeneratePermutations(index + 1);
                    swapped.Add(characters[index]);
                    Swap(i, index);
                }
            }
        }

        private static bool IsValid()
        {
            for (int i = 0; i <= characters.Length - 2; i++)
            {
                if (characters[i] == characters[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var temp = characters[firstIndex];
            characters[firstIndex] = characters[secondIndex];
            characters[secondIndex] = temp;
        }
    }
}
