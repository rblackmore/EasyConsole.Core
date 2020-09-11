using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsole.BetterDemo.Pages
{
    public class MainPage : Page
    {

        public MainPage(AppManager appManager) : 
            base(
                "Main Page",
                appManager, 
                new Option("Go to Page 1", () => appManager.NavigateTo<Page1>())
                )
        {
            this.Menu.Add(new Option("Say Hello", SayHi));
        }

        private void SayHi()
        {
            string name = Input.ReadString("Enter name: ");
            Output.WriteLine(ConsoleColor.Cyan, "Hello, {0}", name);

            Input.ReadKey();
        }
    }
}
