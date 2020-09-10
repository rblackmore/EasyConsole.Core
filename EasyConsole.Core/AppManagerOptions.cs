namespace EasyConsole
{
    /// <summary>
    /// Options for <see cref="AppManager"/>.
    /// </summary>
    public class AppManagerOptions
    {
        /// <summary>
        /// Gets or Sets the App Title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not a Breadcrumb Header should be displayed.
        /// </summary>
        public bool BreadCrumbHeader { get; set; }
    }
}
