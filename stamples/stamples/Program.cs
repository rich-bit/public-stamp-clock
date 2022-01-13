using System;

namespace stamples
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;
            MenuState currentMenustate = MenuState.menu;
            Settings settings = new Settings();
            new Settings();

            while (runProgram)
            {
                new Menu(ref runProgram, ref currentMenustate);
            }
        }
    }
}
