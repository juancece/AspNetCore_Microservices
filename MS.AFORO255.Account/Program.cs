using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.Metrics.Metrics;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace MS.AFORO255.Account
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration((host, builder) =>
                    {
                        var env = host.HostingEnvironment;
                        builder.AddConfigServer(env.EnvironmentName);
                    });
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseAppMetrics();
                });
    }
}