using System;
using System.IO;

using EasyConsole.BetterDemo.Pages;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace EasyConsole.BetterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<AppManagerOptions>(opt => { opt.Title = "A Wonderful Demo App"; opt.BreadCrumbHeader = true; });

                    services.AddSingleton<AppManager>();
                    services.AddTransient<MainPage>();
                })
                .UseSerilog()
                .Build();

            var app = ActivatorUtilities.CreateInstance<AppManager>(host.Services);

            app.Run();

        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            var environment = 
                Environment.GetEnvironmentVariable("CONSOLENETCORE_ENVIRONMENT") ?? Environments.Production;

            var environmentappsettingsPath = $"appsettings.{environment}.json";

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile(environmentappsettingsPath, optional: true)
                .AddEnvironmentVariables();
        }
    }
}
