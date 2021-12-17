using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Configuring Log */
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File
                (
                    path: "Logs\\log-.txt", /* path where the log file will be stored */
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", /* what are the info that log will contain */
                    rollingInterval: RollingInterval.Day, /* a new log file will be created each day */
                    restrictedToMinimumLevel: LogEventLevel.Information /* keeping log information to min level */
                ).CreateLogger();

            try
            {
                Log.Information("Application is starting"); //adding a log
                CreateHostBuilder(args).Build().Run();
            }
            catch(Exception exception)
            {
                Log.Fatal(exception, "Application failed to start");
            }
            finally
            {
                Log.CloseAndFlush();
            }

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
