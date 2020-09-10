using Microsoft.Extensions.Logging;

namespace EasyConsole.BetterDemo
{
    public class App
    {
        private readonly ILogger<App> logger;

        public App(ILogger<App> logger)
        {
            this.logger = logger;
        }

        public void Run()
        {
            var init = new AppManager("EasyDemo", true);

            init.Run();
        }
    }
}
