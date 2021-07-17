using System;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5
{
    public class Starter
    {
        private readonly IActions _actions;
        private readonly IFileService _fileService;
        public Starter(
            IActions actions,
            IFileService fileService)
        {
            _actions = actions;
            _fileService = fileService;
        }

        public void Run()
        {
            _actions.InfoAction();
            try
            {
                _actions.BusinesExceptionAction();
            }
            catch (BusinessExceptions.BusinessException)
            {
            }

            try
            {
                _actions.ExceptionAction();
            }
            catch (Exception)
            {
            }
        }
    }
}
