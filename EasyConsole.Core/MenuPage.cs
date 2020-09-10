using System;
using System.ComponentModel;

namespace EasyConsole
{
    public abstract class MenuPage : Page
    {
        protected Menu Menu { get; set; }

        public MenuPage(string title, AppManager appManager) : base(title, appManager)
        {
            this.Menu = new Menu();
        }

        public MenuPage Add(string name, Action callback)
        {
            return Add(new Option(name, callback));
        }

        public MenuPage Add(Option option)
        {
            Menu.Add(option);
            return this;
        }

        public MenuPage Add(Option[] options)
        {
            foreach (var option in options)
            {
                Menu.Add(option);
            }

            return this;
        }

        public override void Display()
        {
            base.Display();

            if (this.AppManager.NavigationEnabled && !this.Menu.Contains("Go back"))
                this.Menu.Add("Go back", () => { this.AppManager.NavigateBack(); });

            Menu.Display();
        }
    }
}
