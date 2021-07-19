using System;
using System.IO;
using Modul2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Modul2HW5
{
    public class Starter
    {
        private readonly IActions _actions;
        private readonly IFileService _fileService;
        private readonly IConfigService _configService;
        public Starter(
            IActions actions,
            IFileService fileService,
            IConfigService configService)
        {
            _actions = actions;
            _fileService = fileService;
            _configService = configService;
        }

        public void Run()
        {
            for (var i = 0; i < 100; i++)
            {
                switch (new Random().Next(_configService.LoggerConfig.DirectorySize + 1))
                {
                    case 1:
                        _actions.InfoAction();
                        break;
                    case 2:
                        try
                        {
                            _actions.BusinesExceptionAction();
                        }
                        catch (BusinessExceptions.BusinessException)
                        {
                        }

                        break;
                    case 3:
                        try
                        {
                            _actions.ExceptionAction();
                        }
                        catch (Exception)
                        {
                        }

                        break;
                }
            }
        }
    }
}
