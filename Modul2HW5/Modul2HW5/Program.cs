using System;
using Microsoft.Extensions.DependencyInjection;
using Modul2HW5.Services;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<Starter>()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<IActions, Actions>()
                .AddTransient<IFileService, FileService>()
                .BuildServiceProvider();
            var start = serviceProvider.GetService<Starter>();
            start.Run();
        }
    }
}
