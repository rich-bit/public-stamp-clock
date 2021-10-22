using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace stamples
{
    class Fileread
    {
        // This will get the current WORKING directory (i.e. \bin\Debug) // -- Ty stackoverflow
        string workingDirectory = Environment.CurrentDirectory;

        int dataNotRead = 0;

        public Fileread()
        {
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            List<String> myStringList = File.ReadAllLines(projectDirectory + "/stamp-clock.txt").ToList();
            myStringList.RemoveAll(s => string.IsNullOrWhiteSpace(s));//ty stackoverflow
            Settings.data = new List<StampleData>();

            foreach (string item in myStringList)
            {
                try
                {
                    string[] subs = item.Split(new[] { "punch-in", ";", "punch-out", ";", "project", ";", "description", ";" }, StringSplitOptions.RemoveEmptyEntries);

                    DateTime readPunchIn = Convert.ToDateTime(subs[0]);
                    DateTime readPunchOut = Convert.ToDateTime(subs[1]);
                    string readProject = subs[2];
                    string readDescription = subs[3];                    

                    Settings.data.Add(new StampleData(readPunchIn, readPunchOut, readProject, readDescription));
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());
                    dataNotRead++;
                }
            }

            if (dataNotRead != 0)
            {
                Console.WriteLine($"Warning, not all data was read by program. {dataNotRead} lines from timesheet failed.");
                Console.WriteLine("Check file in project folder please.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Read success.");
            }
        }
        public void WriteToFile()
        {
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            try
            {

                using (StreamWriter sw = File.AppendText(projectDirectory + "/stamp-clock.txt"))
                {                    
                    sw.WriteLine($"punch-in;{Settings.currentPunchInTime};punch-out;{Settings.currentPunchOutTime};project;{Settings.currentProject};description;{Settings.currentDescription};\n");
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                Console.WriteLine("Error when writing file");
            }
        }
        public void ResetFile()
        {
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            try
            {
                File.Delete(projectDirectory + "/stamp-clock.txt");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
            File.Create(projectDirectory + "/stamp-clock.txt");
        }
    }
}
