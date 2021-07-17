using System;
using Modul2HW5.Enums;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;
        private string _log;
        public LoggerService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void CreateLog(LogTypes logType, string message)
        {
            _log = $"{DateTime.UtcNow}: {logType}: {message}";
            Console.WriteLine(_log);
            _fileService.WriteToFile(_log);
        }
    }
}
