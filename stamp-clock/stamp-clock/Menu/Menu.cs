using System;
using System.Collections.Generic;
using System.Text;

namespace stamp_clock
{
    enum MenuPost
    {
        menu,
        punchin,
        punchout,
        settings,
        reset
    }

    class Menu
    {
        public Menu()
        {
            MenuPost currentMenuPost = MenuPost.menu;
            InitiateMenu(currentMenuPost);
        }
        private void InitiateMenu(MenuPost menupost)
        {
            switch (menupost)
            {
                case MenuPost.menu:
                    Console.Clear();
                    Console.WriteLine("[1]: Punch-IN");
                    Console.WriteLine("[2]: Punch-OUT");
                    Console.WriteLine("[3]: Reset Time-System");
                    Console.WriteLine("[4]: Settings");
                    Console.Write("Make choice + ENTER: ");
                    Console.ReadLine();
                    break;
                case MenuPost.punchin:
                    break;
                case MenuPost.punchout:
                    break;
                case MenuPost.reset:
                    break;
                case MenuPost.settings:
                    break;
            }
        }

    }
}
