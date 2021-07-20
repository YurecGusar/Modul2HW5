using Modul2HW5.Enums;

namespace Modul2HW5.Services.Abstractions
{
    public interface ILoggerService
    {
        public void CreateLog(LogTypes logType, string message);
    }
}
