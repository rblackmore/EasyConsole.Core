using System;
using System.Collections.Generic;
using System.Text;

namespace EasyConsole.Demo.Pages
{
    public class MainPage : MenuPage
    {
        public MainPage(AppManager program)
            : base ("Main Page", program)
        {
            Add(new Option("Page 1", () => AppManager.NavigateTo<Page1>()));
        }
    }
}
