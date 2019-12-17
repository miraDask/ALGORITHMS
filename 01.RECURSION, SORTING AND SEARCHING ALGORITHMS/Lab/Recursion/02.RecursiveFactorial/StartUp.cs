namespace _02.RecursiveFactorial
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(number));
        }

        private static long Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}
