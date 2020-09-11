using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsole.BetterDemo.Pages
{
    public class Page1 : Page
    {
        public Page1(AppManager appManager) : 
            base("This is Page 1", appManager, new Option("Exit", () => appManager.Close()))
        {
            this.Menu.Add("Roll a D6", () => 
            { 
                Output.WriteLine(ConsoleColor.Green, $"Roll 1-6: {new Random().Next(1, 6)}"); 
                Input.ReadKey(); 
            });

        }
    }
}
