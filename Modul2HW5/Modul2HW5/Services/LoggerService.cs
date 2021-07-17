using System;
using Modul2HW5.Enums;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        public void CreateLog(LogTypes logType, string message)
        {
            var log = $"{DateTime.UtcNow}: {logType}: {message}";
            Console.WriteLine(log);
        }
    }
}
