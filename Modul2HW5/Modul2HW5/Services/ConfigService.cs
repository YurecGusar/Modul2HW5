using System.IO;
using Modul2HW5.Configs;
using Modul2HW5.Services.Abstractions;
using Newtonsoft.Json;

namespace Modul2HW5.Services
{
    public class ConfigService : IConfigService
    {
        private const string _jsonFileName = @"E:\A-Level\YurecGusar\Modul2HW5\Modul2HW5\Modul2HW5\Configs\Config.json";
        public ConfigService()
        {
            /*Serialization(GetConfig());*/
            var config = DeSerialization();
            LoggerConfig = config.LoggerConfig;
        }

        public LoggerConfig LoggerConfig { get; set; }
        private Config GetConfig()
        {
            return new Config
            {
                LoggerConfig = new LoggerConfig
                {
                    DirectoryName = @"Logs\",
                    DirectorySize = 3,
                    FileExtension = ".txt",
                    FileNameFormat = "hh.mm.ss dd.MM.yyyy",
                    TimeFormat = "hh:mm:ss"
                }
            };
        }

        private void Serialization(Config newConfig)
        {
            var config = newConfig;
            var json = JsonConvert.SerializeObject(config);
            File.WriteAllText(_jsonFileName, json);
        }

        private Config DeSerialization()
        {
            var readFile = File.ReadAllText(_jsonFileName);
            var config = JsonConvert.DeserializeObject<Config>(readFile);
            return config;
        }
    }
}
