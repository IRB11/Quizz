using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using System.IO;

namespace Quizz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog((context, configuration) =>
                {
                    configuration.Enrich.FromLogContext().WriteTo.Console();
                    configuration.Enrich.FromLogContext().WriteTo.File(new RenderedCompactJsonFormatter(), @$"{Directory.GetCurrentDirectory()}\appLog.json", rollingInterval: RollingInterval.Day);
                }, writeToProviders: true)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
