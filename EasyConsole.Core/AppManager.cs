namespace EasyConsole
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class AppManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppManager"/> class.
        /// </summary>
        /// <param name="options"><see cref="AppManagerOptions"/> Optional configuration parameters.</param>
        public AppManager(AppManagerOptions options = null)
        {
            this.Pages = new Dictionary<Type, Page>();
            this.History = new Stack<Page>();

            if (options != null)
            {
                this.Title = options.Title;
                this.BreadcrumbHeader = options.BreadCrumbHeader;
            }
        }

        public string Title { get; set; }

        public bool BreadcrumbHeader { get; private set; }

        public Stack<Page> History { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not navigation is enabled.
        /// Navigation is enabled if there are pages in the <see cref="History"/>.
        /// </summary>
        public bool NavigationEnabled
        {
            get { return this.History.Count > 1; }
        }

        protected Page CurrentPage
        {
            get
            {
                return this.History.Any() ? this.History.Peek() : null;
            }
        }

        private Dictionary<Type, Page> Pages { get; set; }

        /// <summary>
        /// Runs the applicaiton by displaying the first page.
        /// </summary>
        public virtual void Run()
        {
            try
            {
                if (this.Title != null)
                    Console.Title = this.Title;

                this.CurrentPage.Display();
            }
            catch (Exception e)
            {
                Output.WriteLine(ConsoleColor.Red, e.ToString());
            }
            finally
            {
                if (Debugger.IsAttached)
                {
                    Input.ReadString("Press [Enter] to exit");
                }
            }
        }

        /// <summary>
        /// Navigates to the Main Menu Page.
        /// </summary>
        public void NavigateHome()
        {
            while (this.History.Count > 1)
                this.History.Pop();

            this.DisplayCurrentPage();
        }

        /// <summary>
        /// Sets current page, and navigates to it.
        /// </summary>
        /// <typeparam name="T">The page type to navigate to.</typeparam>
        /// <returns>The current page.</returns>
        public T NavigateTo<T>() where T : Page
        {
            this.SetPage<T>();

            this.DisplayCurrentPage();
            return this.CurrentPage as T;
        }

        /// <summary>
        /// Navigates to the previous page, and sets it as the current page.
        /// </summary>
        /// <returns>The previous page.</returns>
        public Page NavigateBack()
        {
            this.History.Pop();

            this.DisplayCurrentPage();
            return this.CurrentPage;
        }

        public void AddPage(Page page)
        {
            if (page == null)
                throw new ArgumentNullException(nameof(page));

            Type pageType = page.GetType();

            if (this.Pages.ContainsKey(pageType))
                this.Pages[pageType] = page;
            else
                this.Pages.Add(pageType, page);
        }

        /// <summary>
        /// Set the current page, and push it onto the History.
        /// If provided page is already current, simply return the current page.
        /// </summary>
        /// <typeparam name="T">The Page to set as current.</typeparam>
        /// <returns>The current page.</returns>
        protected T SetPage<T>() where T : Page
        {
            Type pageType = typeof(T);

            if (this.CurrentPage != null && this.CurrentPage.GetType() == pageType)
                return this.CurrentPage as T;

            if (!this.Pages.TryGetValue(pageType, out Page nextPage))
                throw new KeyNotFoundException($"The given page \"{pageType.FullName}\" was not present");

            this.History.Push(nextPage);

            return this.CurrentPage as T;
        }

        private void DisplayCurrentPage()
        {
            Console.Clear();

            // Display Breadcrumb Titles if Enabled.
            if (this.History.Count > 1 && this.BreadcrumbHeader)
            {
                StringBuilder breadcrumb = new StringBuilder();

                var pageTitleHistoryReversed = this.History.Select((page) => page.Title).Reverse();

                foreach (var title in pageTitleHistoryReversed)
                {
                    breadcrumb.Append($"{title} > ");
                }

                breadcrumb.Remove(breadcrumb.Length - 3, 3);

                Console.WriteLine(breadcrumb.ToString());
            }
            else
            {
                Console.WriteLine(this.Title);
            }

            Console.WriteLine("---");

            this.CurrentPage.Display();
        }
    }
}
