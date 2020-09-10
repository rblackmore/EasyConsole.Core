namespace EasyConsole
{
    using System;
    using System.Linq;

    public abstract class Page
    {
        protected Menu Menu { get; set; }

        public Page(string title, AppManager appManager, params Option[] options)
        {
            this.Title = title;
            this.AppManager = appManager;

            this.Menu = new Menu();

            foreach (var option in options)
            {
                this.Menu.Add(option);
            }
        }

        public string Title { get; private set; }

        public AppManager AppManager { get; set; }

        public virtual void Display()
        {
            if (this.AppManager.NavigationEnabled && !this.Menu.Contains("Go Back"))
                this.Menu.Add("Go Back", () => { this.AppManager.NavigateBack(); });

            this.Menu.Display();
        }
    }
}
