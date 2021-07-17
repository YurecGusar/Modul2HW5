using System;
using Modul2HW5.BusinessExceptions;
using Modul2HW5.Enums;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5.Services
{
    public class Actions : IActions
    {
        private readonly ILoggerService _logger;
        public Actions(ILoggerService logger)
        {
            _logger = logger;
        }

        public bool InfoAction()
        {
            var message = $"Start method: {nameof(InfoAction)}";
            _logger.CreateLog(LogTypes.INFO, message);
            return true;
        }

        public void BusinesExceptionAction()
        {
            var message = "Skipped logic in method";
            _logger.CreateLog(LogTypes.WARNING, message);
            throw new BusinessException(message);
        }

        public void ExceptionAction()
        {
            var message = "I broke a logic";
            _logger.CreateLog(LogTypes.ERROR, message);
            throw new Exception(message);
        }
    }
}
