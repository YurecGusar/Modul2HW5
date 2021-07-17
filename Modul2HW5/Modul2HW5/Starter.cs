using System;
using Modul2HW5.Services.Abstractions;

namespace Modul2HW5
{
    public class Starter
    {
        private readonly IActions _actions;
        public Starter(
            IActions actions,
            IFileService fileService)
        {
            _actions = actions;
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
