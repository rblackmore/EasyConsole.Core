using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsole.BetterDemo.Pages
{
    public class MainPage : MenuPage
    {
        public MainPage(AppManager appManager) : base("Main Page", appManager)
        {
            Add("Say Hi", SayHi);
        }

        private void SayHi()
        {
            string name = Input.ReadString("Enter name: ");
            Output.WriteLine(ConsoleColor.Cyan, "Hello, {0}", name);
        }
    }
}
