using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsole.BetterDemo.Pages
{
    public class MainPage : Page
    {
        public MainPage(AppManager appManager) : base("Main Page", appManager)
        {
            this.Menu.Add(new Option("Say Hello", SayHi));
        }

        private void SayHi()
        {
            string name = Input.ReadString("Enter name: ");
            Output.WriteLine(ConsoleColor.Cyan, "Hello, {0}", name);
        }
    }
}
