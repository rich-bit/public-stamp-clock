using System;
using System.IO;

namespace stamp_clock
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("stamp-clock-txt"))
            {
                Console.WriteLine("Reading data...");
            }
            else
            {
                Console.WriteLine("Reading data...");
                File.Create("stamp-clock.txt");
            }
            new Menu();
        }
    }
}
