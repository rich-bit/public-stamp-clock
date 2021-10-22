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
                    Console.Clear();
                    Console.WriteLine("[1]: Punch in");
                    Console.WriteLine("[2]: Punch out");
                    Console.WriteLine("[3]: View Time-Sheet");
                    Console.WriteLine("[4]: Settings");
                    Console.WriteLine("[5]: Reset program");
                    Console.WriteLine("[6]: Quit");
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
                        currentMenuState = MenuState.viewTimeCard;
                    else if (choice == 4)
                        currentMenuState = MenuState.settings;
                    else if (choice == 5)
                        currentMenuState = MenuState.reset;
                    else if (choice == 6)
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
                case MenuState.viewTimeCard:
                    new Fileread();
                    new PresentTimeSheet();
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
