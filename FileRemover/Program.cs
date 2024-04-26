using FileRemover.Controllers;
using FileRemover.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileRemover;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
 
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var host = CreateHostBuilder().Build();
        ServiceProvider = host.Services;

        Application.Run(ServiceProvider.GetRequiredService<MainWindowForm>());
    }

    public static IServiceProvider ServiceProvider { get; private set; }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => {
                services.AddScoped<MainWindowForm>();
                services.AddScoped<MainWindowController>();
                services.AddScoped<FileService>();
            });
    }
}