using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;

namespace TestFileRead
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;

            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            List<String> myStringList = File.ReadAllLines(projectDirectory + "/stamp-clock.txt").ToList();
            foreach(string item in myStringList)
            {
                Console.WriteLine(item);
                string[] subs = item.Split(new [] { "punch-in", ";" }, StringSplitOptions.RemoveEmptyEntries);//Gör lista av string[] splitters
                Console.WriteLine(subs[0]);//Lägg i settings
            }
            Console.ReadLine();
        }
    }
}
