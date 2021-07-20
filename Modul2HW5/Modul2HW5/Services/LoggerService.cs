using System;
using Modul2HW5.Enums;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IConfigService _config;
        private readonly IFileService _fileService;
        private string _log;
        public LoggerService(IFileService fileService, IConfigService config)
        {
            _fileService = fileService;
            _config = config;
        }

        public void CreateLog(LogTypes logType, string message)
        {
            _log = $"{DateTime.UtcNow.ToString(_config.LoggerConfig.TimeFormat)} {logType}: {message}";
            Console.WriteLine(_log);
            _fileService.WriteToFile(_log);
        }
    }
}
