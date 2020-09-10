using System;
using System.Linq;

namespace EasyConsole
{
    public abstract class Page
    {
        public string Title { get; private set; }

        public AppManager AppManager { get; set; }

        public Page(string title, AppManager appManager)
        {
            Title = title;
            AppManager = appManager;
        }

        public virtual void Display()
        {
            if (AppManager.History.Count > 1 && AppManager.BreadcrumbHeader)
            {
                string breadcrumb = null;
                foreach (var title in AppManager.History.Select((page) => page.Title).Reverse())
                    breadcrumb += title + " > ";
                breadcrumb = breadcrumb.Remove(breadcrumb.Length - 3);
                Console.WriteLine(breadcrumb);
            }
            else
            {
                Console.WriteLine(Title);
            }
            Console.WriteLine("---");
        }
    }
}
