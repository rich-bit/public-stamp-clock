using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace stamples
{
    class Settings
    {
        public static List<StampleData> data;
        public static DateTime currentPunchInTime;
        public static DateTime currentPunchOutTime;
        public static string currentProject;
        public static string currentDescription;

        // This will get the current WORKING directory (i.e. \bin\Debug) // -- Ty stackoverflow
        public static string workingDirectory = Environment.CurrentDirectory;
        // This will get the current PROJECT directory
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public Settings()
        {
            Console.WindowWidth = 150;
        }
        public static List<string> removeDuplicates()
        {
            List<string> projects = new List<string>();

            for(int i = 0; i < data.Count; i++)
            {
                projects.Add(data[i].project);
            }

            var projectsNoDupes = new HashSet<string>(projects).ToList();//Stackoverflow
            return projectsNoDupes;
        }
    }
}
