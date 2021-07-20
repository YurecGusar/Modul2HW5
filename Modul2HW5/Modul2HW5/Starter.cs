using System;
using System.IO;
using Modul2HW5.Enums;
using Modul2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Modul2HW5
{
    public class Starter
    {
        private readonly IActions _actions;
        private readonly ILoggerService _logger;
        private readonly IFileService _fileService;
        public Starter(
            IActions actions,
            ILoggerService logger,
            IFileService fileService)
        {
            _actions = actions;
            _logger = logger;
            _fileService = fileService;
        }

        public void Run()
        {
            var quantityRunMethods = 100;
            for (var i = 0; i < quantityRunMethods; i++)
            {
                try
                {
                    GetRandomMethod();
                }
                catch (BusinessExceptions.BusinessException bEx)
                {
                    _logger.CreateLog(LogTypes.WARNING, $"Action got this custom Exception: {bEx.Message}");
                }
                catch (Exception ex)
                {
                    _logger.CreateLog(LogTypes.ERROR, $"Action failed by reason: {ex}");
                }
            }
        }

        private void GetRandomMethod()
        {
            switch (new Random().Next(4))
            {
                case 1:
                    _actions.InfoAction();
                    break;
                case 2:
                    _actions.BusinesExceptionAction();
                    break;
                case 3:
                    _actions.ExceptionAction();
                    break;
            }
        }
    }
}
