namespace _03.RecursiveDrawing
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            Draw(number);
        }

        private static void Draw(int number)
        {
            if (number == 0)
            {
                return;
            }

            var row = new string('*', number);
            Console.WriteLine(row);
            Draw(number - 1);
            var newRow = new string('#', number);
            Console.WriteLine(newRow);
        }
    }
}
