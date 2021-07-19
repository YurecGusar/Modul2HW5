using Modul2HW5.Configs;

namespace Modul2HW5.Services.Abstractions
{
    public interface IConfigService
    {
        public LoggerConfig LoggerConfig { get; set; }
    }
}
