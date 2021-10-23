using System;
using System.Collections.Generic;
using System.Text;

namespace stamples
{
    class PresentTimeSheet
    {
        List<string> projects = new List<string>();
        public PresentTimeSheet()
        {
            Console.Clear();
            projects = Settings.removeDuplicates();

            int j = 0;
            PrintProject(projects[j], Settings.data);



            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;
                switch (choice)
                {
                    // 1 ! key
                    case ConsoleKey.UpArrow:
                        if (j < projects.Count - 1)
                        { j++; PrintProject(projects[j], Settings.data); }
                        else
                        { j = 0; PrintProject(projects[j], Settings.data); }
                        break;
                    //2 @ key
                    case ConsoleKey.DownArrow:
                        if (j > 0)
                        { j--; PrintProject(projects[j], Settings.data); }
                        else
                        { j = projects.Count - 1; PrintProject(projects[j], Settings.data); }
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Exiting...");
                        break;//Stackoverflow ty
                }
            } while (choice != ConsoleKey.Escape);            
        }
        private void PrintProject(string project, List<StampleData> data)
        {
            Console.Clear();
            Console.WriteLine("Arrow up/down to switch between projects");
            Console.WriteLine("Press ESC to stop");
            Console.WriteLine();
            Console.WriteLine($"TimeStamps in project: {project}");
            Console.WriteLine("_________________________________________________________________________________________________________");
            TimeSpan totalWorkedTime = TimeSpan.Zero;
            Console.WriteLine("\tPunch-in \t\tPunch-out \t\tWorked-time \t\tdescription");
            int stamples = 0;
            foreach (StampleData item in data)
            {
                if (item.project == project)
                {
                    stamples++;

                    TimeSpan t1 = item.punchIn - DateTime.MinValue;
                    TimeSpan t2 = item.punchOut - DateTime.MinValue;

                    TimeSpan result = t2 - t1;
                    totalWorkedTime += result;

                    Console.WriteLine($"\t{item.punchIn} \t{item.punchOut} \t{Math.Round(result.TotalHours, 2)} hour[s] \t\t{item.description}");
                }
            }
            Console.WriteLine("_________________________________________________________________________________________________________");
            Console.WriteLine($"Total: \t\t\t\t\t\t\t{Math.Round(totalWorkedTime.TotalHours, 2)} hour[s]");
        }
    }
}
