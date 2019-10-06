using System;
using System.IO;
using API;
using API.Model;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DatabaseLoader
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(Start);
        }

        private static void Start(Options opts)
        {
            IServiceCollection services = BuildServiceCollection(opts);
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                sp.GetService<CameraParser>()
                    .LoadCsv();
            }
        }

        private static IServiceCollection BuildServiceCollection(Options opts)
        {
            if (!File.Exists(opts.dbPath))
                throw new FileNotFoundException($"could not find SqliteFile {opts.dbPath}");

            if (!File.Exists(opts.csvPath))
                throw new FileNotFoundException($"Could not find file {opts.csvPath}");

            var connString = $"Data Source = {opts.dbPath}";


            return new ServiceCollection()
                .AddDbContext<CameraContext>(options =>
                    options.UseSqlite(connString).EnableSensitiveDataLogging())
                .AddSingleton(o => opts)
                .AddScoped<CameraParser>();
        }
    }
}