using System;

namespace stamples
{
    class Menu
    {
        public bool PunchedIn { get; set; }
        public Menu(ref bool draw, ref MenuState currentMenuState)
        {
            switch (currentMenuState)
            {
                case MenuState.menu:
                    new Fileread();
                    Console.Clear();

                    Console.WriteLine("Please don't use these words/symbols in program:\npunch-in punch-out project description ;\nTry to keep things simple.");
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("[1]: Punch in");
                    Console.WriteLine("[2]: Punch out");
                    Console.WriteLine("[3]: Add worked time");
                    Console.WriteLine("[4]: View Time-Sheet");
                    Console.WriteLine("[5]: Settings");
                    Console.WriteLine("[6]: Reset program");
                    Console.WriteLine("[7]: Quit");
                    Console.Write("Make choice + enter: ");                    
                    int choice = 0;
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        draw = false;
                    }
                    if (choice == 1)
                        currentMenuState = MenuState.punchin;
                    else if (choice == 2)
                        currentMenuState = MenuState.punchout;
                    else if (choice == 3)
                        currentMenuState = MenuState.addtime;
                    else if (choice == 4)
                        currentMenuState = MenuState.viewTimeCard;
                    else if (choice == 5)
                        currentMenuState = MenuState.settings;
                    else if (choice == 6)
                        currentMenuState = MenuState.reset;
                    else if (choice == 7)
                        currentMenuState = MenuState.quit;
                    else
                        draw = false;
                    break;
                case MenuState.punchin:
                    Console.Write("Punch in to project: ");
                    Settings.currentProject = Console.ReadLine();
                    Settings.currentPunchInTime = DateTime.Now;
                    currentMenuState = MenuState.menu;
                    break;
                case MenuState.punchout:
                    Console.Write("Punch out...Describe your work: ");
                    Settings.currentDescription = Console.ReadLine();
                    Settings.currentPunchOutTime = DateTime.Now;
                    new Fileread().WriteToFile();
                    currentMenuState = MenuState.menu;
                    break;
                case MenuState.addtime:
                    try
                    {
                        Console.Write("Time started [YYYY-MM-DD HH:MM:SS]: ");
                        Settings.currentPunchInTime = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Project: ");
                        Settings.currentProject = Console.ReadLine();
                        Console.Write("Time ended [YYYY-MM-DD HH:MM:SS]: ");
                        Settings.currentPunchOutTime = Convert.ToDateTime(Console.ReadLine());
                        Console.Write("Describe work: ");
                        Settings.currentDescription = Console.ReadLine();
                        new Fileread().WriteToFile();
                        currentMenuState = MenuState.menu;
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.ToString());
                        Console.WriteLine("Did not work. Restart program...");
                        draw = false;
                    }
                    break;
                case MenuState.viewTimeCard:
                    if (Settings.data.Count > 0)
                    {
                        new Fileread();
                        new PresentTimeSheet();
                    }
                    currentMenuState = MenuState.menu;
                    break;
                case MenuState.settings:
                    Console.ReadLine();
                    currentMenuState = MenuState.menu;
                    break;
                case MenuState.reset:
                    Console.Write("Warning: All data will be lost, are you sure? Y/N? ");
                    char anwser = Convert.ToChar(Console.ReadLine());
                    if (anwser == 'Y' || anwser == 'y')
                    { new Fileread().ResetFile(); currentMenuState = MenuState.menu; }
                    else
                        currentMenuState = MenuState.menu;
                    break;
                case MenuState.quit:
                    draw = false;
                    break;
            }
        }
    }
}
