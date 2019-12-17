namespace _04.TowersOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static int takenStep = 0;
        private static Stack<int> sourceRod;
        private static Stack<int> destinationRod = new Stack<int>();
        private static Stack<int> spareRod = new Stack<int>();

        public static void Main()
        {
            var disksCount = int.Parse(Console.ReadLine());

            sourceRod = new Stack<int>(Enumerable.Range(1, disksCount).Reverse());
          
            PrintPegs();

            MoveDisk(disksCount, sourceRod, spareRod, destinationRod);
        }


        private static void MoveDisk(int disk, Stack<int> sourceRod, Stack<int> spareRod, Stack<int> destinationRod)
        {

            if (disk == 1)
            {
                destinationRod.Push(sourceRod.Pop());
                Console.WriteLine($"Step #{++takenStep}: Moved disk {disk}");
                PrintPegs();
                return;
            }

            MoveDisk(disk - 1, sourceRod, destinationRod, spareRod);
            destinationRod.Push(sourceRod.Pop());
            Console.WriteLine($"Step #{++takenStep}: Moved disk {disk}");
            PrintPegs();
            MoveDisk(disk - 1, spareRod, sourceRod, destinationRod);

        }


        private static void PrintPegs()
        {
            Console.WriteLine("Source: " + string.Join(", ", sourceRod.Reverse()));
            Console.WriteLine("Destination: " + string.Join(", ", destinationRod.Reverse()));
            Console.WriteLine("Spare: " + string.Join(", ", spareRod.Reverse()));
            Console.WriteLine();
        }
    }
}
